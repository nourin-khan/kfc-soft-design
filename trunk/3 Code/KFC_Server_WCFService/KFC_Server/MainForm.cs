using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using ServiceLibrary;

namespace KFC_Server
{
    public partial class MainForm : Form
    {
        private string dabaseFile;
        //const string ServiceAddress = "net.tcp://localhost:{0}/KFCServer/";
        const string ServiceAddress = "http://localhost:{0}/KFC_Server/ServiceLibrary/Service/";
        string address;

        const int KfcDictSize = 10;

        class ServerStatus
        {
            public const string Stopped = "Stopped";
            public const string Running = "Running";
        }

        Dictionary<string, ThreadServiceHost<Service, IService>> _kfcDict;

        public MainForm()
        {
            InitializeComponent();
            _kfcDict = new Dictionary<string, ThreadServiceHost<Service, IService>>(KfcDictSize);            
            btnStop.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // stop services
            btnStop_Click(sender, e);
            // exit
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFile.Text.Trim()))
            {
                MessageBox.Show("Please select a database file !", "Error");
                return;
            }

            try
            {
                address = txtAddress.Text;
                string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + dabaseFile + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
                ServiceLibrary.Properties.ConnectionSettings.ConnectionString = connectionString;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
                return;
            }
            StartKFCServer();
            btnStop.Enabled = true;
        }

        private void StartKFCServer()
        {
            try
            {
                string serviceAddr = string.Format(ServiceAddress, address);
                // Create the host
                ThreadServiceHost<Service, IService> kfcHost = new ThreadServiceHost<Service, IService>(serviceAddr, address, new WSHttpBinding());

                // add to dictionary of servers
                _kfcDict.Add(address, kfcHost);

                textBoxAddress.Text = serviceAddr;
                textBoxStatus.Text = ServerStatus.Running;
                textBoxStatus.BackColor = Color.PaleGreen;
                btnStart.Enabled = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL Database File|*.mdf";
            dlg.Title = "Choose KFC database file";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dabaseFile = dlg.FileName;
                txtFile.Text = dabaseFile;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_kfcDict.Count > 0)
                {
                    _kfcDict[address].Stop();

                    // remove from dictionary servers
                    _kfcDict.Remove(address);

                    // set status
                    textBoxAddress.Text = string.Empty;
                    textBoxStatus.Text = ServerStatus.Stopped;
                    textBoxStatus.BackColor = Color.LightPink;
                    btnStop.Enabled = false;
                    btnStart.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}
