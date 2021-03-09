using Core.Model.Dto;
using Core.Model.Enum;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Core.Utils
{
    public class CurrencyParser
    {
        private static GetCurrency UAHfromUSD { get; set; }
        private static GetCurrency UAHfromEUR { get; set; }
        private static object Lock { get; set; }
        public static GetCurrency GetUAHfromUSD()
        {
            if (UAHfromUSD == null)
            {
                Set();
            }
            else if ((DateTime.Now - UAHfromUSD.OldReflesh).Hours > 1)
            {
                Set();
            }

            return UAHfromUSD;
        }
        public static GetCurrency GetUAHfromEUR()
        {
            if (UAHfromEUR == null)
            {
                Set();
            }
            else if ((DateTime.Now - UAHfromEUR.OldReflesh).Hours > 1)
            {
                Set();
            }

            return UAHfromEUR;
        }
        public static async Task<GetCurrency> GetUAHfromUSDAsync()
        {
            if (UAHfromUSD == null)
            {
                await SetAsync();
            }
            else if ((DateTime.Now - UAHfromUSD.OldReflesh).Hours > 1)
            {
                await SetAsync();
            }

            return UAHfromUSD;
        }
        public static async Task<GetCurrency> GetUAHfromEURAsync()
        {
            if (UAHfromEUR == null)
            {
                await SetAsync();
            }
            else if ((DateTime.Now - UAHfromEUR.OldReflesh).Hours > 1)
            {
                await SetAsync();
            }

            return UAHfromEUR;
        }
        private static void Set()
        {
            var restclient = new RestClient("https://minfin.com.ua/api");
            var request = new RestRequest("currency/ratelist");

            var response = restclient.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var price = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrencyResult>(response.Content);
                UAHfromUSD = new GetCurrency(price.Data.Rates.Buy.USD, price.Data.Rates.Sell.USD, DateTime.Now);
                UAHfromEUR = new GetCurrency(price.Data.Rates.Buy.EUR, price.Data.Rates.Sell.EUR, DateTime.Now);
            }
        }
        private static async Task SetAsync()
        {
            var restclient = new RestClient("https://minfin.com.ua/api");
            var request = new RestRequest("currency/ratelist");

            var response = await restclient.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var price = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrencyResult>(response.Content);
                UAHfromUSD = new GetCurrency(price.Data.Rates.Buy.USD, price.Data.Rates.Sell.USD, DateTime.Now);
                UAHfromEUR = new GetCurrency(price.Data.Rates.Buy.EUR, price.Data.Rates.Sell.EUR, DateTime.Now);
            }
        }

        public static double Convert(Currency currency, Currency convertToCurrency, double value)
        {
            switch (currency)
            {
                case Currency.EUR:
                    switch (convertToCurrency)
                    {
                        case Currency.EUR:
                            return value;
                        case Currency.UAH:
                            return value * GetUAHfromEUR().Buy;
                        case Currency.USD:
                            return value * GetUAHfromEUR().Buy / GetUAHfromUSD().Buy;
                    }
                    break;
                case Currency.UAH:
                    switch (convertToCurrency)
                    {
                        case Currency.EUR:
                            return value / GetUAHfromEUR().Buy;
                        case Currency.UAH:
                            return value;
                        case Currency.USD:
                            return value / GetUAHfromUSD().Buy;
                    }
                    break;
                case Currency.USD:
                    switch (convertToCurrency)
                    {
                        case Currency.EUR:
                            return value * GetUAHfromUSD().Buy / GetUAHfromEUR().Buy;
                        case Currency.UAH:
                            return value * GetUAHfromUSD().Buy;
                        case Currency.USD:
                            return value;
                    }
                    break;
            }
            return -1;
        }
        public static async Task<double> ConvertAsync(Currency currency, Currency convertToCurrency, double value)
        {
            switch (currency)
            {
                case Currency.EUR:
                    switch (convertToCurrency)
                    {
                        case Currency.EUR:
                            return value;
                        case Currency.UAH:
                            return value * (await GetUAHfromEURAsync()).Buy;
                        case Currency.USD:
                            return value * (await GetUAHfromEURAsync()).Buy / (await GetUAHfromUSDAsync()).Buy;
                    }
                    break;
                case Currency.UAH:
                    switch (convertToCurrency)
                    {
                        case Currency.EUR:
                            return value / (await GetUAHfromEURAsync()).Buy;
                        case Currency.UAH:
                            return value;
                        case Currency.USD:
                            return value / (await GetUAHfromUSDAsync()).Buy;
                    }
                    break;
                case Currency.USD:
                    switch (convertToCurrency)
                    {
                        case Currency.EUR:
                            return value * (await GetUAHfromUSDAsync()).Buy / (await GetUAHfromEURAsync()).Buy;
                        case Currency.UAH:
                            return value * (await GetUAHfromUSDAsync()).Buy;
                        case Currency.USD:
                            return value;
                    }
                    break;
            }
            return -1;
        }
    }
}
