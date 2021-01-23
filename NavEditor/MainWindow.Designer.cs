namespace NavEditor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.AirportText = new System.Windows.Forms.TextBox();
            this.AirportLabel = new System.Windows.Forms.Label();
            this.ApproachLabel = new System.Windows.Forms.Label();
            this.ApproachSelect = new System.Windows.Forms.ComboBox();
            this.ApproachPanel = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Glidepath = new System.Windows.Forms.Panel();
            this.AppGpBox = new System.Windows.Forms.NumericUpDown();
            this.AppGpLabel = new System.Windows.Forms.Label();
            this.AppRwyBox = new System.Windows.Forms.ComboBox();
            this.AppFreqBox = new System.Windows.Forms.NumericUpDown();
            this.AppFreqLabel = new System.Windows.Forms.Label();
            this.AppRwyLabel = new System.Windows.Forms.Label();
            this.AppIdentBox = new System.Windows.Forms.TextBox();
            this.AppIdentLabel = new System.Windows.Forms.Label();
            this.divider1 = new System.Windows.Forms.Label();
            this.AptDirBtn = new System.Windows.Forms.Button();
            this.NavDirBtn = new System.Windows.Forms.Button();
            this.aptDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.navDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Reminder = new System.Windows.Forms.Label();
            this.divider2 = new System.Windows.Forms.Label();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.divider6 = new System.Windows.Forms.Label();
            this.divider5 = new System.Windows.Forms.Label();
            this.CreditsLabel = new System.Windows.Forms.Label();
            this.ViewCredits = new System.Windows.Forms.Button();
            this.divider4 = new System.Windows.Forms.Label();
            this.NavReLabel = new System.Windows.Forms.Label();
            this.RefreshNav = new System.Windows.Forms.Button();
            this.divider3 = new System.Windows.Forms.Label();
            this.AptReLabel = new System.Windows.Forms.Label();
            this.RefreshAirports = new System.Windows.Forms.Button();
            this.ApproachPanel.SuspendLayout();
            this.Glidepath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppGpBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppFreqBox)).BeginInit();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AirportText
            // 
            this.AirportText.Location = new System.Drawing.Point(18, 24);
            this.AirportText.Name = "AirportText";
            this.AirportText.Size = new System.Drawing.Size(100, 20);
            this.AirportText.TabIndex = 0;
            this.AirportText.TextChanged += new System.EventHandler(this.AirportText_TextChanged);
            // 
            // AirportLabel
            // 
            this.AirportLabel.AutoSize = true;
            this.AirportLabel.Location = new System.Drawing.Point(15, 8);
            this.AirportLabel.Name = "AirportLabel";
            this.AirportLabel.Size = new System.Drawing.Size(65, 13);
            this.AirportLabel.TabIndex = 1;
            this.AirportLabel.Text = "Airport ICAO";
            // 
            // ApproachLabel
            // 
            this.ApproachLabel.AutoSize = true;
            this.ApproachLabel.Location = new System.Drawing.Point(140, 9);
            this.ApproachLabel.Name = "ApproachLabel";
            this.ApproachLabel.Size = new System.Drawing.Size(53, 13);
            this.ApproachLabel.TabIndex = 2;
            this.ApproachLabel.Text = "Approach";
            // 
            // ApproachSelect
            // 
            this.ApproachSelect.BackColor = System.Drawing.SystemColors.Window;
            this.ApproachSelect.FormattingEnabled = true;
            this.ApproachSelect.Location = new System.Drawing.Point(139, 23);
            this.ApproachSelect.Name = "ApproachSelect";
            this.ApproachSelect.Size = new System.Drawing.Size(114, 21);
            this.ApproachSelect.TabIndex = 3;
            this.ApproachSelect.SelectedIndexChanged += new System.EventHandler(this.ApproachSelect_SelectedIndexChanged);
            // 
            // ApproachPanel
            // 
            this.ApproachPanel.Controls.Add(this.SaveButton);
            this.ApproachPanel.Controls.Add(this.Glidepath);
            this.ApproachPanel.Controls.Add(this.AppRwyBox);
            this.ApproachPanel.Controls.Add(this.AppFreqBox);
            this.ApproachPanel.Controls.Add(this.AppFreqLabel);
            this.ApproachPanel.Controls.Add(this.AppRwyLabel);
            this.ApproachPanel.Controls.Add(this.AppIdentBox);
            this.ApproachPanel.Controls.Add(this.AppIdentLabel);
            this.ApproachPanel.Location = new System.Drawing.Point(12, 52);
            this.ApproachPanel.Name = "ApproachPanel";
            this.ApproachPanel.Size = new System.Drawing.Size(251, 135);
            this.ApproachPanel.TabIndex = 4;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(6, 100);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Glidepath
            // 
            this.Glidepath.Controls.Add(this.AppGpBox);
            this.Glidepath.Controls.Add(this.AppGpLabel);
            this.Glidepath.Location = new System.Drawing.Point(112, 55);
            this.Glidepath.Name = "Glidepath";
            this.Glidepath.Size = new System.Drawing.Size(129, 38);
            this.Glidepath.TabIndex = 7;
            // 
            // AppGpBox
            // 
            this.AppGpBox.DecimalPlaces = 2;
            this.AppGpBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AppGpBox.Location = new System.Drawing.Point(15, 15);
            this.AppGpBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AppGpBox.Name = "AppGpBox";
            this.AppGpBox.Size = new System.Drawing.Size(114, 20);
            this.AppGpBox.TabIndex = 1;
            this.AppGpBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // AppGpLabel
            // 
            this.AppGpLabel.AutoSize = true;
            this.AppGpLabel.Location = new System.Drawing.Point(16, 0);
            this.AppGpLabel.Name = "AppGpLabel";
            this.AppGpLabel.Size = new System.Drawing.Size(95, 13);
            this.AppGpLabel.TabIndex = 0;
            this.AppGpLabel.Text = "Glidepath Degrees";
            // 
            // AppRwyBox
            // 
            this.AppRwyBox.FormattingEnabled = true;
            this.AppRwyBox.Location = new System.Drawing.Point(6, 69);
            this.AppRwyBox.Name = "AppRwyBox";
            this.AppRwyBox.Size = new System.Drawing.Size(100, 21);
            this.AppRwyBox.TabIndex = 6;
            // 
            // AppFreqBox
            // 
            this.AppFreqBox.DecimalPlaces = 3;
            this.AppFreqBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.AppFreqBox.Location = new System.Drawing.Point(127, 19);
            this.AppFreqBox.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.AppFreqBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.AppFreqBox.Name = "AppFreqBox";
            this.AppFreqBox.Size = new System.Drawing.Size(114, 20);
            this.AppFreqBox.TabIndex = 5;
            this.AppFreqBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // AppFreqLabel
            // 
            this.AppFreqLabel.AutoSize = true;
            this.AppFreqLabel.Location = new System.Drawing.Point(124, 4);
            this.AppFreqLabel.Name = "AppFreqLabel";
            this.AppFreqLabel.Size = new System.Drawing.Size(106, 13);
            this.AppFreqLabel.TabIndex = 4;
            this.AppFreqLabel.Text = "Approach Frequency";
            // 
            // AppRwyLabel
            // 
            this.AppRwyLabel.AutoSize = true;
            this.AppRwyLabel.Location = new System.Drawing.Point(3, 55);
            this.AppRwyLabel.Name = "AppRwyLabel";
            this.AppRwyLabel.Size = new System.Drawing.Size(95, 13);
            this.AppRwyLabel.TabIndex = 2;
            this.AppRwyLabel.Text = "Approach Runway";
            // 
            // AppIdentBox
            // 
            this.AppIdentBox.Location = new System.Drawing.Point(6, 20);
            this.AppIdentBox.Name = "AppIdentBox";
            this.AppIdentBox.Size = new System.Drawing.Size(100, 20);
            this.AppIdentBox.TabIndex = 1;
            // 
            // AppIdentLabel
            // 
            this.AppIdentLabel.AutoSize = true;
            this.AppIdentLabel.Location = new System.Drawing.Point(3, 3);
            this.AppIdentLabel.Name = "AppIdentLabel";
            this.AppIdentLabel.Size = new System.Drawing.Size(83, 13);
            this.AppIdentLabel.TabIndex = 0;
            this.AppIdentLabel.Text = "Approach Ident.";
            // 
            // divider1
            // 
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(12, 194);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(251, 2);
            this.divider1.TabIndex = 5;
            // 
            // AptDirBtn
            // 
            this.AptDirBtn.Location = new System.Drawing.Point(12, 200);
            this.AptDirBtn.Name = "AptDirBtn";
            this.AptDirBtn.Size = new System.Drawing.Size(98, 23);
            this.AptDirBtn.TabIndex = 6;
            this.AptDirBtn.Text = "Airports Folder";
            this.AptDirBtn.UseVisualStyleBackColor = true;
            this.AptDirBtn.Click += new System.EventHandler(this.AptFoldBtn_Click);
            // 
            // NavDirBtn
            // 
            this.NavDirBtn.Location = new System.Drawing.Point(165, 200);
            this.NavDirBtn.Name = "NavDirBtn";
            this.NavDirBtn.Size = new System.Drawing.Size(98, 23);
            this.NavDirBtn.TabIndex = 7;
            this.NavDirBtn.Text = "Navigation Folder";
            this.NavDirBtn.UseVisualStyleBackColor = true;
            this.NavDirBtn.Click += new System.EventHandler(this.NavDirBtn_Click);
            // 
            // aptDirDialog
            // 
            this.aptDirDialog.ShowNewFolderButton = false;
            // 
            // Reminder
            // 
            this.Reminder.ForeColor = System.Drawing.Color.Red;
            this.Reminder.Location = new System.Drawing.Point(4, 174);
            this.Reminder.Name = "Reminder";
            this.Reminder.Size = new System.Drawing.Size(265, 39);
            this.Reminder.TabIndex = 9;
            this.Reminder.Text = "Remember to pull the Airports Repository and Merge\r\nthe Navigation Upstream into " +
    "your branch to\r\nensure everything is up-to-date!";
            this.Reminder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divider2
            // 
            this.divider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider2.Location = new System.Drawing.Point(269, 9);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(2, 219);
            this.divider2.TabIndex = 10;
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.MessageLabel);
            this.InfoPanel.Controls.Add(this.divider6);
            this.InfoPanel.Controls.Add(this.divider5);
            this.InfoPanel.Controls.Add(this.CreditsLabel);
            this.InfoPanel.Controls.Add(this.ViewCredits);
            this.InfoPanel.Controls.Add(this.divider4);
            this.InfoPanel.Controls.Add(this.NavReLabel);
            this.InfoPanel.Controls.Add(this.RefreshNav);
            this.InfoPanel.Controls.Add(this.divider3);
            this.InfoPanel.Controls.Add(this.AptReLabel);
            this.InfoPanel.Controls.Add(this.RefreshAirports);
            this.InfoPanel.Controls.Add(this.Reminder);
            this.InfoPanel.Location = new System.Drawing.Point(277, 8);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(271, 217);
            this.InfoPanel.TabIndex = 11;
            // 
            // MessageLabel
            // 
            this.MessageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(7, 6);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(258, 25);
            this.MessageLabel.TabIndex = 20;
            this.MessageLabel.Text = "Welcome to NavEditor!";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divider6
            // 
            this.divider6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider6.Location = new System.Drawing.Point(7, 169);
            this.divider6.Name = "divider6";
            this.divider6.Size = new System.Drawing.Size(261, 2);
            this.divider6.TabIndex = 19;
            // 
            // divider5
            // 
            this.divider5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider5.Location = new System.Drawing.Point(7, 123);
            this.divider5.Name = "divider5";
            this.divider5.Size = new System.Drawing.Size(261, 2);
            this.divider5.TabIndex = 18;
            // 
            // CreditsLabel
            // 
            this.CreditsLabel.Location = new System.Drawing.Point(113, 132);
            this.CreditsLabel.Name = "CreditsLabel";
            this.CreditsLabel.Size = new System.Drawing.Size(152, 33);
            this.CreditsLabel.TabIndex = 17;
            this.CreditsLabel.Text = "Thank you to everyone who helped me make NavEditor.";
            // 
            // ViewCredits
            // 
            this.ViewCredits.Location = new System.Drawing.Point(10, 137);
            this.ViewCredits.Name = "ViewCredits";
            this.ViewCredits.Size = new System.Drawing.Size(97, 23);
            this.ViewCredits.TabIndex = 16;
            this.ViewCredits.Text = "View Credits";
            this.ViewCredits.UseVisualStyleBackColor = true;
            this.ViewCredits.Click += new System.EventHandler(this.ViewCredits_Click);
            // 
            // divider4
            // 
            this.divider4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider4.Location = new System.Drawing.Point(7, 71);
            this.divider4.Name = "divider4";
            this.divider4.Size = new System.Drawing.Size(261, 2);
            this.divider4.TabIndex = 15;
            // 
            // NavReLabel
            // 
            this.NavReLabel.Location = new System.Drawing.Point(110, 76);
            this.NavReLabel.Name = "NavReLabel";
            this.NavReLabel.Size = new System.Drawing.Size(155, 44);
            this.NavReLabel.TabIndex = 14;
            this.NavReLabel.Text = "Use if the Navigation Files have been changed outside of NavEditor.";
            // 
            // RefreshNav
            // 
            this.RefreshNav.Location = new System.Drawing.Point(10, 85);
            this.RefreshNav.Name = "RefreshNav";
            this.RefreshNav.Size = new System.Drawing.Size(97, 23);
            this.RefreshNav.TabIndex = 13;
            this.RefreshNav.Text = "Refresh Nav";
            this.RefreshNav.UseVisualStyleBackColor = true;
            this.RefreshNav.Click += new System.EventHandler(this.RefreshNav_Click);
            // 
            // divider3
            // 
            this.divider3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider3.Location = new System.Drawing.Point(7, 35);
            this.divider3.Name = "divider3";
            this.divider3.Size = new System.Drawing.Size(262, 2);
            this.divider3.TabIndex = 12;
            // 
            // AptReLabel
            // 
            this.AptReLabel.Location = new System.Drawing.Point(107, 39);
            this.AptReLabel.Name = "AptReLabel";
            this.AptReLabel.Size = new System.Drawing.Size(158, 32);
            this.AptReLabel.TabIndex = 11;
            this.AptReLabel.Text = "Use if you can\'t find an Airport\'s Approaches.";
            // 
            // RefreshAirports
            // 
            this.RefreshAirports.Location = new System.Drawing.Point(10, 40);
            this.RefreshAirports.Name = "RefreshAirports";
            this.RefreshAirports.Size = new System.Drawing.Size(97, 23);
            this.RefreshAirports.TabIndex = 10;
            this.RefreshAirports.Text = "Refresh Airports";
            this.RefreshAirports.UseVisualStyleBackColor = true;
            this.RefreshAirports.Click += new System.EventHandler(this.RefreshAirports_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 237);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.divider2);
            this.Controls.Add(this.NavDirBtn);
            this.Controls.Add(this.AptDirBtn);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.ApproachPanel);
            this.Controls.Add(this.ApproachSelect);
            this.Controls.Add(this.ApproachLabel);
            this.Controls.Add(this.AirportLabel);
            this.Controls.Add(this.AirportText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "NavEditor";
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.ApproachPanel.ResumeLayout(false);
            this.ApproachPanel.PerformLayout();
            this.Glidepath.ResumeLayout(false);
            this.Glidepath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppGpBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppFreqBox)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AirportText;
        private System.Windows.Forms.Label AirportLabel;
        private System.Windows.Forms.Label ApproachLabel;
        private System.Windows.Forms.ComboBox ApproachSelect;
        private System.Windows.Forms.Panel ApproachPanel;
        private System.Windows.Forms.Label AppIdentLabel;
        private System.Windows.Forms.TextBox AppIdentBox;
        private System.Windows.Forms.Label AppRwyLabel;
        private System.Windows.Forms.NumericUpDown AppFreqBox;
        private System.Windows.Forms.Label AppFreqLabel;
        private System.Windows.Forms.ComboBox AppRwyBox;
        private System.Windows.Forms.Panel Glidepath;
        private System.Windows.Forms.NumericUpDown AppGpBox;
        private System.Windows.Forms.Label AppGpLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.Button AptDirBtn;
        private System.Windows.Forms.Button NavDirBtn;
        private System.Windows.Forms.FolderBrowserDialog aptDirDialog;
        private System.Windows.Forms.FolderBrowserDialog navDirDialog;
        private System.Windows.Forms.Label Reminder;
        private System.Windows.Forms.Label divider2;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label AptReLabel;
        private System.Windows.Forms.Button RefreshAirports;
        private System.Windows.Forms.Label divider3;
        private System.Windows.Forms.Button RefreshNav;
        private System.Windows.Forms.Label NavReLabel;
        private System.Windows.Forms.Label divider5;
        private System.Windows.Forms.Label CreditsLabel;
        private System.Windows.Forms.Button ViewCredits;
        private System.Windows.Forms.Label divider4;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label divider6;
    }
}

