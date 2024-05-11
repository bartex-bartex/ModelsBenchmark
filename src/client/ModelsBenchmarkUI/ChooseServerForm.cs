using ModelsBenchmarkLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelsBenchmarkUI
{
    public partial class ChooseServerForm : Form
    {
        public ChooseServerForm()
        {
            InitializeComponent();

            serverComboBox.DataSource = GlobalConfig.AvailableApiUrls;
        }

        private void selectServerBtn_Click(object sender, EventArgs e)
        {
            string serverUrl = serverComboBox.Text;

            // TODO - validate serverUrl

            GlobalConfig.SetupDefaultServer(serverUrl);

            this.Close();
        }
    }
}
