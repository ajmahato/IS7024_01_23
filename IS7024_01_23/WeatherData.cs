namespace WeatherSpace
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WeatherData
    {
        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("state_code")]
        public string StateCode { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("app_max_temp")]
        public double AppMaxTemp { get; set; }

        [JsonProperty("app_min_temp")]
        public double AppMinTemp { get; set; }

        [JsonProperty("clouds")]
        public long Clouds { get; set; }

        [JsonProperty("clouds_hi")]
        public long CloudsHi { get; set; }

        [JsonProperty("clouds_low")]
        public long CloudsLow { get; set; }

        [JsonProperty("clouds_mid")]
        public long CloudsMid { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("dewpt")]
        public double Dewpt { get; set; }

        [JsonProperty("high_temp")]
        public double HighTemp { get; set; }

        [JsonProperty("low_temp")]
        public double LowTemp { get; set; }

        [JsonProperty("max_dhi")]
        public object MaxDhi { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonProperty("moon_phase_lunation")]
        public double MoonPhaseLunation { get; set; }

        [JsonProperty("moonrise_ts")]
        public long MoonriseTs { get; set; }

        [JsonProperty("moonset_ts")]
        public long MoonsetTs { get; set; }

        [JsonProperty("ozone")]
        public double Ozone { get; set; }

        [JsonProperty("pop")]
        public long Pop { get; set; }

        [JsonProperty("precip")]
        public double Precip { get; set; }

        [JsonProperty("pres")]
        public double Pres { get; set; }

        [JsonProperty("rh")]
        public long Rh { get; set; }

        [JsonProperty("slp")]
        public double Slp { get; set; }

        [JsonProperty("snow")]
        public long Snow { get; set; }

        [JsonProperty("snow_depth")]
        public long SnowDepth { get; set; }

        [JsonProperty("sunrise_ts")]
        public long SunriseTs { get; set; }

        [JsonProperty("sunset_ts")]
        public long SunsetTs { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("uv")]
        public double Uv { get; set; }

        [JsonProperty("valid_date")]
        public DateTimeOffset ValidDate { get; set; }

        [JsonProperty("vis")]
        public double Vis { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("wind_cdir")]
        public string WindCdir { get; set; }

        [JsonProperty("wind_cdir_full")]
        public string WindCdirFull { get; set; }

        [JsonProperty("wind_dir")]
        public long WindDir { get; set; }

        [JsonProperty("wind_gust_spd")]
        public double WindGustSpd { get; set; }

        [JsonProperty("wind_spd")]
        public double WindSpd { get; set; }
    }

    public partial class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public partial class WeatherData
    {
        public static WeatherData FromJson(string json) => JsonConvert.DeserializeObject<WeatherData>(json, WeatherSpace.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WeatherData self) => JsonConvert.SerializeObject(self, WeatherSpace.Converter.Settings);
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
