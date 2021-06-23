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
            this.rdfToggle = new System.Windows.Forms.CheckBox();
            this.USBToggle = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QualityCB
            // 
            this.QualityCB.FormattingEnabled = true;
            this.QualityCB.Items.AddRange(new object[] {
            "0 - High",
            "1 - Medium",
            "2 - Low"});
            this.QualityCB.Location = new System.Drawing.Point(171, 64);
            this.QualityCB.Name = "QualityCB";
            this.QualityCB.Size = new System.Drawing.Size(121, 21);
            this.QualityCB.TabIndex = 0;
            this.QualityCB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // customFtoggle
            // 
            this.customFtoggle.AutoSize = true;
            this.customFtoggle.Location = new System.Drawing.Point(34, 69);
            this.customFtoggle.Name = "customFtoggle";
            this.customFtoggle.Size = new System.Drawing.Size(104, 17);
            this.customFtoggle.TabIndex = 1;
            this.customFtoggle.Text = "Customf Support";
            this.customFtoggle.UseVisualStyleBackColor = true;
            this.customFtoggle.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RPCToggle
            // 
            this.RPCToggle.AutoSize = true;
            this.RPCToggle.Location = new System.Drawing.Point(34, 92);
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
            "0 - Default (Hor+)",
            "1 - Crop (Vert-)",
            "2 - Stretch",
            "3 - Pixel-based"});
            this.ScaleCB.Location = new System.Drawing.Point(171, 104);
            this.ScaleCB.Name = "ScaleCB";
            this.ScaleCB.Size = new System.Drawing.Size(121, 21);
            this.ScaleCB.TabIndex = 3;
            this.ScaleCB.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(243, 150);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Close";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdfToggle
            // 
            this.rdfToggle.AutoSize = true;
            this.rdfToggle.Location = new System.Drawing.Point(34, 46);
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
            this.USBToggle.Location = new System.Drawing.Point(34, 115);
            this.USBToggle.Name = "USBToggle";
            this.USBToggle.Size = new System.Drawing.Size(88, 17);
            this.USBToggle.TabIndex = 8;
            this.USBToggle.Text = "USB Support";
            this.USBToggle.UseVisualStyleBackColor = true;
            this.USBToggle.CheckedChanged += new System.EventHandler(this.USBToggle_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Graphics Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Scaling";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Game Settings";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 185);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.USBToggle);
            this.Controls.Add(this.rdfToggle);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ScaleCB);
            this.Controls.Add(this.RPCToggle);
            this.Controls.Add(this.customFtoggle);
            this.Controls.Add(this.QualityCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "OpenFK Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox QualityCB;
        private System.Windows.Forms.CheckBox customFtoggle;
        private System.Windows.Forms.CheckBox RPCToggle;
        private System.Windows.Forms.ComboBox ScaleCB;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.CheckBox rdfToggle;
        private System.Windows.Forms.CheckBox USBToggle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}