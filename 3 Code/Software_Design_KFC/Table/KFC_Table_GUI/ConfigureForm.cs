using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace KFC_Table_GUI
{
    public partial class ConfigureForm : Form
    {
        private string imageFolder;
        private string serviceAddress;

        public ConfigureForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtImageFolder.Text = dlg.SelectedPath;
                imageFolder = dlg.SelectedPath;
            }
        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnDisconnect_Click(sender, e);
            this.Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            serviceAddress = txtAddress.Text;
            try
            {
                MetadataExchangeClient mexClient = new MetadataExchangeClient(new Uri(serviceAddress), MetadataExchangeClientMode.HttpGet);
                MetadataSet metadata = mexClient.GetMetadata();
                textBoxAddress.Text = serviceAddress;
                textBoxStatus.Text = "Available";
                textBoxStatus.BackColor = Color.PaleGreen;
            }
            catch (System.Exception ex)
            {
                textBoxStatus.Text = "Note available";
                textBoxStatus.BackColor = Color.LightPink;
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableNum.Text))
            {
                MessageBox.Show("Bạn phải cấu hình số thứ tự của bàn ăn !", "Error");
                return;
            }
            // set table number
            TableController.ConfigurationCTL.TableNum = int.Parse(txtTableNum.Text);
            // set images path
            TableController.ConfigurationCTL.ImagesFolder = imageFolder;
            // set service address
            TableController.ConfigurationCTL.ServiceAddress = serviceAddress;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
