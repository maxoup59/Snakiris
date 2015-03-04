using System;
using System.Windows.Forms;

namespace Snakiris
{
    public partial class ServerChoice : Form
    {
        LauncherForm parent;
        public ServerChoice(LauncherForm parent = null)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public void AddAddress(string adresse)
        {
            listBox1.Items.Add(adresse);
            listBox1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.parent.setIPServer(listBox1.SelectedItem.ToString());
            Close();
        }
    }
}
