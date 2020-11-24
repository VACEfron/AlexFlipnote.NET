using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlexFlipnote.NET
{
    internal static class RequestFunctions
    {
        internal static string _token;

        internal static string JsonRequest(string endpoint, string key)
        {
            try
            {
                JObject data = MakeWebRequest(endpoint);

                return data[key].Value<string>();
            }
            catch
            {
                throw;
            }
        }

        internal static JObject JObjectRequest(string endpoint)
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

        internal static MemoryStream ImageRequest(string endpoint)
        {
            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "AlexFlipnote.NET by VAC Efron#0001");
            if (!string.IsNullOrEmpty(_token))
                httpClient.DefaultRequestHeaders.Add("Authorization", _token);

            var getRequest = httpClient.GetAsync("https://api.alexflipnote.dev/" + endpoint, HttpCompletionOption.ResponseContentRead);
            var responseMessage = getRequest.Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var responseString = responseMessage.Content.ReadAsStringAsync().Result;
                JObject error = (JObject)JsonConvert.DeserializeObject(responseString);
                throw new Exception($"Status {error["code"].Value<int>()}: {error["name"].Value<string>()}. {error["description"].Value<string>()}");
            }

            var stream = responseMessage.Content.ReadAsStreamAsync();
            return (MemoryStream)stream.Result;
        }

        internal static JObject MakeWebRequest(string endpoint)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "AlexFlipnote.NET by VAC Efron#0001");
            if (!string.IsNullOrEmpty(_token))
                httpClient.DefaultRequestHeaders.Add("Authorization", _token);

            var getRequest = httpClient.GetAsync("https://api.alexflipnote.dev/" + endpoint);
            var responseMessage = getRequest.Result;
            var responseJson = (JObject)JsonConvert.DeserializeObject(responseMessage.Content.ReadAsStringAsync().Result);

            if (!responseMessage.IsSuccessStatusCode)                            
                throw new Exception($"Status {responseJson["code"].Value<int>()}: {responseJson["name"].Value<string>()}. {responseJson["description"].Value<string>()}");         

            return responseJson;
        }        
    }
}
