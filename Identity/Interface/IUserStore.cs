using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Models;

namespace Identity.Interface
{
    public interface IUserStore
    {
       
        public Users ValidateCredentials(string username, string password);
    }
}
