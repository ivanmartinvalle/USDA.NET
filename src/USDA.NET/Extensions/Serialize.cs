using Newtonsoft.Json;
using USDA.NET.Food.Report;
using USDA.NET.Food.Search;

namespace USDA.NET.Extensions
{
    public static class SerializeExtension
    {
        public static string ToJson(this SearchResult self) => JsonConvert.SerializeObject(self, Converter.Settings);

        public static string ToJson(this Result self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
