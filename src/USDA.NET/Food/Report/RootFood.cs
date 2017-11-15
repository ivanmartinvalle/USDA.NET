using Newtonsoft.Json;

namespace USDA.NET.Food.Report
{
    public class RootFood
    {
        /// <summary>
        /// The food report
        /// </summary>
        [JsonProperty("food")]
        public FoodItem Food { get; set; }
    }
}