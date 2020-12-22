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
                throw new Exception($"Status {(int)error["code"]}: {(string)error["name"]}. {(string)error["description"]}");
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
                throw new Exception($"Status {(int)responseJson["code"]}: {(string)responseJson["name"]}. {(string)responseJson["description"]}");         

            return responseJson;
        }        
    }
}
