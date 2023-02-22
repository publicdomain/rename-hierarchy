using System;
using System.Collections.Generic;
using System.Diagnostics;
using Alphaleonis.Win32.Filesystem;
using System.Windows.Forms;
using System.Xml.Serialization;
using PublicDomain;
using System.Linq;

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
        /// The errors list.
        /// </summary>
        private static List<string> errorsList = new List<string>();

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

                // Check it's a valid directory path
                if (!Directory.Exists(directoryPath))
                {
                    // Halt flow
                    return;
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
                RenameHierarchy(directoryPath);

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
                    catch (Exception ex)
                    {
                        // Error when writing log
                        MessageBox.Show("Could not write error log file.", "Rename hierarchy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                /* Advise user */

                // Message of success with optional error count
                MessageBox.Show($"Renamed the folder hierarchy {(errorsList.Count == 0 ? "successfully" : $"with {errorsList.Count} errors")}.", "Rename hierarchy", MessageBoxButtons.OK, (errorsList.Count == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error));
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
        private static void RenameHierarchy(string directoryPath)
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

                // Rename with a random dirctory name
                directoryInfo.MoveTo(newDirectoryPath);
            }
            catch (Exception ex)
            {
                // Add to errors list
                errorsList.Add($"Error when renaming \"{directoryPath}\": {ex.Message}");
            }
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
