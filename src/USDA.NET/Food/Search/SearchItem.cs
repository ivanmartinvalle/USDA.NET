using Newtonsoft.Json;

namespace USDA.NET.Food.Search
{
    public class SearchItem
    {
        /// <summary>
        /// This will either be BL = Branded Food Products or SR = Standard Release
        /// </summary>
	    [JsonProperty("ds")]
        public string DataSource { get; set; }

        /// <summary>
        /// Food group to which the food belongs
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// The food’s name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The food’s NDB Number
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("ndbno")]
        public string NDBNumber { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }
}