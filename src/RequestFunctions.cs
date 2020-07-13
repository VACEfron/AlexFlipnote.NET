using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System;

namespace AlexFlipnote.NET
{
    public static class RequestFunctions
    {
        public static string JsonRequest(string Endpoint, string JsonObject)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"https://api.alexflipnote.dev/{Endpoint}");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var data = (JObject)JsonConvert.DeserializeObject(responseString);

                return data[JsonObject].Value<string>();
            }
            catch(Exception e) { throw e; }            
        }

        public static JObject JObjectRequest(string Endpoint)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"https://api.alexflipnote.dev/{Endpoint}");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return (JObject)JsonConvert.DeserializeObject(responseString);
            }
            catch (Exception e) { throw e; }
        }

        public static MemoryStream ImageRequest(string Endpoint)
        {
            try
            {
                using (WebClient WebClient = new WebClient())
                {
                    byte[] Byte = WebClient.DownloadData($"https://api.alexflipnote.dev/{Endpoint}");
                    return new MemoryStream(Byte);
                }

            }
            catch (Exception e) { throw e; }            
        }
    }
}
