using Newtonsoft.Json;

namespace USDA.NET.Food.Report
{
    public class Measure
    {
        /// <summary>
        /// Equivalent of the measure expressed as an <seealso cref="Unit"/>
        /// </summary>
        [JsonProperty("eqv")]
        public long Equivalent { get; set; }

        /// <summary>
        /// Unit in with the equivalent amount is expressed. Usually either gram (g) or milliliter (ml)
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("eunit")]
        public string Unit { get; set; }

        /// <summary>
        /// Name of the measure, e.g. "large"
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("qty")]
        public long Quantity { get; set; }

        /// <summary>
        /// Gram equivalent value of the measure.
        /// </summary>
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}