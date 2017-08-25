using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using ServiceLayer.RestClient;

namespace ServiceLayer.API
{
    public class ClientServiceCall : IClientServiceCall
    {
        #region Field

        private Dictionary<string, string> _serviceConfiguration;
        private HttpClient _httpClient;
        private GlobalRestClient _globalClient;

        #endregion

        public ClientServiceCall(IServiceConfiguration serviceConfiguration)
        {
            _serviceConfiguration = serviceConfiguration.GetServiceConfiguration();
            _globalClient = new GlobalRestClient(serviceConfiguration);
        }

        public async Task<ClientsRoot> GetAllStores(string accessToken)
        {
            List<KeyValuePair<string, string>> uriParameters = new List<KeyValuePair<string, string>>();
            uriParameters.Add(new KeyValuePair<string, string>("accessToken", accessToken));

            var result = await _globalClient.GetRequest<ClientsRoot>("api/clients", "myclients", uriParameters);
            return result.Value;
        }

        public async Task<BranchesRoot> GetAllCashRegisters(string accessToken,string clientId)
        {
            List<KeyValuePair<string, string>> uriParameters = new List<KeyValuePair<string, string>>();
            uriParameters.Add(new KeyValuePair<string, string>("accessToken", accessToken));
            uriParameters.Add(new KeyValuePair<string, string>("client", clientId));
            var result = await _globalClient.GetRequest<BranchesRoot>("api/v3", "branches", uriParameters);
            return result.Value;
        }

        public async Task<ProductsRoot> GetAllProducts(string accessToken, string clientId)
        {
            List<KeyValuePair<string, string>> uriParameters = new List<KeyValuePair<string, string>>();
            uriParameters.Add(new KeyValuePair<string, string>("accessToken", accessToken));
            uriParameters.Add(new KeyValuePair<string, string>("client",clientId));
            var result = await _globalClient.GetRequest<ProductsRoot>("api", "products", uriParameters);
            return result.Value;
        }
    }
}
