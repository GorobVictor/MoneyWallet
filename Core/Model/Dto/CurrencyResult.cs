using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Core.Model.Dto
{
    public class CurrencyResult
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class Data
    {
        [JsonProperty("base")]
        public Base Base { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("rates")]
        public Rates Rates { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public class Base
    {
        [JsonProperty("currency1")]
        public string Currency1 { get; set; }
        [JsonProperty("currency2")]
        public string Currency2 { get; set; }
    }
    public class Rates
    {
        [JsonProperty("buy")]
        public Seller Buy { get; set; }
        [JsonProperty("sell")]
        public Seller Sell { get; set; }
    }
    public class Seller
    {
        public double UAH { get; set; }
        public double USD { get; set; }
        public double EUR { get; set; }
    }

}
