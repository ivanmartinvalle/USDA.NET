using System.Collections.Generic;
using Newtonsoft.Json;

namespace USDA.NET.Food.Search
{
	public class SearchList
	{
        /// <summary>
        /// This will either be Branded Food Products or Standard Reference
        /// </summary>
	    [JsonProperty("ds")]
	    public string DataSource { get; set; }

        /// <summary>
        /// Last item in the list (relates to <seealso cref="PaginationOptions.Offset"/>)
        /// </summary>
	    [JsonProperty("end")]
	    public long End { get; set; }

	    [JsonProperty("group")]
	    public string Group { get; set; }

        /// <summary>
        /// Terms requested and used in the search
        /// </summary>
	    [JsonProperty("q")]
	    public string Query { get; set; }

        /// <summary>
        /// Requested sort order (r = relevance or n = name)
        /// </summary>
	    [JsonProperty("sort")]
	    public string Sort { get; set; }

        /// <summary>
        /// Standard Release version of the data being reported
        /// </summary>
	    [JsonProperty("sr")]
	    public string StandardReleaseVersion { get; set; }

        /// <summary>
        /// Beginning item in the list (relates to <seealso cref="PaginationOptions.Offset"/>)
        /// </summary>
	    [JsonProperty("start")]
	    public long Start { get; set; }

        /// <summary>
        /// Total # of items returned by the search
        /// </summary>
	    [JsonProperty("total")]
	    public long Total { get; set; }

        /// <summary>
        /// List of Search Results
        /// </summary>
	    [JsonProperty("item")]
        public IEnumerable<SearchItem> Item { get; set; }
	}
}