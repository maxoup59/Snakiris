using System;
using System.Windows.Forms;

namespace Snakiris
{

    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

  
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Hide();
            ServerForm serverForm = new ServerForm();
            serverForm.FormClosed += new FormClosedEventHandler(CloseMainForm);
            serverForm.Show();
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            Hide();
            LauncherForm launcherForm = new LauncherForm();
            launcherForm.FormClosed += new FormClosedEventHandler(CloseMainForm);
            launcherForm.Show();
        }
        private void CloseMainForm(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void OpenMainForm(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Hide();
            MapEditor mapEditor = new MapEditor();
            mapEditor.FormClosed += new FormClosedEventHandler(OpenMainForm);
            mapEditor.Show();
        }
    }
}
