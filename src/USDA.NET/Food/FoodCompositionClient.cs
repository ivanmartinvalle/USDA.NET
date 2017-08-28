using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace USDA.NET.Food
{
	public class FoodCompositionClient : IDisposable
	{
		private static readonly Uri SearchApi = new Uri("/ndb/search/", UriKind.Relative);

		private readonly HttpClient _httpClient;
		private readonly string _apiKey;

		public FoodCompositionClient(string apiKey)
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://api.nal.usda.gov")
			};
			_apiKey = apiKey;
		}

		public async Task<SearchResult> SearchAsync(SearchOptions searchOptions, PaginationOptions pagingOptions)
		{
			var queryString = BuildQueryString(searchOptions, pagingOptions);
			var requestUri = new Uri($"{SearchApi}?{queryString}", UriKind.Relative);

			var result = await _httpClient.GetAsync(requestUri);
			result.EnsureSuccessStatusCode();

			return await result.Content.ReadAsAsync<SearchResult>();
		}

		private string BuildQueryString(SearchOptions searchOptions, PaginationOptions pagingOptions)
		{
			var parameterDictionary = new Dictionary<string, string>();
			parameterDictionary["format"] = "json";
			parameterDictionary["api_key"] = _apiKey;

			parameterDictionary["q"] = searchOptions.Q;
			parameterDictionary["ds"] = searchOptions.Ds;
			parameterDictionary["fg"] = searchOptions.Fg;

			parameterDictionary["sort"] = pagingOptions.Sort;

			if (pagingOptions.Max != 0)
			{
				parameterDictionary["max"] = pagingOptions.Max.ToString();				
			}
			if (pagingOptions.Offset != 0)
			{
				parameterDictionary["offset"] = pagingOptions.Offset.ToString();			
			}

			var parameters = parameterDictionary.Where(parameter => parameter.Value != null)
				.Select(parameter => $"{parameter.Key}={HttpUtility.UrlEncode(parameter.Value)}");
			
			return string.Join("&", parameters);
		}

		public void Dispose()
		{
			_httpClient.Dispose();
		}
	}
}