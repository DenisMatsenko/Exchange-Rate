using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    }
}