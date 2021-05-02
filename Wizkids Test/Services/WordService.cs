using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wizkids_Test.Entities;
using System.Net.Http.Headers;
using Wizkids_Test.Services.Authentication;
using Newtonsoft.Json;
using Wizkids_Test.Entities.WebService;

namespace Wizkids_Test.Services
{
    public class WordService
    {
        public WordService(IAuthenticationStrategy authenticationStrategy, string endpoint)
        {
            AuthenticationStrategy = authenticationStrategy;
            Endpoint = new Uri(endpoint);
            _client = new HttpClient();
        }
        public IAuthenticationStrategy AuthenticationStrategy { get; set; }
        public Uri Endpoint { get; set; }
        private HttpClient _client;
        public async Task<IEnumerable<IWord>> GetAsync(string partial, string locale = "en-GB")
        {
            var targetUri = GetUriWithParameters(partial, locale);
            _client.DefaultRequestHeaders.Authorization = AuthenticationStrategy.GetAuthenticationMethod();


            var response = await _client.GetAsync(targetUri);

            var results = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
            var outputList = new List<IWord>();
            foreach (var result in results)
            {
                var word = new Word() { Locale = locale, Value = result };
                outputList.Add(word);
            }

            return outputList;
        }
        private Uri GetUriWithParameters(string partial, string locale)
        {
            var baseEndpoint = Endpoint;
            UriBuilder builder = new UriBuilder();
            builder.Path = baseEndpoint.AbsolutePath;
            builder.Host = Endpoint.Host;
            var queryParams = $"locale={locale}&text={partial}";
            builder.Query = queryParams;
            return builder.Uri;
        }
    }
}
