namespace NavEditor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.ApproachPanel.SuspendLayout();
            this.Glidepath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppGpBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppFreqBox)).BeginInit();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 201);
            this.Controls.Add(this.ApproachPanel);
            this.Controls.Add(this.ApproachSelect);
            this.Controls.Add(this.ApproachLabel);
            this.Controls.Add(this.AirportLabel);
            this.Controls.Add(this.AirportText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "NavEditor";
            this.ApproachPanel.ResumeLayout(false);
            this.ApproachPanel.PerformLayout();
            this.Glidepath.ResumeLayout(false);
            this.Glidepath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppGpBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppFreqBox)).EndInit();
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
    }
}

