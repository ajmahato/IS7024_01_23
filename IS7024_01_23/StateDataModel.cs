using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IS7024_01_23
{
    public partial class StateDataModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }
    }

    public partial class StateDataModel
    {
        public static List<StateDataModel> FromJson(string json) => JsonConvert.DeserializeObject<List<StateDataModel>>(json, IS7024_01_23.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<StateDataModel> self) => JsonConvert.SerializeObject(self, IS7024_01_23.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
