// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace RenameHierarchy
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Microsoft.VisualBasic;
    using Microsoft.Win32;
    using PublicDomain;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Gets or sets the associated icon.
        /// </summary>
        /// <value>The associated icon.</value>
        private Icon associatedIcon = null;

        /// <summary>
        /// The settings data.
        /// </summary>
        private SettingsData settingsData = null;

        /// <summary>
        /// The rename hierarchy key list.
        /// </summary>
        private List<string> renameHierarchyKeyList = new List<string>();

        /// <summary>
        /// The settings data path.
        /// </summary>
        private string settingsDataPath = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), $"{Application.ProductName}-SettingsData.txt");

        /// <summary>
        /// The associated icon bitmap.
        /// </summary>
        private Bitmap associatedIconBitmap = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RenameHierarchy.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            /* Set icons */

            // Set the bitmap for the associated icon
            this.associatedIconBitmap = (Bitmap)this.freeReleasesPublicDomainisToolStripMenuItem.Image;

            // Set associated icon from exe file
            this.associatedIcon = Icon.FromHandle(this.associatedIconBitmap.GetHicon());

            /* Settings data */

            // Check for settings file
            if (!File.Exists(this.settingsDataPath))
            {
                // Create new settings file
                Shared.SaveSettingsFile(this.settingsDataPath, new SettingsData());
            }

            // Load settings from disk
            this.settingsData = Shared.LoadSettingsFile(this.settingsDataPath);

            /* Set values */

            // Add context menu item text
            this.renameHierarchyKeyList.Add($"Software\\Classes\\directory\\shell\\{this.settingsData.ContextMenuItemText}");

            // Update the program by registry key
            this.UpdateByRegistryKey();

            // Set topmost checked state
            this.alwaysOnTopToolStripMenuItem.Checked = this.settingsData.AlwaysOnTop;
        }

        /// <summary>
        /// Updates the program by registry key.
        /// </summary>
        private void UpdateByRegistryKey()
        {
            // Try to set renameHierarchy key
            using (var renameHierarchyKey = Registry.CurrentUser.OpenSubKey(this.renameHierarchyKeyList[0]))
            {
                // Check for no returned registry key
                if (renameHierarchyKey == null)
                {
                    // Disable remove button
                    this.removeButton.Enabled = false;

                    // Enable add button
                    this.addButton.Enabled = true;

                    // Update status text
                    this.activityToolStripStatusLabel.Text = "Inactive";
                }
                else
                {
                    // Disable add button
                    this.addButton.Enabled = false;

                    // Enable remove button
                    this.removeButton.Enabled = true;

                    // Update status text
                    this.activityToolStripStatusLabel.Text = "Active";
                }
            }
        }

        /// <summary>
        /// Handles the add button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAddButtonClick(object sender, EventArgs e)
        {
            // Add the context menu
            this.AddContextMenu(true);
        }

        /// <summary>
        /// Handles the remove button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRemoveButtonClick(object sender, EventArgs e)
        {
            // Remove the context menu
            this.RemoveContextMenu(true);
        }

        /// <summary>
        /// Adds the context menu.
        /// </summary>
        /// <param name="advise">If set to <c>true</c> advise.</param>
        private void AddContextMenu(bool advise)
        {
            try
            {
                // Iterate renameHierarchy registry keys
                foreach (string renameHierarchyKey in this.renameHierarchyKeyList)
                {
                    // Add renameHierarchy command to registry
                    RegistryKey registryKey;
                    registryKey = Registry.CurrentUser.CreateSubKey(renameHierarchyKey);
                    registryKey.SetValue("icon", Application.ExecutablePath);
                    registryKey.SetValue("position", "-");
                    registryKey = Registry.CurrentUser.CreateSubKey($"{renameHierarchyKey}\\command");
                    registryKey.SetValue(string.Empty, $"{Path.Combine(Application.StartupPath, Application.ExecutablePath)} \"%1\"");
                    registryKey.Close();
                }

                // Check if must advise
                if (advise)
                {
                    // Update the program by registry key
                    this.UpdateByRegistryKey();

                    // Notify user
                    MessageBox.Show($"Rename hierarchy context menu added!{Environment.NewLine}{Environment.NewLine}Right-click in Windows Explorer to use it.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Notify user
                MessageBox.Show($"Error when adding rename hierarchy context menu to registry.{Environment.NewLine}{Environment.NewLine}Message:{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Removes the context menu.
        /// </summary>
        /// <param name="advise">If set to <c>true</c> advise.</param>
        private void RemoveContextMenu(bool advise)
        {
            try
            {
                // Iterate renameHierarchy registry keys 
                foreach (var renameHierarchyKey in this.renameHierarchyKeyList)
                {
                    // Remove renameHierarchy command to registry
                    Registry.CurrentUser.DeleteSubKeyTree(renameHierarchyKey);
                }

                // Check if must advise
                if (advise)
                {
                    // Update the program by registry key
                    this.UpdateByRegistryKey();

                    // Notify user
                    MessageBox.Show("Rename hierarchy context menu removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Notify user
                MessageBox.Show($"Error when removing rename hierarchy command from registry.{Environment.NewLine}{Environment.NewLine}Message:{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the free releases public domainis tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open our site
            Process.Start("https://publicdomain.is");
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open original thread
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=53141.0");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub repository
            Process.Start("https://github.com/publicdomain/rename-hierarchy");
        }

        /// <summary>
        /// Handles the about tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Set license text
            var licenseText = $"CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication{Environment.NewLine}" +
                $"https://creativecommons.org/publicdomain/zero/1.0/legalcode{Environment.NewLine}{Environment.NewLine}" +
                $"Libraries and icons have separate licenses.{Environment.NewLine}{Environment.NewLine}" +
                $"LiteDB database library by mbdavid (Mauricio David) - MIT license{Environment.NewLine}" +
                $"https://github.com/mbdavid/LiteDB{Environment.NewLine}{Environment.NewLine}" +
                $"AlphaFS library by Alphaleonis - MIT license{Environment.NewLine}" +
                $"https://github.com/alphaleonis/AlphaFS{Environment.NewLine}{Environment.NewLine}" +
                $"Rename item icon by Clker-Free-Vector-Images - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/rename-item-sign-symbol-27285/{Environment.NewLine}{Environment.NewLine}" +
                $"Patreon icon used according to published brand guidelines{Environment.NewLine}" +
                $"https://www.patreon.com/brand{Environment.NewLine}{Environment.NewLine}" +
                $"GitHub mark icon used according to published logos and usage guidelines{Environment.NewLine}" +
                $"https://github.com/logos{Environment.NewLine}{Environment.NewLine}" +
                $"DonationCoder icon used with permission{Environment.NewLine}" +
                $"https://www.donationcoder.com/forum/index.php?topic=48718{Environment.NewLine}{Environment.NewLine}" +
                $"PublicDomain icon is based on the following source images:{Environment.NewLine}{Environment.NewLine}" +
                $"Bitcoin by GDJ - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/bitcoin-digital-currency-4130319/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter P by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/p-glamour-gold-lights-2790632/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter D by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/d-glamour-gold-lights-2790573/{Environment.NewLine}{Environment.NewLine}";

            // Prepend sponsors
            licenseText = $"RELEASE SUPPORTERS:{Environment.NewLine}{Environment.NewLine}* Jesse Reichler{Environment.NewLine}* Max P.{Environment.NewLine}* Kathryn S.{Environment.NewLine}* Cranioscopical{Environment.NewLine}{Environment.NewLine}=========={Environment.NewLine}{Environment.NewLine}" + licenseText;

            // Set title
            string programTitle = typeof(MainForm).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;

            // Set version for generating semantic version
            Version version = typeof(MainForm).GetTypeInfo().Assembly.GetName().Version;

            // Set about form
            var aboutForm = new AboutForm(
                $"About {programTitle}",
                $"{programTitle} {version.Major}.{version.Minor}.{version.Build}",
                $"Made for: nkormanik{Environment.NewLine}DonationCoder.com{Environment.NewLine}Day #54, Week #08 @ February 23, 2023",
                licenseText,
                this.Icon.ToBitmap())
            {
                // Set about form icon
                Icon = this.associatedIcon,

                // Set always on top
                TopMost = this.TopMost
            };

            // Show about form
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Handles the folder name length tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFolderNameLengthToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Unset topmost
            this.TopMost = false;

            // Try to parse integer from user input
            if (int.TryParse(Interaction.InputBox("Enter new name length:", "Set name length", this.settingsData.NameLength.ToString()), out int parsedInt) && parsedInt > 0)
            {
                // Set 
                this.settingsData.NameLength = parsedInt;
            }

            // Set topmost
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the options tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Toggle checked
            toolStripMenuItem.Checked = !toolStripMenuItem.Checked;

            // Set topmost by check box
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the main form load.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Set topmost
            this.TopMost = this.settingsData.AlwaysOnTop;
        }

        /// <summary>
        /// Handles the main form form closing.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // Always on top
            this.settingsData.AlwaysOnTop = this.alwaysOnTopToolStripMenuItem.Checked;

            // Save settings data to disk
            Shared.SaveSettingsFile(this.settingsDataPath, this.settingsData);
        }

        /// <summary>
        /// Handles the context menu item text tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnContextMenuItemTextToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Unset topmost
            this.TopMost = false;

            // Set new context menu item text
            string contextMenuItemText = Interaction.InputBox("Enter new context menu item text:", "Set text", this.settingsData.ContextMenuItemText);

            // Set topmost
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;

            // Check it's not empty and it's actually a different one
            if (contextMenuItemText.Length > 0 && contextMenuItemText != this.settingsData.ContextMenuItemText)
            {
                // Check if it's active 
                if (this.activityToolStripStatusLabel.Text == "Active")
                {
                    // Remove current context menu
                    this.RemoveContextMenu(false);
                }

                // Set it into list (both active and inactive)
                this.renameHierarchyKeyList[0] = $"Software\\Classes\\directory\\shell\\{contextMenuItemText}";

                // Check if it's active again
                if (this.activityToolStripStatusLabel.Text == "Active")
                {
                    // Add new context menu
                    this.AddContextMenu(false);
                }

                // Set it into settings data
                this.settingsData.ContextMenuItemText = contextMenuItemText;
            }
        }

        /// <summary>
        /// Handles the exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close program        
            this.Close();
        }
    }
}
