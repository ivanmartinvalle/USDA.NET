using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace USDA.NET.Food
{

    public class Errors
    {
        [JsonProperty("error")]
        public List<Error> Error { get; set; } = new List<Error>();
    }

    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }
    }
}
