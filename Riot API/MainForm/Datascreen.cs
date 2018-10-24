using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MainForm
{
    public partial class Datascreen : Form
    {
        private Info data;
        private Info summonerData;
        private Info rankedData;
        private Info champData;

        public Datascreen(Info data_, Info summonerdata_)
        {
            data = data_;
            summonerData = summonerdata_;
            InitializeComponent();
            InitializeData();   
        }

        private void InitializeData()
        {
            string url = "http://ddragon.leagueoflegends.com/cdn/6.24.1/img/profileicon/" + summonerData.profileIconId + ".png";
            try {summonerIcon.Load(url);}
            catch (WebException e) { }
            levelLabel.Text = "Level "+ summonerData.summonerLevel.ToString();
            nameLabel.Text = summonerData.name;

            rankedData = new Requester().rankedData(data.Region, summonerData.id.ToString());

            soloLabel.Text = rankedData.tier + " " + rankedData.rank;
            soloLPLabel.Text = rankedData.leaguePoints + " LP";
            soloWinsLabel.Text = rankedData.wins + " W";
            soloLosesLabel.Text = rankedData.losses + " L";
            double wins = rankedData.wins;
            double losses = rankedData.losses;
            double winP = wins / (wins + losses) * 100;
            winP = System.Math.Round(winP, 2);
            soloWinPLabel.Text = winP + "%";

            flexLabel.Text = rankedData.flexQ.tier + " " + rankedData.flexQ.rank;
            flexLPLabel.Text = rankedData.flexQ.leaguePoints + " LP";
            flexWinsLabel.Text = rankedData.flexQ.wins + " W";
            flexLosesLabel.Text = rankedData.flexQ.losses + " L";
            double flexwins = rankedData.flexQ.wins;
            double flexlosses = rankedData.flexQ.losses;
            double flexwinP = flexwins / (flexwins + flexlosses) * 100;
            winP = System.Math.Round(flexwinP, 2);
            flexWinPLabel.Text = winP + "%";

            switch (rankedData.tier)
            {
                case "PROVISIONAL": soloIcon.Image = global::MainForm.Properties.Resources.provisional; break;
                case "BRONZE": soloIcon.Image = global::MainForm.Properties.Resources.bronze; break;
                case "SILVER": soloIcon.Image = global::MainForm.Properties.Resources.silver; break;
                case "GOLD": soloIcon.Image = global::MainForm.Properties.Resources.gold; break;
                case "PLATINUM": soloIcon.Image = global::MainForm.Properties.Resources.platinum; break;
                case "DIAMOND": soloIcon.Image = global::MainForm.Properties.Resources.diamond; break;
                case "MASTER": soloIcon.Image = global::MainForm.Properties.Resources.master; break;
                case "CHALLENGER": soloIcon.Image = global::MainForm.Properties.Resources.challenger; break;
            }
            switch (rankedData.flexQ.tier)
            {
                case "PROVISIONAL": flexIcon.Image = global::MainForm.Properties.Resources.provisional; break;
                case "BRONZE": flexIcon.Image = global::MainForm.Properties.Resources.bronze; break;
                case "SILVER": flexIcon.Image = global::MainForm.Properties.Resources.silver; break;
                case "GOLD": flexIcon.Image = global::MainForm.Properties.Resources.gold; break;
                case "PLATINUM": flexIcon.Image = global::MainForm.Properties.Resources.platinum; break;
                case "DIAMOND": flexIcon.Image = global::MainForm.Properties.Resources.diamond; break;
                case "MASTER": flexIcon.Image = global::MainForm.Properties.Resources.master; break;
                case "CHALLENGER": flexIcon.Image = global::MainForm.Properties.Resources.challenger; break;
            }

            champData = new Requester().champData(data.Region, summonerData.id.ToString());

            masteryLabel.Text = champData.championPoints.ToString();
            champPortrait.ImageLocation = "http://ddragon.leagueoflegends.com/cdn/6.24.1/img/champion/Jhin.png";
        }

        private void soloIcon_Click(object sender, EventArgs e)
        {
            if (soloPanel.Visible)
            {
                soloPanel.Visible = false;
            }
            else
            {
                soloPanel.Visible = true;
            }
        }

        private void flexIcon_Click(object sender, EventArgs e)
        {
            if (flexPanel.Visible)
            {
                flexPanel.Visible = false;
            }
            else
            {
                flexPanel.Visible = true;
            }
        }
    }
}
