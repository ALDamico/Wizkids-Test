using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Wizkids_Test.Services.Authentication
{
    public class BearerTokenAuthenticationStrategy : IAuthenticationStrategy
    {
        public BearerTokenAuthenticationStrategy(AuthenticationInfo authenticationInfo)
        {
            AuthenticationInfo = authenticationInfo;
        }
        public AuthenticationInfo AuthenticationInfo { get; }

        public AuthenticationHeaderValue GetAuthenticationMethod()
        {
            return new AuthenticationHeaderValue("Bearer", AuthenticationInfo.Token);
        }
    }
}
