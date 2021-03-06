using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MainForm
{
    class Requester
    {
        private string key = "";

        public Info summonerData(string region, string name)
        {
            string info = "";
            try
            {               
                string url = "https://" + region + ".api.riotgames.com/lol/summoner/v3/summoners/by-name/" + name + "?api_key=" + key;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    info = reader.ReadToEnd();
                }         
            }
            catch(WebException e)
            {
                Console.WriteLine("404");
            }
            Info summonerData = new Info();
            summonerData = JsonConvert.DeserializeObject<Info>(info);
            return summonerData;
        }

        public Info rankedData(string region, string summonerid)
        {
            string info = "";
            try
            {
                string url = "https://" + region + ".api.riotgames.com/lol/league/v3/positions/by-summoner/" + summonerid + "?api_key=" + key;
                Console.WriteLine(url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    info = reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("404");
            }

            Console.WriteLine(info);

            string solo = "";
            string flex = "";
            bool secondstring = false;
            for (int i = 1; i<info.Length; i++)
            {             
                char[] array = info.ToCharArray();
                if(!secondstring)
                {
                    solo += array[i];
                }
                else
                {
                    flex += array[i];
                }
                if (array[i].Equals('}'))
                {
                    secondstring = true;
                    i++;
                }
            }

            Console.WriteLine("Flex TT info: " + flex);

            if(flex.Contains("RANKED_FLEX_TT"))
            {
                string flexholder = flex;
                string tt = "{";
                flex = "{";
                bool secondstring2 = false;
                for (int i = 1; i < flexholder.Length; i++)
                {
                    char[] array = flexholder.ToCharArray();
                    if (!secondstring2)
                    {
                        tt += array[i];
                    }
                    else
                    {
                        flex += array[i];
                    }
                    if (array[i].Equals('}'))
                    {
                        secondstring2 = true;
                        i++;
                    }
                }
                if (flex.Contains("RANKED_FLEX_TT"))
                {
                    string temp = tt;
                    tt = flex;
                    flex = temp;
                }
            }
            else if (solo.Contains("RANKED_FLEX_TT"))
            {
                string soloholder = solo;
                string tt = "{";
                solo = "{";
                bool secondstring2 = false;
                for (int i = 1; i < soloholder.Length; i++)
                {
                    char[] array = soloholder.ToCharArray();
                    if (!secondstring2)
                    {
                        solo += array[i];
                    }
                    else
                    {
                        tt += array[i];
                    }
                    if (array[i].Equals('}'))
                    {
                        secondstring2 = true;
                        i++;
                    }
                }
                if (solo.Contains("RANKED_FLEX_TT"))
                {
                    string temp = tt;
                    tt = solo;
                    solo = temp;
                }
            }

            Console.WriteLine("solo: " + solo + "\nflex: " + flex);

            if(solo.Contains("RANKED_FLEX_SR") || flex.Contains("RANKED_SOLO_5x5"))
            {
                string temp = solo;
                solo = flex;
                flex = temp;
            }

            Info rankedData = new Info();

            try
            {
                if (solo == "")
                {
                    solo = "{\"leagueId\":\"\",\"leagueName\":\"\",\"tier\":\"PROVISIONAL\",\"queueType\":\"RANKED_SOLO_5x5\",\"rank\":\"\",\"playerOrTeamId\":\"\",\"playerOrTeamName\":\"\",\"leaguePoints\":0,\"wins\":0,\"losses\":0}";
                    rankedData = JsonConvert.DeserializeObject<Info>(solo);
                }
                else
                {
                    rankedData = JsonConvert.DeserializeObject<Info>(solo);
                }
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine("FUCK solo" + e.Message);
            }

            try
            {           
                if (flex == "")
                {
                    flex = "{\"leagueId\":\"\",\"leagueName\":\"\",\"tier\":\"PROVISIONAL\",\"queueType\":\"RANKED_FLEX_SR\",\"rank\":\"\",\"playerOrTeamId\":\"\",\"playerOrTeamName\":\"\",\"leaguePoints\":0,\"wins\":0,\"losses\":0}";
                    rankedData.flexQ = JsonConvert.DeserializeObject<Flex>(flex);
                }
                else
                {
                    rankedData.flexQ = JsonConvert.DeserializeObject<Flex>(flex);
                }               
            }
            catch(JsonReaderException e)
            {
                Console.WriteLine("FUCK flex" + e.Message);
            }
            return rankedData;
        }

        public Info champData(string region, string summonerid)
        {
            char[] info = new char[300];
            try
            {
                string url = "https://" + region + ".api.riotgames.com/lol/champion-mastery/v3/champion-masteries/by-summoner/" + summonerid + "?api_key=" + key;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    reader.ReadBlock(info, 0, 300);
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("404");
            }
            
            bool delete = false;
            string newinfo = "";
            for(int i = 1; i<300; i++)
            {             
                if(!delete)
                {
                    newinfo += info[i];
                }
                if (info[i].Equals('}'))
                {
                    delete = true;
                }
            }
            Info champData = new Info();
            champData = JsonConvert.DeserializeObject<Info>(newinfo);
            champData.championName = new ChampionID().IDtoName(champData.championId);
            return champData;
        }

    }
}
