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
    public class LoginServiceCall : ILoginServiceCall
    {
        #region Filed

        private Dictionary<string, string> _serviceConfiguration;
        private HttpClient _httpClient;
        private GlobalRestClient _globalClient;

        #endregion
        #region constructor
        public LoginServiceCall(IServiceConfiguration serviceConfiguration)
        {
            _serviceConfiguration = serviceConfiguration.GetServiceConfiguration();
            _globalClient = new GlobalRestClient(serviceConfiguration);
        }
        #endregion
#region Method
        public async Task<User> Authenticate(string username, string password)
        {
           UserPostData postdata=new UserPostData
           {
               username = username,
               password = password
           };
            try
            {
                var result = await _globalClient.PostRequest<User>("api/v3/authenticate", "credentials", postdata);
                if(result.error==null)
                   return result.Value;
                else
                {
                    throw new Exception(result?.error?.message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }
#endregion
    }
}
