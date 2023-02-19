﻿
namespace RenameHierarchy
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        	this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
        	this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.nameLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.enableUndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.freeReleasesPublicDomainisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.originalThreadDonationCodercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sourceCodeGithubcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
        	this.mainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.activityToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.addButton = new System.Windows.Forms.Button();
        	this.removeButton = new System.Windows.Forms.Button();
        	this.mainMenuStrip.SuspendLayout();
        	this.mainStatusStrip.SuspendLayout();
        	this.tableLayoutPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mainMenuStrip
        	// 
        	this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem,
        	        	        	this.minimizeToolStripMenuItem,
        	        	        	this.toolsToolStripMenuItem,
        	        	        	this.helpToolStripMenuItem});
        	this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
        	this.mainMenuStrip.Name = "mainMenuStrip";
        	this.mainMenuStrip.Size = new System.Drawing.Size(246, 24);
        	this.mainMenuStrip.TabIndex = 27;
        	// 
        	// fileToolStripMenuItem
        	// 
        	this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.exitToolStripMenuItem});
        	this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        	this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        	this.fileToolStripMenuItem.Text = "&File";
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
        	this.exitToolStripMenuItem.Text = "E&xit";
        	this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
        	// 
        	// minimizeToolStripMenuItem
        	// 
        	this.minimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
        	this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
        	this.minimizeToolStripMenuItem.Visible = false;
        	// 
        	// toolsToolStripMenuItem
        	// 
        	this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.customizeToolStripMenuItem,
        	        	        	this.optionsToolStripMenuItem});
        	this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
        	this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
        	this.toolsToolStripMenuItem.Text = "&Tools";
        	// 
        	// customizeToolStripMenuItem
        	// 
        	this.customizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.nameLengthToolStripMenuItem});
        	this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
        	this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
        	this.customizeToolStripMenuItem.Text = "&Customize";
        	// 
        	// nameLengthToolStripMenuItem
        	// 
        	this.nameLengthToolStripMenuItem.Name = "nameLengthToolStripMenuItem";
        	this.nameLengthToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
        	this.nameLengthToolStripMenuItem.Text = "&Name length";
        	this.nameLengthToolStripMenuItem.Click += new System.EventHandler(this.OnNameLengthToolStripMenuItemClick);
        	// 
        	// optionsToolStripMenuItem
        	// 
        	this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.enableUndoToolStripMenuItem});
        	this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
        	this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
        	this.optionsToolStripMenuItem.Text = "&Options";
        	this.optionsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnOptionsToolStripMenuItemDropDownItemClicked);
        	// 
        	// enableUndoToolStripMenuItem
        	// 
        	this.enableUndoToolStripMenuItem.Checked = true;
        	this.enableUndoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.enableUndoToolStripMenuItem.Name = "enableUndoToolStripMenuItem";
        	this.enableUndoToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
        	this.enableUndoToolStripMenuItem.Text = "&Enable undo";
        	// 
        	// helpToolStripMenuItem
        	// 
        	this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.freeReleasesPublicDomainisToolStripMenuItem,
        	        	        	this.originalThreadDonationCodercomToolStripMenuItem,
        	        	        	this.sourceCodeGithubcomToolStripMenuItem,
        	        	        	this.toolStripSeparator2,
        	        	        	this.aboutToolStripMenuItem});
        	this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        	this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.helpToolStripMenuItem.Text = "&Help";
        	// 
        	// freeReleasesPublicDomainisToolStripMenuItem
        	// 
        	this.freeReleasesPublicDomainisToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("freeReleasesPublicDomainisToolStripMenuItem.Image")));
        	this.freeReleasesPublicDomainisToolStripMenuItem.Name = "freeReleasesPublicDomainisToolStripMenuItem";
        	this.freeReleasesPublicDomainisToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.freeReleasesPublicDomainisToolStripMenuItem.Text = "Free Releases @ PublicDomain.is";
        	this.freeReleasesPublicDomainisToolStripMenuItem.Click += new System.EventHandler(this.OnFreeReleasesPublicDomainisToolStripMenuItemClick);
        	// 
        	// originalThreadDonationCodercomToolStripMenuItem
        	// 
        	this.originalThreadDonationCodercomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("originalThreadDonationCodercomToolStripMenuItem.Image")));
        	this.originalThreadDonationCodercomToolStripMenuItem.Name = "originalThreadDonationCodercomToolStripMenuItem";
        	this.originalThreadDonationCodercomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.originalThreadDonationCodercomToolStripMenuItem.Text = "&Original thread @ DonationCoder.com";
        	this.originalThreadDonationCodercomToolStripMenuItem.Click += new System.EventHandler(this.OnOriginalThreadDonationCodercomToolStripMenuItemClick);
        	// 
        	// sourceCodeGithubcomToolStripMenuItem
        	// 
        	this.sourceCodeGithubcomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sourceCodeGithubcomToolStripMenuItem.Image")));
        	this.sourceCodeGithubcomToolStripMenuItem.Name = "sourceCodeGithubcomToolStripMenuItem";
        	this.sourceCodeGithubcomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.sourceCodeGithubcomToolStripMenuItem.Text = "Source code @ Github.com";
        	this.sourceCodeGithubcomToolStripMenuItem.Click += new System.EventHandler(this.OnSourceCodeGithubcomToolStripMenuItemClick);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(275, 6);
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.aboutToolStripMenuItem.Text = "&About...";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
        	// 
        	// mainStatusStrip
        	// 
        	this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.mainToolStripStatusLabel,
        	        	        	this.activityToolStripStatusLabel});
        	this.mainStatusStrip.Location = new System.Drawing.Point(0, 123);
        	this.mainStatusStrip.Name = "mainStatusStrip";
        	this.mainStatusStrip.Size = new System.Drawing.Size(246, 22);
        	this.mainStatusStrip.SizingGrip = false;
        	this.mainStatusStrip.TabIndex = 26;
        	// 
        	// mainToolStripStatusLabel
        	// 
        	this.mainToolStripStatusLabel.Name = "mainToolStripStatusLabel";
        	this.mainToolStripStatusLabel.Size = new System.Drawing.Size(150, 17);
        	this.mainToolStripStatusLabel.Text = "Rename hierarchy menu is:";
        	// 
        	// activityToolStripStatusLabel
        	// 
        	this.activityToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.activityToolStripStatusLabel.Name = "activityToolStripStatusLabel";
        	this.activityToolStripStatusLabel.Size = new System.Drawing.Size(52, 17);
        	this.activityToolStripStatusLabel.Text = "Inactive";
        	// 
        	// tableLayoutPanel
        	// 
        	this.tableLayoutPanel.ColumnCount = 1;
        	this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel.Controls.Add(this.addButton, 0, 0);
        	this.tableLayoutPanel.Controls.Add(this.removeButton, 0, 1);
        	this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
        	this.tableLayoutPanel.Name = "tableLayoutPanel";
        	this.tableLayoutPanel.RowCount = 2;
        	this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
        	this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
        	this.tableLayoutPanel.Size = new System.Drawing.Size(246, 99);
        	this.tableLayoutPanel.TabIndex = 28;
        	// 
        	// addButton
        	// 
        	this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.addButton.Location = new System.Drawing.Point(3, 3);
        	this.addButton.Name = "addButton";
        	this.addButton.Size = new System.Drawing.Size(240, 58);
        	this.addButton.TabIndex = 0;
        	this.addButton.Text = "&Add to Windows Explorer";
        	this.addButton.UseVisualStyleBackColor = true;
        	this.addButton.Click += new System.EventHandler(this.OnAddButtonClick);
        	// 
        	// removeButton
        	// 
        	this.removeButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.removeButton.Location = new System.Drawing.Point(3, 67);
        	this.removeButton.Name = "removeButton";
        	this.removeButton.Size = new System.Drawing.Size(240, 29);
        	this.removeButton.TabIndex = 1;
        	this.removeButton.Text = "&Remove from Windows Explorer";
        	this.removeButton.UseVisualStyleBackColor = true;
        	this.removeButton.Click += new System.EventHandler(this.OnRemoveButtonClick);
        	// 
        	// MainForm
        	// 
        	this.AcceptButton = this.addButton;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(246, 145);
        	this.Controls.Add(this.tableLayoutPanel);
        	this.Controls.Add(this.mainMenuStrip);
        	this.Controls.Add(this.mainStatusStrip);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "MainForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Rename hierarchy";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
        	this.Load += new System.EventHandler(this.OnMainFormLoad);
        	this.mainMenuStrip.ResumeLayout(false);
        	this.mainMenuStrip.PerformLayout();
        	this.mainStatusStrip.ResumeLayout(false);
        	this.mainStatusStrip.PerformLayout();
        	this.tableLayoutPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripMenuItem enableUndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameLengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolStripStatusLabel activityToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeGithubcomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originalThreadDonationCodercomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeReleasesPublicDomainisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
    }
}
