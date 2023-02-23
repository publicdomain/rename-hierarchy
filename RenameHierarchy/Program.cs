using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Alphaleonis.Win32.Filesystem;
using LiteDB;
using PublicDomain;

namespace RenameHierarchy
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// The settings data.
        /// </summary>
        private static SettingsData settingsData = null;

        /// <summary>
        /// The settings data path.
        /// </summary>
        private static string settingsDataPath = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), $"{Application.ProductName}-SettingsData.txt");

        /// <summary>
        /// The errors file path.
        /// </summary>
        private static string errorsFilePath = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), $"{Application.ProductName}-ErrorLog.txt");

        /// <summary>
        /// The undo db path.
        /// </summary>
        private static string undoDbPath = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), $"{Application.ProductName}-UNDO.db");

        /// <summary>
        /// The errors list.
        /// </summary>
        private static List<string> errorsList = new List<string>();

        /// <summary>
        /// The rename dictionary.
        /// </summary>
        private static Dictionary<string, string> renameDictionary = new Dictionary<string, string>();

        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // Check for arguments and valid directory
            if (args.Length > 0)
            {
                // Set directory path
                string directoryPath = args[0];

                // Try for non-rename hierarchy errors
                try
                {
                    // Check it's a valid directory path
                    if (!Directory.Exists(directoryPath))
                    {
                        // Halt flow
                        return;
                    }

                    // Open database (or create it)
                    using (var db = new LiteDatabase(undoDbPath))
                    {
                        // Get collection
                        var renameDataCollection = db.GetCollection<RenameData>("renameDataCollection");

                        // Try to get a previous operation result on current directory
                        var undoResult = renameDataCollection.Find(x => x.DirectoryPath == directoryPath).FirstOrDefault();

                        // Check there's something to undo
                        if (undoResult != null)
                        {
                            // Ask user and set dialog result
                            DialogResult dialogResult = MessageBox.Show("Would you like to UNDO last hierarchy renaming?", "Rename hierarchy UNDO", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            // Act upon user answer
                            if (dialogResult == DialogResult.Yes)
                            {
                                // Set sorted paths list
                                List<string> sortedPathsList = undoResult.RenameDictionary.Keys.OrderBy(p => p.Count(c => c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar)).ToList<string>();

                                // Iterate sorted paths
                                for (int i = 0; i < sortedPathsList.Count; i++)
                                {
                                    try
                                    {
                                        // Set current
                                        string renamedPath = sortedPathsList[i];

                                        // Set previous
                                        string originalPath = undoResult.RenameDictionary[renamedPath];

                                        // Check directory exists
                                        if (Directory.Exists(renamedPath))
                                        {
                                            // Rename
                                            Directory.Move(renamedPath, originalPath);
                                        }
                                    }
                                    catch  /*(Exception ex)*/
                                    {
                                        // TODO Let it fall through [User can be advised if there are differences or errors in a future version]
                                    }
                                }

                                // Remove from collection
                                renameDataCollection.Delete(undoResult.Id);

                                // Halt flow by YES
                                return;
                            }
                            else if (dialogResult == DialogResult.Cancel)
                            {
                                // Halt flow by Cancel
                                return;
                            }

                            // Continue by NO
                        }

                        /* Settings data */

                        // Check for settings file
                        if (!File.Exists(settingsDataPath))
                        {
                            // Create new settings file
                            Shared.SaveSettingsFile(settingsDataPath, new SettingsData());
                        }

                        // Load settings from disk
                        settingsData = Shared.LoadSettingsFile(settingsDataPath);

                        /* Process the directory */

                        // Rename the passed directory hierarchy
                        string newDirectoryPath = RenameHierarchy(directoryPath);

                        /* LiteDB */

                        // Create new rename data instance
                        var renameData = new RenameData
                        {
                            DirectoryPath = newDirectoryPath,
                            RenameDictionary = renameDictionary,
                            RenameDateTime = DateTime.UtcNow
                        };

                        // Insert rename data document
                        renameDataCollection.Insert(renameData);

                        // Index using a directory path property
                        renameDataCollection.EnsureIndex(x => x.DirectoryPath);
                    }

                    /* Save errors to file */

                    // Check for errors
                    if (errorsList.Count > 0)
                    {
                        try
                        {
                            // Write separator with directory name
                            File.WriteAllText(errorsFilePath, $"{Environment.NewLine}{Environment.NewLine}[{directoryPath}]{Environment.NewLine}");

                            // Write to disk
                            File.AppendAllLines(errorsFilePath, errorsList);
                        }
                        catch
                        {
                            // TODO Error when writing log [Can be made DRY, perhaps via library]
                            MessageBox.Show("Could not write error log file.", "Rename hierarchy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    /* Advise user */

                    // Message of success with optional error count
                    MessageBox.Show($"Renamed the folder hierarchy {(errorsList.Count == 0 ? "successfully" : $"with {errorsList.Count} errors")}.", "Rename hierarchy", MessageBoxButtons.OK, (errorsList.Count == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error));
                }
                catch (Exception ex)
                {
                    try
                    {
                        // Write separator with directory name
                        File.WriteAllText(errorsFilePath, $"{Environment.NewLine}{Environment.NewLine}[{directoryPath}]{Environment.NewLine}{ex.Message}");
                    }
                    catch
                    {
                        // TODO Error when writing log [Can be made DRY, perhaps via library]
                        MessageBox.Show("Could not write error log file.", "Rename hierarchy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    /* Advise user */

                    // Message of error
                    MessageBox.Show($"Error when renaming folder hierarchy:{Environment.NewLine}{Environment.NewLine}{ex.Message}", "Rename hierarchy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // By user
            {
                // Run main form
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }

        /// <summary>
        /// Renames the hierarchy.
        /// </summary>
        /// <param name="directoryPath">Directory path.</param>
        private static string RenameHierarchy(string directoryPath)
        {
            // Set directory info
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            // Iterate subdirectories
            foreach (DirectoryInfo subdirectoryInfo in directoryInfo.GetDirectories("*", System.IO.SearchOption.TopDirectoryOnly))
            {
                // Use recursion
                RenameHierarchy(subdirectoryInfo.FullName);
            }

            // The new directory path
            string newDirectoryPath = string.Empty;

            // Set retries
            int retries = 1;

            try
            {
                // Redo until it's a valid one
                do
                {
                    // Cap to 100 retries
                    if (retries == 100)
                    {
                        // Halt with an exception
                        throw new Exception("Retries exhausted.");
                    }

                    // TODO Set possible new name [Name length can be set automagically]
                    newDirectoryPath = Path.Combine(directoryInfo.Parent.FullName, GetRandomDirectoryName(settingsData.NameLength));

                    // Raise retries
                    retries++;
                } while (Directory.Exists(newDirectoryPath));

                // Rename with new random directory name
                directoryInfo.MoveTo(newDirectoryPath);

                // TODO Add to rename dictionary [May need another check for clearing new directory path if there was an error here]
                renameDictionary.Add(newDirectoryPath, directoryPath);
            }
            catch (Exception ex)
            {
                // Add to errors list
                errorsList.Add($"Error when renaming \"{directoryPath}\": {ex.Message}");

                // Clear new directory path since there was an error
                newDirectoryPath = string.Empty;
            }

            // Return the new directory path
            return newDirectoryPath;
        }

        /// <summary>
        /// Gets the random name of the directory.
        /// </summary>
        /// <returns>The random directory name.</returns>
        /// <param name="length">Length.</param>
        private static string GetRandomDirectoryName(int length)
        {
            // Set new random object
            Random random = new Random();

            // Return a numerical string with proper range
            return string.Join(string.Empty, Enumerable.Range(0, length).Select(number => random.Next(0, 9).ToString()));
        }
    }
}
