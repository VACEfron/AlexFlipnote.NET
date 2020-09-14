using System;
using System.IO;
using System.Net.Http;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            catch
            {
                throw;
            }
        }

        public static JObject JObjectRequest(string endpoint)
        {
            try
            {
                return MakeWebRequest(endpoint);
            }
            catch
            {
                throw;
            }
        }

        public static MemoryStream ImageRequest(string endpoint)
        {
            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "AlexFlipnote.NET by VAC Efron#0001");
            var response = httpClient.GetAsync("https://api.alexflipnote.dev/" + endpoint,
                HttpCompletionOption.ResponseContentRead);
            var responseMessage = response.Result;
            if (!responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result);
                var responseText = htmlDoc.DocumentNode.LastChild.InnerText.Replace("\n","");
                throw new Exception($"Status {(int)responseMessage.StatusCode}: {responseText}");
            }
            
            var stream = responseMessage.Content.ReadAsStreamAsync();
            return (MemoryStream) stream.Result;
        }

        public static JObject MakeWebRequest(string endpoint)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "AlexFlipnote.NET by VAC Efron#0001");
            var httpResponseMsg = httpClient.GetAsync($"https://api.alexflipnote.dev/{endpoint}");
            return (JObject) JsonConvert.DeserializeObject(httpResponseMsg.Result.Content.ReadAsStringAsync().Result);
        }
    }
}