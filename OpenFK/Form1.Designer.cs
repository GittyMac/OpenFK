namespace OpenFK
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
            this.AS2Container = new OpenFK.FlashRightClick();
            this.AS3Container = new OpenFK.FlashRightClick();
            ((System.ComponentModel.ISupportInitialize)(this.AS2Container)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS3Container)).BeginInit();
            this.SuspendLayout();
            // 
            // AS2Container
            // 
            this.AS2Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AS2Container.Enabled = true;
            this.AS2Container.Location = new System.Drawing.Point(0, 0);
            this.AS2Container.Name = "AS2Container";
            this.AS2Container.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AS2Container.OcxState")));
            this.AS2Container.Size = new System.Drawing.Size(800, 600);
            this.AS2Container.TabIndex = 0;
            // 
            // AS3Container
            // 
            this.AS3Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AS3Container.Enabled = true;
            this.AS3Container.Location = new System.Drawing.Point(0, 0);
            this.AS3Container.Name = "AS3Container";
            this.AS3Container.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AS3Container.OcxState")));
            this.AS3Container.Size = new System.Drawing.Size(800, 600);
            this.AS3Container.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.AS2Container);
            this.Controls.Add(this.AS3Container);
            this.Name = "Form1";
            this.Text = "OpenFK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AS2Container)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AS3Container)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlashRightClick AS2Container;
        private FlashRightClick AS3Container;
    }
}

