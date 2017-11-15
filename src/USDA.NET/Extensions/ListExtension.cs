using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USDA.NET.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        /// Takes <paramref name="input"/> and converts each item to "<paramref name="input.Key"/>=<paramref name="input.Value"/>" and then joins each with "&amp;"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FlattenQueryString(this IEnumerable<KeyValuePair<string, string>> input)
        {
            var parameters = input.Where(parameter => parameter.Value != null)
                .Select(parameter => $"{parameter.Key}={HttpUtility.UrlEncode(parameter.Value)}");

            return string.Join("&", parameters);
        }
    }
}
