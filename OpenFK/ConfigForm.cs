using System;
using System.Windows.Forms;

namespace OpenFK
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            customFtoggle.Checked = Properties.Settings.Default.customF;
            RPCToggle.Checked = Properties.Settings.Default.RPC;
            rdfToggle.Checked = Properties.Settings.Default.RDF;
            QualityCB.SelectedIndex = Properties.Settings.Default.Quality;
            ScaleCB.SelectedIndex = Properties.Settings.Default.ScaleMode;
            USBToggle.Checked = Properties.Settings.Default.USBSupport;
            OnlineToggle.Checked = Properties.Settings.Default.IsOnline;
            HTTPBox1.Text = Properties.Settings.Default.HTTPHost1;
            HTTPBox2.Text = Properties.Settings.Default.HTTPHost2;
            TCPHostBox.Text = Properties.Settings.Default.TCPHost;
            TCPPortBox.Text = Properties.Settings.Default.TCPPort;
            string currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            label8.Text = "OpenFK v" + currentVersion.Substring(0, currentVersion.LastIndexOf("."));
            UpdateTextboxes();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Quality = QualityCB.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ScaleMode = ScaleCB.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (customFtoggle.Checked)
            {
                Properties.Settings.Default.customF = true;
            }
            else
                Properties.Settings.Default.customF = false;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (RPCToggle.Checked)
            {
                Properties.Settings.Default.RPC = true;
            }
            else
                Properties.Settings.Default.RPC = false;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HTTPHost1 = HTTPBox1.Text;
            Properties.Settings.Default.HTTPHost2 = HTTPBox2.Text;
            Properties.Settings.Default.TCPHost = TCPHostBox.Text;
            Properties.Settings.Default.TCPPort = TCPPortBox.Text;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void rdfToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdfToggle.Checked)
            {
                Properties.Settings.Default.RDF = true;
            }
            else
                Properties.Settings.Default.RDF = false;
            Properties.Settings.Default.Save();
        }

        private void USBToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (USBToggle.Checked)
            {
                Properties.Settings.Default.USBSupport = true;
            }
            else
                Properties.Settings.Default.USBSupport = false;
            Properties.Settings.Default.Save();
        }

        private void OnlineToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (OnlineToggle.Checked)
            {
                Properties.Settings.Default.IsOnline = true;
            }
            else
                Properties.Settings.Default.IsOnline = false;
            Properties.Settings.Default.Save();
            UpdateTextboxes();
        }

        void UpdateTextboxes()
        {
            if (Properties.Settings.Default.IsOnline)
            {
                HTTPBox1.Enabled = true;
                HTTPBox2.Enabled = true;
                TCPHostBox.Enabled = true;
                TCPPortBox.Enabled = true;
            }
            else
            {
                HTTPBox1.Enabled = false;
                HTTPBox2.Enabled = false;
                TCPHostBox.Enabled = false;
                TCPPortBox.Enabled = false;
            }
        }
    }
}
