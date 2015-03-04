using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.Windows.Forms;

namespace Snakiris
{
    public partial class LauncherForm : Form
    {
        IServiceServeur proxy;
        byte[] myb = new byte[] { 0x41, 0x42, 0x43, 0x41, 0x42, 0x43 };
        List<Ping> ListeOrdi = new List<Ping>();
        int nbTest = 256;
        ServerChoice serverChoix;
        public LauncherForm()
        {
            InitializeComponent();

        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            string ip = textBoxIPServer.Text;
            string adresse = "http://" + ip + ":80/Snakiris/ServiceServeur";
            EndpointAddress endpointAdress = new EndpointAddress(adresse);
            proxy = ChannelFactory<IServiceServeur>.CreateChannel(new BasicHttpBinding(), endpointAdress);
            try
            {
                proxy.isAccessible();
                ClientForm clientForm = new ClientForm(proxy, textBoxName.Text);
                clientForm.Show();
            }
            catch
            {
                MessageBox.Show("Pas de serveur accessible à cette adresse !");
            }
        }

        private void buttonFindServer_Click(object sender, EventArgs e)
        {
            string addresse = getMyIP();
            int stop = 0;
            if (addresse != "FALSE")
            {
                for (int i = 0; i < addresse.Length; i++)
                {
                    if (addresse[i] == '.')
                        stop = i;
                }
            }
            addresse = addresse.Substring(0, stop + 1);
            for (int i = 0; i < nbTest; i++)
            {
                ListeOrdi.Add(new Ping());
                ListeOrdi[i].PingCompleted += new PingCompletedEventHandler(pi_PingCompleted);
                ListeOrdi[i].SendAsync(addresse + i.ToString(), 150, myb, i);
            }
            serverChoix = new ServerChoice(this);
            serverChoix.Show();
        }
        string getMyIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            foreach (IPAddress item in addr)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return item.ToString();
            }
            return "FALSE";
        }
        void pi_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            PingReply reply = e.Reply;
            string ip = e.Reply.Address.ToString();
            if (ip != "0.0.0.0")
            {
                string adresse = "http://" + ip + ":80/Snakiris/ServiceServeur";
                EndpointAddress endpointAdress = new EndpointAddress(adresse);
                proxy = ChannelFactory<IServiceServeur>.CreateChannel(new BasicHttpBinding(), endpointAdress);
                try
                {
                    proxy.isAccessible();
                    serverChoix.AddAddress(ip);
                }
                catch
                {
                }
            }
        }

        public void setIPServer(string IP)
        {
            textBoxIPServer.Text = IP;
        }

    }
}
