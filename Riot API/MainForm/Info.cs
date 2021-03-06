﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MainForm
{
    public class Info
    {
        public string Summonername { get; set; }
        public string Region { get; set; }

        //summoner JSON
        public string name { get; set; }
        public long summonerLevel { get; set; }
        public long revisionDate { get; set; }
        public long id { get; set; }
        public long accountid { get; set; }
        public int profileIconId { get; set; }

        //ranked Json
        public string leagueName { get; set; }
        public string tier { get; set; }
        public string queueType { get; set; }
        public string rank { get; set; }
        public int leaguePoints { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public JsonArrayAttribute miniSeries { get; set; }

        //ranked Flex class
        public Flex flexQ = new Flex();

        //champion mastery JSON
        public int championLevel { get; set; }
        public int championPoints { get; set; }
        public long championId { get; set; }

        public string championName { get; set; }

    }
}
