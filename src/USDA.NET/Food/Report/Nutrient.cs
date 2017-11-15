using System.Collections.Generic;
using Newtonsoft.Json;

namespace USDA.NET.Food.Report
{
    public class Nutrient
    {
        /// <summary>
        /// Indicator of how the value was derived
        /// </summary>
        [JsonProperty("derivation")]
        public string Derivation { get; set; }

        /// <summary>
        /// Number of data points
        /// </summary>
        [JsonProperty("dp")]
        public int? DataPoint { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("measures")]
        public List<Measure> Measures { get; set; }

        /// <summary>
        /// Nutrient name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Nutrient number (nutrient_no) for the nutrient
        /// </summary>
        [JsonProperty("nutrient_id")]
        public int NutrientId { get; set; }

        /// <summary>
        /// Standard error
        /// </summary>
        [JsonProperty("se")]
        public string StandardError { get; set; }

        /// <summary>
        /// List of source id's in the sources list referenced for this nutrient
        /// </summary>
        [JsonProperty("sourcecode")]
        public List<int> Sourcecode { get; set; }

        /// <summary>
        /// Unit of measure for this nutrient
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 100 g equivalent value of the nutrient
        /// </summary>
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}