﻿namespace OpenFK
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
            this.OnlineToggle = new System.Windows.Forms.CheckBox();
            this.HTTPBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TCPHostBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TCPPortBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.HTTPBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QualityCB
            // 
            this.QualityCB.FormattingEnabled = true;
            this.QualityCB.Items.AddRange(new object[] {
            "0 - High",
            "1 - Medium",
            "2 - Low"});
            this.QualityCB.Location = new System.Drawing.Point(204, 64);
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
            this.ScaleCB.Location = new System.Drawing.Point(204, 104);
            this.ScaleCB.Name = "ScaleCB";
            this.ScaleCB.Size = new System.Drawing.Size(121, 21);
            this.ScaleCB.TabIndex = 3;
            this.ScaleCB.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(248, 283);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(101, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Save and Close";
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
            this.label1.Location = new System.Drawing.Point(199, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Graphics Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Quality";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(199, 88);
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
            // OnlineToggle
            // 
            this.OnlineToggle.AutoSize = true;
            this.OnlineToggle.Location = new System.Drawing.Point(134, 176);
            this.OnlineToggle.Name = "OnlineToggle";
            this.OnlineToggle.Size = new System.Drawing.Size(92, 17);
            this.OnlineToggle.TabIndex = 14;
            this.OnlineToggle.Text = "Enable Online";
            this.OnlineToggle.UseVisualStyleBackColor = true;
            this.OnlineToggle.CheckedChanged += new System.EventHandler(this.OnlineToggle_CheckedChanged);
            // 
            // HTTPBox1
            // 
            this.HTTPBox1.Location = new System.Drawing.Point(78, 218);
            this.HTTPBox1.Name = "HTTPBox1";
            this.HTTPBox1.Size = new System.Drawing.Size(100, 20);
            this.HTTPBox1.TabIndex = 15;
            this.HTTPBox1.Text = "localhost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(75, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "HTTP Host 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "TCP Host";
            // 
            // TCPHostBox
            // 
            this.TCPHostBox.Location = new System.Drawing.Point(78, 257);
            this.TCPHostBox.Name = "TCPHostBox";
            this.TCPHostBox.Size = new System.Drawing.Size(100, 20);
            this.TCPHostBox.TabIndex = 18;
            this.TCPHostBox.Text = "localhost";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "OpenFK v0.0.0.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(184, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "TCP Port";
            // 
            // TCPPortBox
            // 
            this.TCPPortBox.Location = new System.Drawing.Point(187, 257);
            this.TCPPortBox.Name = "TCPPortBox";
            this.TCPPortBox.Size = new System.Drawing.Size(100, 20);
            this.TCPPortBox.TabIndex = 21;
            this.TCPPortBox.Text = "80";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(184, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "HTTP Host 2";
            // 
            // HTTPBox2
            // 
            this.HTTPBox2.Location = new System.Drawing.Point(187, 218);
            this.HTTPBox2.Name = "HTTPBox2";
            this.HTTPBox2.Size = new System.Drawing.Size(100, 20);
            this.HTTPBox2.TabIndex = 22;
            this.HTTPBox2.Text = "localhost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(118, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Network Settings";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 311);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.HTTPBox2);
            this.Controls.Add(this.TCPPortBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TCPHostBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.HTTPBox1);
            this.Controls.Add(this.OnlineToggle);
            this.Controls.Add(this.label5);
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
        private System.Windows.Forms.CheckBox OnlineToggle;
        private System.Windows.Forms.TextBox HTTPBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TCPHostBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TCPPortBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox HTTPBox2;
        private System.Windows.Forms.Label label5;
    }
}