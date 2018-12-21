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
            string url = "http://ddragon.leagueoflegends.com/cdn/8.24.1/img/profileicon/" + summonerData.profileIconId + ".png";
            try {summonerIcon.Load(url);}
            catch (WebException e) { }
            levelLabel.Text = "Level "+ summonerData.summonerLevel.ToString();
            nameLabel.Text = summonerData.name;

            rankedData = new Requester().rankedData(data.Region, summonerData.id.ToString());

            soloLabel.Text = rankedData.tier + " " + rankedData.rank;
            soloLPLabel.Text = rankedData.leaguePoints + " LP";
            if(rankedData.leaguePoints == 0)
            {
                this.soloLPLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if(rankedData.leaguePoints == 100)
            {
                this.soloLPLabel.ForeColor = System.Drawing.Color.SpringGreen;
            }
            soloWinsLabel.Text = rankedData.wins + " W";
            soloLosesLabel.Text = rankedData.losses + " L";
            soloDivName.Text = rankedData.leagueName;
            double wins = rankedData.wins;
            double losses = rankedData.losses;
            double winP = wins / (wins + losses) * 100;
            winP = System.Math.Round(winP, 2);
            soloWinPLabel.Text = winP + "%";
            if(winP >= 50)
            {
                this.soloWinPLabel.ForeColor = System.Drawing.Color.SpringGreen;
            }
            else
            {
                this.soloWinPLabel.ForeColor = System.Drawing.Color.Red;
            }

            Console.WriteLine("cunt: "+rankedData.flexQ.leagueName);

            flexLabel.Text = rankedData.flexQ.tier + " " + rankedData.flexQ.rank;
            flexLPLabel.Text = rankedData.flexQ.leaguePoints + " LP";
            if (rankedData.flexQ.leaguePoints == 0)
            {
                this.flexLPLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (rankedData.flexQ.leaguePoints == 100)
            {
                this.flexLPLabel.ForeColor = System.Drawing.Color.SpringGreen;
            }
            flexWinsLabel.Text = rankedData.flexQ.wins + " W";
            flexLosesLabel.Text = rankedData.flexQ.losses + " L";
            flexDivName.Text = rankedData.flexQ.leagueName;
            double flexwins = rankedData.flexQ.wins;
            double flexlosses = rankedData.flexQ.losses;
            double flexwinP = flexwins / (flexwins + flexlosses) * 100;
            winP = System.Math.Round(flexwinP, 2);
            flexWinPLabel.Text = winP + "%";
            if (winP >= 50)
            {
                this.flexWinPLabel.ForeColor = System.Drawing.Color.SpringGreen;
            }
            else
            {
                this.flexWinPLabel.ForeColor = System.Drawing.Color.Red;
            }

            switch (rankedData.tier)
            {
                case "PROVISIONAL": soloIcon.Image = global::MainForm.Properties.Resources.provisional; break;
                case "IRON": soloIcon.Image = global::MainForm.Properties.Resources.iron; break;
                case "BRONZE": soloIcon.Image = global::MainForm.Properties.Resources.bronze; break;
                case "SILVER": soloIcon.Image = global::MainForm.Properties.Resources.silver; break;
                case "GOLD": soloIcon.Image = global::MainForm.Properties.Resources.gold; break;
                case "PLATINUM": soloIcon.Image = global::MainForm.Properties.Resources.platinum; break;
                case "DIAMOND": soloIcon.Image = global::MainForm.Properties.Resources.diamond; break;
                case "MASTER": soloIcon.Image = global::MainForm.Properties.Resources.master; break;
                case "GRANDMASTER": soloIcon.Image = global::MainForm.Properties.Resources.grandmaster; break;
                case "CHALLENGER": soloIcon.Image = global::MainForm.Properties.Resources.challenger; break;
            }
            switch (rankedData.flexQ.tier)
            {
                case "PROVISIONAL": flexIcon.Image = global::MainForm.Properties.Resources.provisional; break;
                case "IRON": flexIcon.Image = global::MainForm.Properties.Resources.iron; break;
                case "BRONZE": flexIcon.Image = global::MainForm.Properties.Resources.bronze; break;
                case "SILVER": flexIcon.Image = global::MainForm.Properties.Resources.silver; break;
                case "GOLD": flexIcon.Image = global::MainForm.Properties.Resources.gold; break;
                case "PLATINUM": flexIcon.Image = global::MainForm.Properties.Resources.platinum; break;
                case "DIAMOND": flexIcon.Image = global::MainForm.Properties.Resources.diamond; break;
                case "MASTER": flexIcon.Image = global::MainForm.Properties.Resources.master; break;
                case "GRANDMASTER": flexIcon.Image = global::MainForm.Properties.Resources.grandmaster; break;
                case "CHALLENGER": flexIcon.Image = global::MainForm.Properties.Resources.challenger; break;
            }

            champData = new Requester().champData(data.Region, summonerData.id.ToString());

            masteryLabel.Text = champData.championPoints.ToString() + "\nMastery Points";
            masteryNameLabel.Text = champData.championName;
           // masteryIcon.ImageLocation = "http://ddragon.leagueoflegends.com/cdn/8.24.1/img/champion/" + champData.championName + ".png";
            championImage.ImageLocation = "http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + champData.championName + "_0.jpg";

            switch(champData.championLevel)
            {             
                case 1: masteryIcon.Image = global::MainForm.Properties.Resources.Champion_Mastery_Level_1; break;
                case 2: masteryIcon.Image = global::MainForm.Properties.Resources.Champion_Mastery_Level_2; break;
                case 3: masteryIcon.Image = global::MainForm.Properties.Resources.Champion_Mastery_Level_3; break;
                case 4: masteryIcon.Image = global::MainForm.Properties.Resources.Champion_Mastery_Level_4; break;
                case 5: masteryIcon.Image = global::MainForm.Properties.Resources.Champion_Mastery_Level_5; break;
                case 6: masteryIcon.Image = global::MainForm.Properties.Resources.Champion_Mastery_Level_6; break;
                case 7: masteryIcon.Image = global::MainForm.Properties.Resources.Champion_Mastery_Level_7; break;
            }
        }

        private void soloIcon_Click(object sender, EventArgs e)
        {
            if (rankedData.wins != 0 && rankedData.losses != 0)
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
        }

        private void flexIcon_Click(object sender, EventArgs e)
        {
            if(rankedData.flexQ.wins != 0 && rankedData.flexQ.losses != 0)
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

        private void soloLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
