using Newtonsoft.Json;

namespace USDA.NET.Food.Report
{
    public class Description
    {
        /// <summary>
        /// Carbohydrate factor
        /// </summary>
        [JsonProperty("cf")]
        public double? CarbohydrateFactor { get; set; }

        /// <summary>
        /// Commercial name
        /// </summary>
        [JsonProperty("cn")]
        public string CommercialName { get; set; }

        /// <summary>
        /// Database source: 'Branded Food Products' or 'Standard Reference'
        /// </summary>
        [JsonProperty("ds")]
        public string DataSource { get; set; }

        /// <summary>
        /// Fat factor
        /// </summary>
        [JsonProperty("ff")]
        public double? FatFactor { get; set; }

        /// <summary>
        /// Food Group
        /// </summary>
        [JsonProperty("fg")]
        public string FoodGroup { get; set; }

        /// <summary>
        /// Manufacturer
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("manu")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Food name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// NDB food number
        /// </summary>
        // ReSharper disable once StringLiteralTypo
        [JsonProperty("ndbno")]
        public string NDBNumber { get; set; }

        /// <summary>
        /// Nitrogen to protein conversion factor
        /// </summary>
        [JsonProperty("nf")]
        public long? NitrogenFactor { get; set; }

        /// <summary>
        /// Protein factor
        /// </summary>
        [JsonProperty("pf")]
        public double? ProteinFactor { get; set; }

        /// <summary>
        /// Refuse %
        /// </summary>
        [JsonProperty("r")]
        public string RefusePercent { get; set; }

        /// <summary>
        /// Refuse description
        /// </summary>
        [JsonProperty("rd")]
        public string RefuseDescription { get; set; }

        /// <summary>
        /// Reporting unit: nutrient values are reported in this unit, usually gram (g) or milliliter (ml)
        /// </summary>
        [JsonProperty("ru")]
        public string ReportingUnit { get; set; }

        /// <summary>
        /// Short description
        /// </summary>
        [JsonProperty("sd")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Scientific name
        /// </summary>
        [JsonProperty("sn")]
        public string ScientificName { get; set; }
    }
}