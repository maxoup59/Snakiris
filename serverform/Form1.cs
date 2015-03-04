using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;
// fourni les méthodes pour décrire les comportements de service

namespace Snakiris
{
    public partial class ServerForm : Form
    {
        IServiceServeur proxy = null;
        List<string> ListeMaps;
        HoteServiceSAOP hoteserviceSAOP = new HoteServiceSAOP();
        HoteServiceREST hoteserviceREST = new HoteServiceREST();
        ClientForm clientForm;

        public ServerForm()
        {
            ListeMaps = new List<string>();
            InitializeComponent();
            InitialisationComboxBox();
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            textBoxName.Enabled = false;
            this.numericUpDownBotCount.Enabled = false;
            this.numericUpDownFruitCount.Enabled = false;
            this.numericUpDownInitialSize.Enabled = false;
            this.numericUpDownPlayerCount.Enabled = false;
            this.comboBoxMaps.Enabled = false;
            this.buttonStartServer.Enabled = false;
            this.buttonStopServer.Enabled = true;
            hoteserviceSAOP.Start("Maps/"+comboBoxMaps.Text,
                    Convert.ToInt32(numericUpDownPlayerCount.Value),
                    Convert.ToInt32(numericUpDownFruitCount.Value),
                    Convert.ToInt32(numericUpDownBotCount.Value),
                    Convert.ToInt32(numericUpDownInitialSize.Value));
            hoteserviceREST.Start();
            string adresse = "http://localhost/Snakiris/ServiceServeur";
            EndpointAddress endpointAdress = new EndpointAddress(adresse);
            proxy = ChannelFactory<IServiceServeur>.CreateChannel(new BasicHttpBinding(), endpointAdress);
            clientForm = new ClientForm(proxy,textBoxName.Text);
            clientForm.Show();
        }

        private void InitialisationComboxBox()
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo("Maps/");
            foreach (System.IO.FileInfo fichier in directory.GetFiles())
            {
                bool add = true;
                for (int i = 0; i < ListeMaps.Count; i++)
                {
                    if (ListeMaps[i] == fichier.Name)
                        add = false;
                }
                if (add)
                {
                    this.comboBoxMaps.Items.AddRange(new object[] { fichier });
                    ListeMaps.Add(fichier.Name);
                }
            }
            this.comboBoxMaps.SelectedIndex = 0;
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            clientForm.Close();
            hoteserviceSAOP.Stop();
            hoteserviceREST.Stop();
            this.numericUpDownBotCount.Enabled = true;
            this.numericUpDownFruitCount.Enabled = true;
            this.numericUpDownInitialSize.Enabled = true;
            this.numericUpDownPlayerCount.Enabled = true;
            this.comboBoxMaps.Enabled = true;
            this.buttonStartServer.Enabled = true;
            this.buttonStopServer.Enabled = false;
            this.textBoxName.Enabled = true;
            this.labelName.Enabled = true;
        }
    }
}
