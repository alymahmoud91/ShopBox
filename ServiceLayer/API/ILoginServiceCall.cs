using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;

namespace ServiceLayer.API
{
    public interface ILoginServiceCall
    {
        Task<User> Authenticate(string username, string password);

    }
}
