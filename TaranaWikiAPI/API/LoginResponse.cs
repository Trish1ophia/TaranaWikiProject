using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaranaWikiApi;

namespace TaranaWikiAPI.API
{
    public class LoginResponse
    {
        public Login Login { get; set; }
    }

    public class Login
    {
        public string Token { get; set; }
    }
}
