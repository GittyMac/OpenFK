namespace OpenFK
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.QualityCB = new System.Windows.Forms.ComboBox();
            this.customFtoggle = new System.Windows.Forms.CheckBox();
            this.RPCToggle = new System.Windows.Forms.CheckBox();
            this.ScaleCB = new System.Windows.Forms.ComboBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.rdfToggle = new System.Windows.Forms.CheckBox();
            this.USBToggle = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // QualityCB
            // 
            this.QualityCB.FormattingEnabled = true;
            this.QualityCB.Items.AddRange(new object[] {
            "0 - High",
            "1 - Medium",
            "2 - Low"});
            this.QualityCB.Location = new System.Drawing.Point(12, 129);
            this.QualityCB.Name = "QualityCB";
            this.QualityCB.Size = new System.Drawing.Size(121, 21);
            this.QualityCB.TabIndex = 0;
            this.QualityCB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // customFtoggle
            // 
            this.customFtoggle.AutoSize = true;
            this.customFtoggle.Location = new System.Drawing.Point(12, 58);
            this.customFtoggle.Name = "customFtoggle";
            this.customFtoggle.Size = new System.Drawing.Size(66, 17);
            this.customFtoggle.TabIndex = 1;
            this.customFtoggle.Text = "customF";
            this.customFtoggle.UseVisualStyleBackColor = true;
            this.customFtoggle.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RPCToggle
            // 
            this.RPCToggle.AutoSize = true;
            this.RPCToggle.Location = new System.Drawing.Point(12, 81);
            this.RPCToggle.Name = "RPCToggle";
            this.RPCToggle.Size = new System.Drawing.Size(96, 17);
            this.RPCToggle.TabIndex = 2;
            this.RPCToggle.Text = "Rich Presence";
            this.RPCToggle.UseVisualStyleBackColor = true;
            this.RPCToggle.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ScaleCB
            // 
            this.ScaleCB.FormattingEnabled = true;
            this.ScaleCB.Items.AddRange(new object[] {
            "0 - Default (Zoom to Aspect Ratio)",
            "1 - Crop 4:3",
            "2 - Stretch 4:3",
            "3 - Dot by Dot"});
            this.ScaleCB.Location = new System.Drawing.Point(12, 156);
            this.ScaleCB.Name = "ScaleCB";
            this.ScaleCB.Size = new System.Drawing.Size(121, 21);
            this.ScaleCB.TabIndex = 3;
            this.ScaleCB.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 183);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Close";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Location = new System.Drawing.Point(12, 13);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(79, 13);
            this.header.TabIndex = 6;
            this.header.Text = "OpenFK Config";
            // 
            // rdfToggle
            // 
            this.rdfToggle.AutoSize = true;
            this.rdfToggle.Location = new System.Drawing.Point(12, 35);
            this.rdfToggle.Name = "rdfToggle";
            this.rdfToggle.Size = new System.Drawing.Size(89, 17);
            this.rdfToggle.TabIndex = 7;
            this.rdfToggle.Text = "RDF Loading";
            this.rdfToggle.UseVisualStyleBackColor = true;
            this.rdfToggle.CheckedChanged += new System.EventHandler(this.rdfToggle_CheckedChanged);
            // 
            // USBToggle
            // 
            this.USBToggle.AutoSize = true;
            this.USBToggle.Location = new System.Drawing.Point(12, 104);
            this.USBToggle.Name = "USBToggle";
            this.USBToggle.Size = new System.Drawing.Size(88, 17);
            this.USBToggle.TabIndex = 8;
            this.USBToggle.Text = "USB Support";
            this.USBToggle.UseVisualStyleBackColor = true;
            this.USBToggle.CheckedChanged += new System.EventHandler(this.USBToggle_CheckedChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 218);
            this.Controls.Add(this.USBToggle);
            this.Controls.Add(this.rdfToggle);
            this.Controls.Add(this.header);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ScaleCB);
            this.Controls.Add(this.RPCToggle);
            this.Controls.Add(this.customFtoggle);
            this.Controls.Add(this.QualityCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox QualityCB;
        private System.Windows.Forms.CheckBox customFtoggle;
        private System.Windows.Forms.CheckBox RPCToggle;
        private System.Windows.Forms.ComboBox ScaleCB;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.CheckBox rdfToggle;
        private System.Windows.Forms.CheckBox USBToggle;
    }
}