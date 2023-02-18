using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExchangeRate
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitMyComponents();
        }

        private void ExcRate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InitMyComponents()
        {
            if (!File.Exists("MyCurrencies.txt"))
                InitMyCurrenciesFile();
            if (!File.Exists("MyExchagesRates.txt"))
                InitMyExchangesRatesFile();

            RefreshBoxes();
        }

        public void RefreshBoxes()
        {
            MainStackPanel.Children.Clear();

            foreach (var item in LocalData.GetExchangeRates())
            {
                MainStackPanel.Children.Add(item.Grid);
            }
        }

        private void InitMyCurrenciesFile()
        {
            File.Create("MyCurrencies.txt");
        }

        private void InitMyExchangesRatesFile()
        {
            File.Create("MyExchagesRates.txt");
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddExchangeButtonClick(object sender, RoutedEventArgs e)
        {
            LocalData.AddExchangeRate(LeftDropMenu.Text, RightDropMenu.Text);
            RefreshBoxes();
        }

        private void ClearAllButtonClick(object sender, RoutedEventArgs e)
        {
            LocalData.ClearAllExchange();
            RefreshBoxes();
        }
    }
}
