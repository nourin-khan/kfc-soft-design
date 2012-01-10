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


namespace KitchenGUI
{
    public partial class ConfigureForm : Form
    {
        private string imageFolder;
        private string serviceAddress;

        public ConfigureForm()
        {
            InitializeComponent();
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
                // if don't have any exception throws => service is available
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
            // set service address
            KitchenController.ConfigurationCTL.ServiceAddress = serviceAddress;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
