using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Wizkids_Test.Services.Authentication
{
    public interface IAuthenticationStrategy
    {
        AuthenticationInfo AuthenticationInfo { get; }
        AuthenticationHeaderValue GetAuthenticationMethod();
    }
}
