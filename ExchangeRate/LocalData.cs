using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace ExchangeRate
{
    internal class LocalData
    {
        public static void AddExchangeRate(string OneCurrency, string TwoCurrency)
        {
            List<string> MyCurrencies = File.ReadAllLines("MyCurrencies.txt").ToList<string>();

            if (OneCurrency != "" && TwoCurrency != "" && OneCurrency != TwoCurrency)
                MyCurrencies.Add($"{OneCurrency}-{TwoCurrency}");

            File.WriteAllLines("MyCurrencies.txt", MyCurrencies);
        }

        public static List<MyExchangeRate> GetExchangeRates()
        {
            List<MyExchangeRate> ExchangeRateList = new List<MyExchangeRate>();
            foreach (var item in File.ReadAllLines("MyCurrencies.txt"))
            {
                ExchangeRateList.Add(new MyExchangeRate(item.Split('-')[0], item.Split('-')[1]));
            }

            return ExchangeRateList;
        }

        public static void ClearAllExchange()
        {
            File.WriteAllLines("MyCurrencies.txt", new string[0]);
        }

        public static void UpdateExchangeRates()
        {
            string end_date = DateTime.Now.ToString("yyyy-MM-dd");
            string start_date = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");

            string[] Currencies = { "USD", "EUR", "CZK", "JPY", "GBP", "CHF", "CNY", "PLN", "UAH", "RUB" };

            string url = $"https://api.apilayer.com/exchangerates_data/fluctuation?start_date={start_date}&end_date={end_date}&base=USD&apikey=ABZgiik4q2TPh3RYQ2T5K4y3K4eQrjVj";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            List<string> CurrencieNow = new List<string>();
            List<string> CurrencieOld = new List<string>();

            JObject jObject = JObject.Parse(response);
            JToken JAllRates = jObject["rates"];

            foreach (var cur in Currencies)
            {
                JToken Jcurrencie = JAllRates[cur];
                CurrencieNow.Add($"{cur}-{Jcurrencie["end_rate"]}");
                CurrencieOld.Add($"{cur}-{Jcurrencie["start_rate"]}");
            }

            File.WriteAllLines("CurrencieNow.txt", CurrencieNow);
            File.WriteAllLines("CurrencieOld.txt", CurrencieOld);
        }
    }
}