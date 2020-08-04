using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace AlexFlipnote.NET
{
    public static class RequestFunctions
    {        
        public static string JsonRequest(string endpoint, string jsonObject)
        {
            try
            {
                JObject data = MakeWebRequest(endpoint);

                return data[jsonObject].Value<string>();
            }
            catch { throw; }            
        }

        public static JObject JObjectRequest(string endpoint)
        {
            try
            {
                return MakeWebRequest(endpoint);
            }
            catch { throw; }
        }

        public static MemoryStream ImageRequest(string endpoint)
        {
            try
            {
                using WebClient webClient = new WebClient();
                
                byte[] byteArray = webClient.DownloadData($"https://api.alexflipnote.dev/{endpoint}");
                return new MemoryStream(byteArray);          
            }
            catch { throw; }            
        }

        public static JObject MakeWebRequest(string endpoint)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.alexflipnote.dev/{endpoint}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return (JObject)JsonConvert.DeserializeObject(responseString);
        }
    }
}
