﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using FinalNamespace;
//
//    var finalData = FinalData.FromJson(jsonString);

namespace FinalNamespace
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FinalData
    {
        [JsonProperty("parks")]
        public List<Parks> Parks { get; set; }
    }

    public partial class Parks
    {
        [JsonProperty("parkName")]
        public string ParkName { get; set; }

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

        [JsonProperty("weather")]
        public List<WeatherDetails> Weather { get; set; }
    }

    public partial class Images
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class WeatherDetails
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class FinalData
    {
        public static FinalData FromJson(string json) => JsonConvert.DeserializeObject<FinalData>(json, FinalNamespace.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this FinalData self) => JsonConvert.SerializeObject(self, FinalNamespace.Converter.Settings);
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
