using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;

namespace ServiceLayer.API
{
   public interface IClientServiceCall
   {
       Task<ClientsRoot> GetAllStores(string accessToken);
       Task<BranchesRoot> GetAllCashRegisters(string accessToken,string ClientId);
       Task<ProductsRoot> GetAllProducts(string accessToken, string ClientId);
    }
}
