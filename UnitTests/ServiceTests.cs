using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Threading.Tasks;
using Wizkids_Test.Services;
using Wizkids_Test.Services.Authentication;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public async Task TestGet()
        {
            var endpoint = "https://services.lingapps.dk/misc/getPredictions";
            var bearerToken = ConfigurationManager.AppSettings.Get("BearerToken");
            var authenticationInfo = new AuthenticationInfo { Token = bearerToken };
            var authenticationStrategy = new BearerTokenAuthenticationStrategy(authenticationInfo);
            var client = new WordService(authenticationStrategy, endpoint);
            var result = await client.GetAsync("name");
            Assert.IsTrue(result.Count() == 11);
        }
    }
}
