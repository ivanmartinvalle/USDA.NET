using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace USDA.NET.Food.Search
{
	public class SearchResult
	{
        /// <summary>
        /// Information about the items returned.
        /// </summary>
        [CanBeNull]
	    [JsonProperty("list")]
        public SearchList List { get; set; }

        /// <summary>
        /// List of errors.
        /// </summary>
        [JsonProperty("errors")]
	    public Errors Errors { get; set; } = new Errors();

        /// <summary>
        /// Shortcut to Errors -> Error -> where message contains "zero results"
        /// </summary>
	    public bool NotFound => Errors.Error.Any(x => x.Message.Contains("zero results"));

        public static SearchResult FromJson(string json) => JsonConvert.DeserializeObject<SearchResult>(json, Converter.Settings);
    }
}