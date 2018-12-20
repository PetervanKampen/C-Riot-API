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
                    flex += array[i];
                }
                else
                {
                    solo += array[i];
                }
                if (array[i].Equals('}'))
                {
                    secondstring = true;
                    Console.WriteLine("test");
                    i++;
                }
            }

            Info rankedData = new Info();
            try
            {
                Console.WriteLine("a");
                Console.WriteLine("solo: " + solo);
                rankedData = JsonConvert.DeserializeObject<Info>(solo);
                Console.WriteLine("b");
                rankedData.flexQ = JsonConvert.DeserializeObject<Flex>(flex);
                Console.WriteLine("c");
            }
            catch(JsonReaderException e)
            {
                Console.WriteLine("FUCK " + e.Message);
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
            Console.WriteLine("champ info: " + newinfo);
            Info champData = new Info();
            champData = JsonConvert.DeserializeObject<Info>(newinfo);
            champData.championName = new ChampionID().IDtoName(champData.championId);
            return champData;
        }

    }
}
