﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using parksNamespace;
//
//    var parksData = ParksData.FromJson(jsonString);
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace parksNamespace
{
    public partial class ParksData
    {
        [JsonProperty("parks")]
        public List<ParkData> Parks { get; set; }
    }

    public partial class ParkData
    {
        [JsonProperty("parkName")]
        public string ParkName { get; set; }

        [JsonProperty("parkID")]
        public string ParkID{ get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("images")]
        public string Images { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateCode")]
        public string StateCode { get; set; }
    }

    public partial class ParkImage
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class ParksData
    {
        public static ParksData FromJson(string json) => JsonConvert.DeserializeObject<ParksData>(json, parksNamespace.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ParksData self) => JsonConvert.SerializeObject(self, parksNamespace.Converter.Settings);
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
