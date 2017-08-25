using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Providers
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public Dictionary<string, string> GetServiceConfiguration()
        {
            var serviceConfigurationDictionary = new Dictionary<string, string>();
            serviceConfigurationDictionary.Add("BaseAddress", " https://api-dev.shopbox.com");
            serviceConfigurationDictionary.Add("Accept", "application/json");
          //serviceConfigurationDictionary.Add("ContentType", "application/x-www-form-urlencoded");
            return serviceConfigurationDictionary;
        }
    }
}
