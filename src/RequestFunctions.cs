using System;
using System.IO;
using System.Net.Http;
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
            var getRequest = httpClient.GetAsync("https://api.alexflipnote.dev/" + endpoint, HttpCompletionOption.ResponseContentRead);
            var responseMessage = getRequest.Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var responseString = responseMessage.Content.ReadAsStringAsync().Result;
                var error = (JObject)JsonConvert.DeserializeObject(responseString);
                throw new Exception($"Status {error["code"].Value<int>()}: {error["name"].Value<string>()}. {error["description"].Value<string>()}");
            }

            var stream = responseMessage.Content.ReadAsStreamAsync();
            return (MemoryStream)stream.Result;
        }

        public static JObject MakeWebRequest(string endpoint)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "AlexFlipnote.NET by VAC Efron#0001");
            var responseMessage = httpClient.GetAsync($"https://api.alexflipnote.dev/{endpoint}");
            return (JObject)JsonConvert.DeserializeObject(responseMessage.Result.Content.ReadAsStringAsync().Result);
        }
    }
}