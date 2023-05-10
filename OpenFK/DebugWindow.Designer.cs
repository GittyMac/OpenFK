
namespace OpenFK
{
    partial class DebugWindow
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
            this.generalLog = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.logTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.logTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalLog
            // 
            this.generalLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalLog.Location = new System.Drawing.Point(3, 3);
            this.generalLog.Name = "generalLog";
            this.generalLog.ReadOnly = true;
            this.generalLog.Size = new System.Drawing.Size(593, 423);
            this.generalLog.TabIndex = 0;
            this.generalLog.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.logTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 455);
            this.tabControl1.TabIndex = 1;
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.generalLog);
            this.logTab.Location = new System.Drawing.Point(4, 22);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(599, 429);
            this.logTab.TabIndex = 0;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 455);
            this.Controls.Add(this.tabControl1);
            this.Name = "DebugWindow";
            this.Text = "OpenFK - Debug";
            this.tabControl1.ResumeLayout(false);
            this.logTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox generalLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage logTab;
    }
}