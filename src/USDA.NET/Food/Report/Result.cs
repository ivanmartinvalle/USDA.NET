using System.Collections.Generic;
using Newtonsoft.Json;

namespace USDA.NET.Food.Report
{
    public class Result
    {
        /// <summary>
        /// API Version
        /// </summary>
        [JsonProperty("api")]
        public long Api { get; set; }

        /// <summary>
        /// Number of foods requested and processed
        /// </summary>
        [JsonProperty("count")]
        public long Count { get; set; }

        /// <summary>
        /// The list of foods reported for a request
        /// </summary>
        [JsonProperty("foods")]
        public List<RootFood> Foods { get; set; }

        /// <summary>
        /// Number of requested foods not found in the database
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("notfound")]
        public long NotFound { get; set; }

        [JsonProperty("errors")]
        public Errors Errors { get; set; } = new Errors();

        public static Result FromJson(string json) => JsonConvert.DeserializeObject<Result>(json, Converter.Settings);
    }
}
