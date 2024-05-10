using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ModelsBenchmarkLibrary.Api
{
    public class ApiProcessor
    {
        public static async Task<List<string>> LoadAvailableModels()
        {
            string url = $"{GlobalConfig.ApiUrl}/models";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    JArray obj = await response.Content.ReadAsAsync<JArray>();

                    return obj.ToObject<List<string>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Dictionary<string, List<string>>> LoadModelParameters(string model)
        {
            string url = $"{GlobalConfig.ApiUrl}/models/{model}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Dictionary<string, List<string>> output = new();

                    JObject obj = await response.Content.ReadAsAsync<JObject>();
                    foreach (var item in obj.Properties())
                    {
                        output.Add(item.Name, item.Value.ToObject<List<string>>());
                    }

                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> BenchmarkModel(string model, Dictionary<string, string> parameters)
        {
            string url = $"{GlobalConfig.ApiUrl}/models/{model}/benchmark";

            var content = new StringContent(
                        JsonConvert.SerializeObject(parameters),
                        Encoding.UTF8,
                        MediaTypeNames.Application.Json);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = content
            };

            var response = await ApiHelper.ApiClient.SendAsync(request)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            return responseBody;
        }
    }
}
