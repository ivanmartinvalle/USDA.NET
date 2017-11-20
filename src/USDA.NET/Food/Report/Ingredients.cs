using Newtonsoft.Json;

namespace USDA.NET.Food.Report
{
    public class Ingredients
    {
        /// <summary>
        /// List of ingredients
        /// </summary>
        [JsonProperty("desc")]
        public string Description { get; set; }

        /// <summary>
        /// Date ingredients were last updated by company
        /// </summary>
        [JsonProperty("upd")]
        public string LastUpdated { get; set; }
    }
}