

namespace WeatherSchemaData
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WeatherSchema
    {
        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("WeatherDataFinal")]
        public List<WeatherInfo> WeatherDataFinal { get; set; }
    }

    public partial class WeatherInfo
    {
        [JsonProperty("app_max_temp")]
        public double AppMaxTemp { get; set; }

        [JsonProperty("app_min_temp")]
        public double AppMinTemp { get; set; }

        [JsonProperty("clouds")]
        public long Clouds { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("precip")]
        public double Precip { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("wind_cdir")]
        public string WindCdir { get; set; }

        [JsonProperty("wind_spd")]
        public double WindSpd { get; set; }
    }

    public partial class WeatherSchema
    {
        public static WeatherSchema FromJson(string json) => JsonConvert.DeserializeObject<WeatherSchema>(json, WeatherSchemaData.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WeatherSchema self) => JsonConvert.SerializeObject(self, WeatherSchemaData.Converter.Settings);
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
