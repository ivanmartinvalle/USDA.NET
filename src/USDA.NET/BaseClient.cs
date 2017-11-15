using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace USDA.NET
{
    public class BaseClient : IDisposable
    {
        protected readonly HttpClient HTTPClient;
        protected List<KeyValuePair<string, string>> ParameterDictionary { get; set; } = new List<KeyValuePair<string, string>>();

        protected BaseClient(string apiKey)
        {
            HTTPClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.nal.usda.gov")
            };

            ParameterDictionary.Add(new KeyValuePair<string, string>("format", "json"));
            ParameterDictionary.Add(new KeyValuePair<string, string>("api_key", apiKey));
        }

        public void Dispose()
        {
            HTTPClient?.Dispose();
        }
    }
}
