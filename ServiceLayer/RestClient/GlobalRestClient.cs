using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace ServiceLayer.RestClient
{
    public class GlobalRestClient
    {
        private Dictionary<string, string> serviceConfiguration;
        private readonly HttpClient _httpClient;

        public GlobalRestClient(IServiceConfiguration _serviceConfiguration)
        {
            serviceConfiguration = _serviceConfiguration?.GetServiceConfiguration();
            _httpClient = new HttpClient(new NativeMessageHandler()) { BaseAddress = new Uri(serviceConfiguration["BaseAddress"]) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(serviceConfiguration["Accept"]));

        }
        #region Methods

        public async Task<GlobalResponse<T>> GetRequest<T>(string controller, string action,
           List<KeyValuePair<string, string>> uriParameters)

        {
            var url = $"/{controller}/{action}?";
            GlobalResponse<T> response=new GlobalResponse<T>();
            try
            {
                
                for (int i = 0; i < uriParameters.Count; i++)
                {
                     url += $"{uriParameters[i].Key}={uriParameters[i].Value}"+"&";
                }
                url = url.Remove(url.Length - 1);
                var result = await _httpClient.GetStringAsync(url);
               
                if (!result.Contains("error"))
                {
                    T bata = JsonConvert.DeserializeObject<T>(result);
                    response.Value = bata;
                }
                else
                {
                    var errorbata = JsonConvert.DeserializeObject<GlobalResponse<T>>(result);
                    response.error = errorbata.error;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public async Task<GlobalResponse<T>> PostRequest<T>(string controller, string action, Object contentObj, params string[] uriParameters)
        {
            try
            {
                string cont = string.Empty;
                GlobalResponse<T> response = new GlobalResponse<T>();

                var url = $"/{controller}/{action}";
                url = uriParameters.Aggregate(url, (current, uriParameter) => current + uriParameter.ToString() + "/");
                cont = JsonConvert.SerializeObject(contentObj);
                var msg = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(cont, Encoding.UTF8, "application/json")
                };

                var responseMessage = await _httpClient.SendAsync(msg);
                string result = await responseMessage.Content.ReadAsStringAsync();
                
                if (!result.Contains("error"))
                {
                    var bata = JsonConvert.DeserializeObject<T>(result);
                    response.Value = bata;
                }
                else
                {
                    var errorbata = JsonConvert.DeserializeObject<GlobalResponse<T>>(result);
                    response.error = errorbata.error;
                }


                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        #endregion
    }
}
