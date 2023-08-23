
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
            this.generalLogs = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.logTab = new System.Windows.Forms.TabPage();
            this.FileLogsTab = new System.Windows.Forms.TabPage();
            this.fileLogs = new System.Windows.Forms.RichTextBox();
            this.incoming = new System.Windows.Forms.TabPage();
            this.incomingLogs = new System.Windows.Forms.RichTextBox();
            this.outgoing = new System.Windows.Forms.TabPage();
            this.outgoingLogs = new System.Windows.Forms.RichTextBox();
            this.CLogger = new System.Windows.Forms.TabPage();
            this.CLoggerTabControl = new System.Windows.Forms.TabControl();
            this.All = new System.Windows.Forms.TabPage();
            this.CLoggerAll = new System.Windows.Forms.RichTextBox();
            this.Trace = new System.Windows.Forms.TabPage();
            this.CLoggerTrace = new System.Windows.Forms.RichTextBox();
            this.Debug = new System.Windows.Forms.TabPage();
            this.CLoggerDebug = new System.Windows.Forms.RichTextBox();
            this.Info = new System.Windows.Forms.TabPage();
            this.CLoggerInfo = new System.Windows.Forms.RichTextBox();
            this.Warning = new System.Windows.Forms.TabPage();
            this.CLoggerWarning = new System.Windows.Forms.RichTextBox();
            this.Error = new System.Windows.Forms.TabPage();
            this.CLoggerError = new System.Windows.Forms.RichTextBox();
            this.Fatal = new System.Windows.Forms.TabPage();
            this.CLoggerFatal = new System.Windows.Forms.RichTextBox();
            this.network = new System.Windows.Forms.TabPage();
            this.NetworkTabs = new System.Windows.Forms.TabControl();
            this.NetworkAllTab = new System.Windows.Forms.TabPage();
            this.NetworkAllLogs = new System.Windows.Forms.RichTextBox();
            this.NetworkGetTab = new System.Windows.Forms.TabPage();
            this.NetworkGetLogs = new System.Windows.Forms.RichTextBox();
            this.NetworkPostTab = new System.Windows.Forms.TabPage();
            this.NetworkPostLogs = new System.Windows.Forms.RichTextBox();
            this.NetworkCommandTab = new System.Windows.Forms.TabPage();
            this.NetworkCommandLogs = new System.Windows.Forms.RichTextBox();
            this.staticStorageTab = new System.Windows.Forms.TabPage();
            this.staticStorageLogs = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.logTab.SuspendLayout();
            this.FileLogsTab.SuspendLayout();
            this.incoming.SuspendLayout();
            this.outgoing.SuspendLayout();
            this.CLogger.SuspendLayout();
            this.CLoggerTabControl.SuspendLayout();
            this.All.SuspendLayout();
            this.Trace.SuspendLayout();
            this.Debug.SuspendLayout();
            this.Info.SuspendLayout();
            this.Warning.SuspendLayout();
            this.Error.SuspendLayout();
            this.Fatal.SuspendLayout();
            this.network.SuspendLayout();
            this.NetworkTabs.SuspendLayout();
            this.NetworkAllTab.SuspendLayout();
            this.NetworkGetTab.SuspendLayout();
            this.NetworkPostTab.SuspendLayout();
            this.NetworkCommandTab.SuspendLayout();
            this.staticStorageTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalLogs
            // 
            this.generalLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalLogs.Location = new System.Drawing.Point(3, 3);
            this.generalLogs.Name = "generalLogs";
            this.generalLogs.ReadOnly = true;
            this.generalLogs.Size = new System.Drawing.Size(593, 423);
            this.generalLogs.TabIndex = 0;
            this.generalLogs.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.logTab);
            this.tabControl1.Controls.Add(this.FileLogsTab);
            this.tabControl1.Controls.Add(this.incoming);
            this.tabControl1.Controls.Add(this.outgoing);
            this.tabControl1.Controls.Add(this.CLogger);
            this.tabControl1.Controls.Add(this.network);
            this.tabControl1.Controls.Add(this.staticStorageTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 455);
            this.tabControl1.TabIndex = 1;
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.generalLogs);
            this.logTab.Location = new System.Drawing.Point(4, 22);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(599, 429);
            this.logTab.TabIndex = 0;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // FileLogsTab
            // 
            this.FileLogsTab.Controls.Add(this.fileLogs);
            this.FileLogsTab.Location = new System.Drawing.Point(4, 22);
            this.FileLogsTab.Name = "FileLogsTab";
            this.FileLogsTab.Padding = new System.Windows.Forms.Padding(3);
            this.FileLogsTab.Size = new System.Drawing.Size(599, 429);
            this.FileLogsTab.TabIndex = 1;
            this.FileLogsTab.Text = "File Logs";
            this.FileLogsTab.UseVisualStyleBackColor = true;
            // 
            // fileLogs
            // 
            this.fileLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileLogs.Location = new System.Drawing.Point(3, 3);
            this.fileLogs.Name = "fileLogs";
            this.fileLogs.ReadOnly = true;
            this.fileLogs.Size = new System.Drawing.Size(593, 423);
            this.fileLogs.TabIndex = 0;
            this.fileLogs.Text = "";
            // 
            // incoming
            // 
            this.incoming.Controls.Add(this.incomingLogs);
            this.incoming.Location = new System.Drawing.Point(4, 22);
            this.incoming.Name = "incoming";
            this.incoming.Padding = new System.Windows.Forms.Padding(3);
            this.incoming.Size = new System.Drawing.Size(599, 429);
            this.incoming.TabIndex = 3;
            this.incoming.Text = "Incoming";
            this.incoming.UseVisualStyleBackColor = true;
            // 
            // incomingLogs
            // 
            this.incomingLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.incomingLogs.Location = new System.Drawing.Point(3, 3);
            this.incomingLogs.Name = "incomingLogs";
            this.incomingLogs.ReadOnly = true;
            this.incomingLogs.Size = new System.Drawing.Size(593, 423);
            this.incomingLogs.TabIndex = 0;
            this.incomingLogs.Text = "";
            // 
            // outgoing
            // 
            this.outgoing.Controls.Add(this.outgoingLogs);
            this.outgoing.Location = new System.Drawing.Point(4, 22);
            this.outgoing.Name = "outgoing";
            this.outgoing.Size = new System.Drawing.Size(599, 429);
            this.outgoing.TabIndex = 4;
            this.outgoing.Text = "Outgoing";
            this.outgoing.UseVisualStyleBackColor = true;
            // 
            // outgoingLogs
            // 
            this.outgoingLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outgoingLogs.Location = new System.Drawing.Point(0, 0);
            this.outgoingLogs.Name = "outgoingLogs";
            this.outgoingLogs.ReadOnly = true;
            this.outgoingLogs.Size = new System.Drawing.Size(599, 429);
            this.outgoingLogs.TabIndex = 0;
            this.outgoingLogs.Text = "";
            // 
            // CLogger
            // 
            this.CLogger.Controls.Add(this.CLoggerTabControl);
            this.CLogger.Location = new System.Drawing.Point(4, 22);
            this.CLogger.Name = "CLogger";
            this.CLogger.Padding = new System.Windows.Forms.Padding(3);
            this.CLogger.Size = new System.Drawing.Size(599, 429);
            this.CLogger.TabIndex = 5;
            this.CLogger.Text = "CLogger";
            this.CLogger.UseVisualStyleBackColor = true;
            // 
            // CLoggerTabControl
            // 
            this.CLoggerTabControl.Controls.Add(this.All);
            this.CLoggerTabControl.Controls.Add(this.Trace);
            this.CLoggerTabControl.Controls.Add(this.Debug);
            this.CLoggerTabControl.Controls.Add(this.Info);
            this.CLoggerTabControl.Controls.Add(this.Warning);
            this.CLoggerTabControl.Controls.Add(this.Error);
            this.CLoggerTabControl.Controls.Add(this.Fatal);
            this.CLoggerTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLoggerTabControl.Location = new System.Drawing.Point(3, 3);
            this.CLoggerTabControl.Name = "CLoggerTabControl";
            this.CLoggerTabControl.SelectedIndex = 0;
            this.CLoggerTabControl.Size = new System.Drawing.Size(593, 423);
            this.CLoggerTabControl.TabIndex = 0;
            // 
            // All
            // 
            this.All.Controls.Add(this.CLoggerAll);
            this.All.Location = new System.Drawing.Point(4, 22);
            this.All.Name = "All";
            this.All.Padding = new System.Windows.Forms.Padding(3);
            this.All.Size = new System.Drawing.Size(585, 397);
            this.All.TabIndex = 0;
            this.All.Text = "All";
            this.All.UseVisualStyleBackColor = true;
            // 
            // CLoggerAll
            // 
            this.CLoggerAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLoggerAll.Location = new System.Drawing.Point(3, 3);
            this.CLoggerAll.Name = "CLoggerAll";
            this.CLoggerAll.ReadOnly = true;
            this.CLoggerAll.Size = new System.Drawing.Size(579, 391);
            this.CLoggerAll.TabIndex = 0;
            this.CLoggerAll.Text = "";
            // 
            // Trace
            // 
            this.Trace.Controls.Add(this.CLoggerTrace);
            this.Trace.Location = new System.Drawing.Point(4, 22);
            this.Trace.Name = "Trace";
            this.Trace.Padding = new System.Windows.Forms.Padding(3);
            this.Trace.Size = new System.Drawing.Size(585, 397);
            this.Trace.TabIndex = 1;
            this.Trace.Text = "Trace";
            this.Trace.UseVisualStyleBackColor = true;
            // 
            // CLoggerTrace
            // 
            this.CLoggerTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLoggerTrace.Location = new System.Drawing.Point(3, 3);
            this.CLoggerTrace.Name = "CLoggerTrace";
            this.CLoggerTrace.ReadOnly = true;
            this.CLoggerTrace.Size = new System.Drawing.Size(579, 391);
            this.CLoggerTrace.TabIndex = 1;
            this.CLoggerTrace.Text = "";
            // 
            // Debug
            // 
            this.Debug.Controls.Add(this.CLoggerDebug);
            this.Debug.Location = new System.Drawing.Point(4, 22);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(585, 397);
            this.Debug.TabIndex = 2;
            this.Debug.Text = "Debug";
            this.Debug.UseVisualStyleBackColor = true;
            // 
            // CLoggerDebug
            // 
            this.CLoggerDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLoggerDebug.Location = new System.Drawing.Point(0, 0);
            this.CLoggerDebug.Name = "CLoggerDebug";
            this.CLoggerDebug.ReadOnly = true;
            this.CLoggerDebug.Size = new System.Drawing.Size(585, 397);
            this.CLoggerDebug.TabIndex = 1;
            this.CLoggerDebug.Text = "";
            // 
            // Info
            // 
            this.Info.Controls.Add(this.CLoggerInfo);
            this.Info.Location = new System.Drawing.Point(4, 22);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(585, 397);
            this.Info.TabIndex = 3;
            this.Info.Text = "Info";
            this.Info.UseVisualStyleBackColor = true;
            // 
            // CLoggerInfo
            // 
            this.CLoggerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLoggerInfo.Location = new System.Drawing.Point(0, 0);
            this.CLoggerInfo.Name = "CLoggerInfo";
            this.CLoggerInfo.ReadOnly = true;
            this.CLoggerInfo.Size = new System.Drawing.Size(585, 397);
            this.CLoggerInfo.TabIndex = 1;
            this.CLoggerInfo.Text = "";
            // 
            // Warning
            // 
            this.Warning.Controls.Add(this.CLoggerWarning);
            this.Warning.Location = new System.Drawing.Point(4, 22);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(585, 397);
            this.Warning.TabIndex = 4;
            this.Warning.Text = "Warning";
            this.Warning.UseVisualStyleBackColor = true;
            // 
            // CLoggerWarning
            // 
            this.CLoggerWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLoggerWarning.Location = new System.Drawing.Point(0, 0);
            this.CLoggerWarning.Name = "CLoggerWarning";
            this.CLoggerWarning.ReadOnly = true;
            this.CLoggerWarning.Size = new System.Drawing.Size(585, 397);
            this.CLoggerWarning.TabIndex = 1;
            this.CLoggerWarning.Text = "";
            // 
            // Error
            // 
            this.Error.Controls.Add(this.CLoggerError);
            this.Error.Location = new System.Drawing.Point(4, 22);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(585, 397);
            this.Error.TabIndex = 5;
            this.Error.Text = "Error";
            this.Error.UseVisualStyleBackColor = true;
            // 
            // CLoggerError
            // 
            this.CLoggerError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLoggerError.Location = new System.Drawing.Point(0, 0);
            this.CLoggerError.Name = "CLoggerError";
            this.CLoggerError.ReadOnly = true;
            this.CLoggerError.Size = new System.Drawing.Size(585, 397);
            this.CLoggerError.TabIndex = 1;
            this.CLoggerError.Text = "";
            // 
            // Fatal
            // 
            this.Fatal.Controls.Add(this.CLoggerFatal);
            this.Fatal.Location = new System.Drawing.Point(4, 22);
            this.Fatal.Name = "Fatal";
            this.Fatal.Size = new System.Drawing.Size(585, 397);
            this.Fatal.TabIndex = 6;
            this.Fatal.Text = "Fatal";
            this.Fatal.UseVisualStyleBackColor = true;
            // 
            // CLoggerFatal
            // 
            this.CLoggerFatal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLoggerFatal.Location = new System.Drawing.Point(0, 0);
            this.CLoggerFatal.Name = "CLoggerFatal";
            this.CLoggerFatal.ReadOnly = true;
            this.CLoggerFatal.Size = new System.Drawing.Size(585, 397);
            this.CLoggerFatal.TabIndex = 1;
            this.CLoggerFatal.Text = "";
            // 
            // network
            // 
            this.network.Controls.Add(this.NetworkTabs);
            this.network.Location = new System.Drawing.Point(4, 22);
            this.network.Name = "network";
            this.network.Padding = new System.Windows.Forms.Padding(3);
            this.network.Size = new System.Drawing.Size(599, 429);
            this.network.TabIndex = 6;
            this.network.Text = "Network";
            this.network.UseVisualStyleBackColor = true;
            // 
            // NetworkTabs
            // 
            this.NetworkTabs.Controls.Add(this.NetworkAllTab);
            this.NetworkTabs.Controls.Add(this.NetworkGetTab);
            this.NetworkTabs.Controls.Add(this.NetworkPostTab);
            this.NetworkTabs.Controls.Add(this.NetworkCommandTab);
            this.NetworkTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkTabs.Location = new System.Drawing.Point(3, 3);
            this.NetworkTabs.Name = "NetworkTabs";
            this.NetworkTabs.SelectedIndex = 0;
            this.NetworkTabs.Size = new System.Drawing.Size(593, 423);
            this.NetworkTabs.TabIndex = 0;
            // 
            // NetworkAllTab
            // 
            this.NetworkAllTab.Controls.Add(this.NetworkAllLogs);
            this.NetworkAllTab.Location = new System.Drawing.Point(4, 22);
            this.NetworkAllTab.Name = "NetworkAllTab";
            this.NetworkAllTab.Padding = new System.Windows.Forms.Padding(3);
            this.NetworkAllTab.Size = new System.Drawing.Size(585, 397);
            this.NetworkAllTab.TabIndex = 0;
            this.NetworkAllTab.Text = "All";
            this.NetworkAllTab.UseVisualStyleBackColor = true;
            // 
            // NetworkAllLogs
            // 
            this.NetworkAllLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkAllLogs.Location = new System.Drawing.Point(3, 3);
            this.NetworkAllLogs.Name = "NetworkAllLogs";
            this.NetworkAllLogs.ReadOnly = true;
            this.NetworkAllLogs.Size = new System.Drawing.Size(579, 391);
            this.NetworkAllLogs.TabIndex = 0;
            this.NetworkAllLogs.Text = "";
            // 
            // NetworkGetTab
            // 
            this.NetworkGetTab.Controls.Add(this.NetworkGetLogs);
            this.NetworkGetTab.Location = new System.Drawing.Point(4, 22);
            this.NetworkGetTab.Name = "NetworkGetTab";
            this.NetworkGetTab.Padding = new System.Windows.Forms.Padding(3);
            this.NetworkGetTab.Size = new System.Drawing.Size(585, 397);
            this.NetworkGetTab.TabIndex = 1;
            this.NetworkGetTab.Text = "GET";
            this.NetworkGetTab.UseVisualStyleBackColor = true;
            // 
            // NetworkGetLogs
            // 
            this.NetworkGetLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkGetLogs.Location = new System.Drawing.Point(3, 3);
            this.NetworkGetLogs.Name = "NetworkGetLogs";
            this.NetworkGetLogs.ReadOnly = true;
            this.NetworkGetLogs.Size = new System.Drawing.Size(579, 391);
            this.NetworkGetLogs.TabIndex = 1;
            this.NetworkGetLogs.Text = "";
            // 
            // NetworkPostTab
            // 
            this.NetworkPostTab.Controls.Add(this.NetworkPostLogs);
            this.NetworkPostTab.Location = new System.Drawing.Point(4, 22);
            this.NetworkPostTab.Name = "NetworkPostTab";
            this.NetworkPostTab.Size = new System.Drawing.Size(585, 397);
            this.NetworkPostTab.TabIndex = 2;
            this.NetworkPostTab.Text = "POST";
            this.NetworkPostTab.UseVisualStyleBackColor = true;
            // 
            // NetworkPostLogs
            // 
            this.NetworkPostLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkPostLogs.Location = new System.Drawing.Point(0, 0);
            this.NetworkPostLogs.Name = "NetworkPostLogs";
            this.NetworkPostLogs.ReadOnly = true;
            this.NetworkPostLogs.Size = new System.Drawing.Size(585, 397);
            this.NetworkPostLogs.TabIndex = 1;
            this.NetworkPostLogs.Text = "";
            // 
            // NetworkCommandTab
            // 
            this.NetworkCommandTab.Controls.Add(this.NetworkCommandLogs);
            this.NetworkCommandTab.Location = new System.Drawing.Point(4, 22);
            this.NetworkCommandTab.Name = "NetworkCommandTab";
            this.NetworkCommandTab.Padding = new System.Windows.Forms.Padding(3);
            this.NetworkCommandTab.Size = new System.Drawing.Size(585, 397);
            this.NetworkCommandTab.TabIndex = 3;
            this.NetworkCommandTab.Text = "NetCommands";
            this.NetworkCommandTab.UseVisualStyleBackColor = true;
            // 
            // NetworkCommandLogs
            // 
            this.NetworkCommandLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkCommandLogs.Location = new System.Drawing.Point(3, 3);
            this.NetworkCommandLogs.Name = "NetworkCommandLogs";
            this.NetworkCommandLogs.ReadOnly = true;
            this.NetworkCommandLogs.Size = new System.Drawing.Size(579, 391);
            this.NetworkCommandLogs.TabIndex = 2;
            this.NetworkCommandLogs.Text = "";
            // 
            // staticStorageTab
            // 
            this.staticStorageTab.Controls.Add(this.staticStorageLogs);
            this.staticStorageTab.Location = new System.Drawing.Point(4, 22);
            this.staticStorageTab.Name = "staticStorageTab";
            this.staticStorageTab.Size = new System.Drawing.Size(599, 429);
            this.staticStorageTab.TabIndex = 7;
            this.staticStorageTab.Text = "CStaticStorage";
            this.staticStorageTab.UseVisualStyleBackColor = true;
            // 
            // staticStorageLogs
            // 
            this.staticStorageLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staticStorageLogs.Location = new System.Drawing.Point(0, 0);
            this.staticStorageLogs.Name = "staticStorageLogs";
            this.staticStorageLogs.ReadOnly = true;
            this.staticStorageLogs.Size = new System.Drawing.Size(599, 429);
            this.staticStorageLogs.TabIndex = 0;
            this.staticStorageLogs.Text = "";
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
            this.FileLogsTab.ResumeLayout(false);
            this.incoming.ResumeLayout(false);
            this.outgoing.ResumeLayout(false);
            this.CLogger.ResumeLayout(false);
            this.CLoggerTabControl.ResumeLayout(false);
            this.All.ResumeLayout(false);
            this.Trace.ResumeLayout(false);
            this.Debug.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Warning.ResumeLayout(false);
            this.Error.ResumeLayout(false);
            this.Fatal.ResumeLayout(false);
            this.network.ResumeLayout(false);
            this.NetworkTabs.ResumeLayout(false);
            this.NetworkAllTab.ResumeLayout(false);
            this.NetworkGetTab.ResumeLayout(false);
            this.NetworkPostTab.ResumeLayout(false);
            this.NetworkCommandTab.ResumeLayout(false);
            this.staticStorageTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox generalLogs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.TabPage FileLogsTab;
        private System.Windows.Forms.RichTextBox fileLogs;
        private System.Windows.Forms.TabPage incoming;
        private System.Windows.Forms.RichTextBox incomingLogs;
        private System.Windows.Forms.TabPage outgoing;
        private System.Windows.Forms.RichTextBox outgoingLogs;
        private System.Windows.Forms.TabPage CLogger;
        private System.Windows.Forms.TabControl CLoggerTabControl;
        private System.Windows.Forms.TabPage All;
        private System.Windows.Forms.RichTextBox CLoggerAll;
        private System.Windows.Forms.TabPage Trace;
        private System.Windows.Forms.RichTextBox CLoggerTrace;
        private System.Windows.Forms.TabPage Debug;
        private System.Windows.Forms.RichTextBox CLoggerDebug;
        private System.Windows.Forms.TabPage Info;
        private System.Windows.Forms.RichTextBox CLoggerInfo;
        private System.Windows.Forms.TabPage Warning;
        private System.Windows.Forms.RichTextBox CLoggerWarning;
        private System.Windows.Forms.TabPage Error;
        private System.Windows.Forms.RichTextBox CLoggerError;
        private System.Windows.Forms.TabPage Fatal;
        private System.Windows.Forms.RichTextBox CLoggerFatal;
        private System.Windows.Forms.TabPage network;
        private System.Windows.Forms.TabControl NetworkTabs;
        private System.Windows.Forms.TabPage NetworkAllTab;
        private System.Windows.Forms.TabPage NetworkGetTab;
        private System.Windows.Forms.TabPage NetworkPostTab;
        private System.Windows.Forms.RichTextBox NetworkAllLogs;
        private System.Windows.Forms.RichTextBox NetworkGetLogs;
        private System.Windows.Forms.RichTextBox NetworkPostLogs;
        private System.Windows.Forms.TabPage NetworkCommandTab;
        private System.Windows.Forms.RichTextBox NetworkCommandLogs;
        private System.Windows.Forms.TabPage staticStorageTab;
        private System.Windows.Forms.RichTextBox staticStorageLogs;
    }
}