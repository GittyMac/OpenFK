using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
