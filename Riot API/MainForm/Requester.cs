using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MainForm
{
    class Requester
    {
        private string key = "RGAPI-19330a3c-af0b-4b55-9724-cdf6e87a39af";

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
            Console.WriteLine("Flex: " + flex);
            Console.WriteLine("Solo: " + solo);

            Info rankedData = new Info();
            try
            {
                rankedData = JsonConvert.DeserializeObject<Info>(solo);
                rankedData.flexQ = JsonConvert.DeserializeObject<Flex>(flex);
            }
            catch(JsonReaderException e)
            {
                Console.WriteLine("FUCK");
            }
            return rankedData;
        }
    }
}
