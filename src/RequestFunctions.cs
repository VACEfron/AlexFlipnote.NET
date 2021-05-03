using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlexFlipnote.NET
{
    internal static class RequestFunctions
    {
        internal static async Task<string> JsonRequest(string endpoint, string key, string token)
        {
            try
            {
                return (string)(await MakeWebRequest(endpoint, token))[key];
            }
            catch
            {
                throw;
            }
        }

        internal static async Task<JObject> JObjectRequest(string endpoint, string token)
        {
            try
            {
                return await MakeWebRequest(endpoint, token);
            }
            catch
            {
                throw;
            }
        }

        internal static async Task<MemoryStream> ImageRequest(string endpoint, string token)
        {
            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "AlexFlipnote.NET by VAC Efron#0001");

            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Add("Authorization", token);

            var responseMessage = await httpClient.GetAsync("https://api.alexflipnote.dev/" + endpoint, HttpCompletionOption.ResponseContentRead);

            if (!responseMessage.IsSuccessStatusCode)
            {
                JObject error = (JObject)JsonConvert.DeserializeObject(await responseMessage.Content.ReadAsStringAsync());
                throw new Exception($"Status {(int)error["code"]}: {(string)error["name"]}. {(string)error["description"]}");
            }

            return (MemoryStream)await responseMessage.Content.ReadAsStreamAsync();
        }

        internal static async Task<JObject> MakeWebRequest(string endpoint, string token)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "AlexFlipnote.NET by VAC Efron#0011");

            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Add("Authorization", token);

            var responseMessage = await httpClient.GetAsync("https://api.alexflipnote.dev/" + endpoint);
            var responseJson = (JObject)JsonConvert.DeserializeObject(await responseMessage.Content.ReadAsStringAsync());

            if (!responseMessage.IsSuccessStatusCode)                            
                throw new Exception($"Status {(int)responseJson["code"]}: {(string)responseJson["name"]}. {(string)responseJson["description"]}");         

            return responseJson;
        }        
    }
}
