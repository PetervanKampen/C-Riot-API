using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Mainscreen : Form
    {
        private Info data;
        private Info summonerData;

        public Mainscreen(Info data_)
        {
            data = data_;
            InitializeComponent();
        }

        private void proceedButton_Click(object sender, EventArgs e)
        {
            if(nameInput.Text != "" && regionDropdown.Text != "")
            {
                data.Summonername = nameInput.Text;
                if(regionDropdown.Text == "EUW")
                {
                    data.Region = "euw1";
                }
                else if(regionDropdown.Text == "NA")
                {
                    data.Region = "na1";
                }

                summonerData = new Requester().summonerData(data.Region, data.Summonername);

                new Datascreen(data, summonerData).ShowDialog();
                this.Visible = false;
                this.Close();
            }
        }
    }
}
