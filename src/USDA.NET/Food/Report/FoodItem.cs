using System.Collections.Generic;
using Newtonsoft.Json;

namespace USDA.NET.Food.Report
{
    public class FoodItem
    {
        /// <summary>
        /// Metadata elements for the food being reported
        /// </summary>
        [JsonProperty("desc")]
        public Description Description { get; set; }

        [JsonProperty("footnotes")]
        public List<object> Footnotes { get; set; }

        /// <summary>
        /// Ingredients (Branded Food Products report only)
        /// </summary>
        [JsonProperty("ing")]
        public Ingredients Ingredients { get; set; }

        // ReSharper disable once StringLiteralTypo
        [JsonProperty("langual")]
        // ReSharper disable once IdentifierTypo
        public List<object> Langual { get; set; }

        /// <summary>
        /// Metadata elements for each nutrient included in the food report
        /// </summary>
        [JsonProperty("nutrients")]
        public List<Nutrient> Nutrients { get; set; }

        /// <summary>
        /// Release version of the data being reported
        /// </summary>
        [JsonProperty("sr")]
        public string StandardReleaseVersion { get; set; }

        /// <summary>
        /// Report type (Report type: b = basic or f = full or s = stats)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}