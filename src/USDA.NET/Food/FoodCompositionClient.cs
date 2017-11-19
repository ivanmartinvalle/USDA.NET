using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using USDA.NET.Extensions;
using USDA.NET.Food.Report;
using USDA.NET.Food.Search;

namespace USDA.NET.Food
{
    [UsedImplicitly]
    public class FoodCompositionClient : IDisposable
    {
        private static readonly Uri SearchApi = new Uri("/ndb/search/", UriKind.Relative);
        private static readonly Uri ReportApi = new Uri("/ndb/V2/reports", UriKind.Relative);

        protected readonly HttpClient HTTPClient;
        protected List<KeyValuePair<string, string>> ParameterDictionary { get; set; } = new List<KeyValuePair<string, string>>();

        public FoodCompositionClient(string apiKey)
        {
            HTTPClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.nal.usda.gov")
            };

            ParameterDictionary.Add(new KeyValuePair<string, string>("format", "json"));
            ParameterDictionary.Add(new KeyValuePair<string, string>("api_key", apiKey));
        }

        [Pure]
        [UsedImplicitly]
        public async Task<Result> ReportAsync(ReportOptions reportOptions)
        {
            if (!reportOptions.NDBNumbers.Any()) throw new ArgumentException("NDB Numbers must have a least on item.", nameof(reportOptions.NDBNumbers));
            if (reportOptions.NDBNumbers.Count > 50) throw new ArgumentException("Max number of NDB Numbers is 50.", nameof(reportOptions.NDBNumbers));

            foreach (var ndbNumber in reportOptions.NDBNumbers)
            {
                // ReSharper disable once StringLiteralTypo
                ParameterDictionary.Add(new KeyValuePair<string, string>("ndbno", ndbNumber));
            }

            ParameterDictionary.Add(new KeyValuePair<string, string>("type", reportOptions.Type.ToDescription()));
            
            var requestUri = new Uri($"{ReportApi}?{ParameterDictionary.FlattenQueryString()}", UriKind.Relative);

            var result = await HTTPClient.GetAsync(requestUri);
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return Result.FromJson(json);
        }

        [Pure]
        [UsedImplicitly]
        public async Task<SearchResult> SearchAsync(SearchOptions searchOptions, PaginationOptions pagingOptions = null)
        {
            if (pagingOptions == null) pagingOptions = new PaginationOptions();
            
            ParameterDictionary.Add(new KeyValuePair<string, string>("q", searchOptions.SearchTerm));
            ParameterDictionary.Add(new KeyValuePair<string, string>("ds", searchOptions.DataSource));
            ParameterDictionary.Add(new KeyValuePair<string, string>("fg", searchOptions.FoodGroupId));
            ParameterDictionary.Add(new KeyValuePair<string, string>("sort", pagingOptions.Sort));

            if (pagingOptions.Max != 0)
            {
                ParameterDictionary.Add(new KeyValuePair<string, string>("max", pagingOptions.Max.ToString()));
            }
            if (pagingOptions.Offset != 0)
            {
                ParameterDictionary.Add(new KeyValuePair<string, string>("offset", pagingOptions.Offset.ToString()));
            }

            var requestUri = new Uri($"{SearchApi}?{ParameterDictionary.FlattenQueryString()}", UriKind.Relative);

            var result = await HTTPClient.GetAsync(requestUri);
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return SearchResult.FromJson(json);
        }

        public void Dispose()
        {
            HTTPClient?.Dispose();
        }
    }
}