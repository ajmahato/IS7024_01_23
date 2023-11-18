﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using StateNamespace;
//
//    var stateJson = StateJson.FromJson(jsonString);
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StateNamespace
{
    public partial class StateJson
    {
        [JsonProperty("total")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Total { get; set; }

        [JsonProperty("limit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Limit { get; set; }

        [JsonProperty("start")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Start { get; set; }

        [JsonProperty("data")]
        public List<StateData> Data { get; set; }
    }

    public partial class StateData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("parkCode")]
        public string ParkCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latLong")]
        public string LatLong { get; set; }

        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }

        [JsonProperty("topics")]
        public List<Activity> Topics { get; set; }

        [JsonProperty("states")]
        public string States { get; set; }

        [JsonProperty("contacts")]
        public Contacts Contacts { get; set; }

        [JsonProperty("entranceFees")]
        public List<Entrance> EntranceFees { get; set; }

        [JsonProperty("entrancePasses")]
        public List<Entrance> EntrancePasses { get; set; }

        [JsonProperty("fees")]
        public List<object> Fees { get; set; }

        [JsonProperty("directionsInfo")]
        public string DirectionsInfo { get; set; }

        [JsonProperty("directionsUrl")]
        public Uri DirectionsUrl { get; set; }

        [JsonProperty("operatingHours")]
        public List<OperatingHour> OperatingHours { get; set; }

        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("weatherInfo")]
        public string WeatherInfo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("relevanceScore")]
        public long RelevanceScore { get; set; }
    }

    public partial class Activity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateCode")]
        public string StateCode { get; set; }

        [JsonProperty("countryCode")]
        public CountryCode CountryCode { get; set; }

        [JsonProperty("provinceTerritoryCode")]
        public string ProvinceTerritoryCode { get; set; }

        [JsonProperty("line1")]
        public string Line1 { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("line3")]
        public Line3 Line3 { get; set; }

        [JsonProperty("line2")]
        public string Line2 { get; set; }
    }

    public partial class Contacts
    {
        [JsonProperty("phoneNumbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        [JsonProperty("emailAddresses")]
        public List<EmailAddress> EmailAddresses { get; set; }
    }

    public partial class EmailAddress
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddressEmailAddress { get; set; }
    }

    public partial class PhoneNumber
    {
        [JsonProperty("phoneNumber")]
        public string PhoneNumberPhoneNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Entrance
    {
        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("credit")]
        public Credit Credit { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("altText")]
        public string AltText { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class OperatingHour
    {
        [JsonProperty("exceptions")]
        public List<ExceptionElement> Exceptions { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("standardHours")]
        public Hours StandardHours { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ExceptionElement
    {
        [JsonProperty("exceptionHours")]
        public Hours ExceptionHours { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }
    }

    public partial class Hours
    {
        [JsonProperty("wednesday", NullValueHandling = NullValueHandling.Ignore)]
        public string Wednesday { get; set; }

        [JsonProperty("monday", NullValueHandling = NullValueHandling.Ignore)]
        public string Monday { get; set; }

        [JsonProperty("thursday", NullValueHandling = NullValueHandling.Ignore)]
        public string Thursday { get; set; }

        [JsonProperty("sunday", NullValueHandling = NullValueHandling.Ignore)]
        public string Sunday { get; set; }

        [JsonProperty("tuesday", NullValueHandling = NullValueHandling.Ignore)]
        public string Tuesday { get; set; }

        [JsonProperty("friday", NullValueHandling = NullValueHandling.Ignore)]
        public string Friday { get; set; }

        [JsonProperty("saturday", NullValueHandling = NullValueHandling.Ignore)]
        public string Saturday { get; set; }
    }

    public enum CountryCode { Us };

    public enum Line3 { Empty, The1StFloor, The26WallSt };

    public enum TypeEnum { Mailing, Physical };

    public enum Credit { NpsKristiRugg, NpsLizMacro, NpsPhoto, NpsPhotoBettyBrown };

    public partial class StateJson
    {
        public static StateJson FromJson(string json) => JsonConvert.DeserializeObject<StateJson>(json, StateNamespace.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this StateJson self) => JsonConvert.SerializeObject(self, StateNamespace.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CountryCodeConverter.Singleton,
                Line3Converter.Singleton,
                TypeEnumConverter.Singleton,
                CreditConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CountryCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CountryCode) || t == typeof(CountryCode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "US")
            {
                return CountryCode.Us;
            }
            throw new Exception("Cannot unmarshal type CountryCode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CountryCode)untypedValue;
            if (value == CountryCode.Us)
            {
                serializer.Serialize(writer, "US");
                return;
            }
            throw new Exception("Cannot marshal type CountryCode");
        }

        public static readonly CountryCodeConverter Singleton = new CountryCodeConverter();
    }

    internal class Line3Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Line3) || t == typeof(Line3?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Line3.Empty;
                //case "1st Floor":
                //    return Line3.Empty;
                //case "26 Wall St":
                //    return Line3.Empty;
                default:
                    return Line3.Empty;
            }
            throw new Exception("Cannot unmarshal type Line3");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Line3)untypedValue;
            switch (value)
            {
                case Line3.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Line3.The1StFloor:
                    serializer.Serialize(writer, "1st Floor");
                    return;
                case Line3.The26WallSt:
                    serializer.Serialize(writer, "26 Wall St");
                    return;
            }
            throw new Exception("Cannot marshal type Line3");
        }

        public static readonly Line3Converter Singleton = new Line3Converter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Mailing":
                    return TypeEnum.Mailing;
                case "Physical":
                    return TypeEnum.Physical;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Mailing:
                    serializer.Serialize(writer, "Mailing");
                    return;
                case TypeEnum.Physical:
                    serializer.Serialize(writer, "Physical");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class CreditConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Credit) || t == typeof(Credit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "NPS / Kristi Rugg":
                    return Credit.NpsKristiRugg;
                //case "NPS / Liz Macro":
                //    return Credit.NpsLizMacro;
                //case "NPS Photo":
                //    return Credit.NpsPhoto;
                //case "NPS Photo / Betty Brown":
                //    return Credit.NpsPhotoBettyBrown;
                default:
                    return Credit.NpsKristiRugg;
            }
            throw new Exception("Cannot unmarshal type Credit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Credit)untypedValue;
            switch (value)
            {
                case Credit.NpsKristiRugg:
                    serializer.Serialize(writer, "NPS / Kristi Rugg");
                    return;
                case Credit.NpsLizMacro:
                    serializer.Serialize(writer, "NPS / Liz Macro");
                    return;
                case Credit.NpsPhoto:
                    serializer.Serialize(writer, "NPS Photo");
                    return;
                case Credit.NpsPhotoBettyBrown:
                    serializer.Serialize(writer, "NPS Photo / Betty Brown");
                    return;
                default:
                    return;
            }
            throw new Exception("Cannot marshal type Credit");
        }

        public static readonly CreditConverter Singleton = new CreditConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
