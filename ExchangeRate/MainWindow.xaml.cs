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
            InitMyCurrencies();
        }

        private void ExcRate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InitMyCurrencies()
        {
            if (!File.Exists("MyCurrencies.txt"))
                InitMyCurrenciesFile();

            CreateBoxes();

        }

        private void CreateBoxes()
        {
            string[] MyCurrencies = File.ReadAllLines("MyCurrencies.txt");

            for (int i = 0; i < MyCurrencies.Length; i++)
            {
                string[] OneCurrencies = MyCurrencies[i].Split('-');

                CreateNewExchangeBox(OneCurrencies[0], OneCurrencies[1]);
            }
        }

        private void InitMyCurrenciesFile()
        {
            File.Create("MyCurrencies.txt");
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateNewExchangeBox(string LeftCurrence, string RightCurrence)
        {
            Grid MainGrid = new Grid
            {
                Width = 380,
                Height = 50,
                Margin = new Thickness
                {
                    Bottom = 10,
                    Left = 10,
                    Right = 10,
                    Top = 10,
                },
                Background = Brushes.White,
            };

            TextBlock ArrowText = new TextBlock
            {
                Text = "-",
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness
                {
                    Bottom = 0,
                    Left = 0,
                    Right = 25,
                    Top = 0,
                },
            };

            TextBlock ValueChangesText = new TextBlock
            {
                Text = "0.0000",
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness
                {
                    Bottom = 0,
                    Left = 0,
                    Right = 25,
                    Top = 0,
                },
            };

            MainGrid.Children.Add(ValueChangesText);
            MainGrid.Children.Add(ArrowText);

            Grid LeftPartGrid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            TextBlock LeftPartMainTB = new TextBlock
            {
                Text = LeftCurrence,
                FontSize = 25,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            TextBlock LeftPartDownTB = new TextBlock
            {
                Text = "uss",
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            TextBlock LeftPartNumTB = new TextBlock
            {
                Text = "1",
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness
                {
                    Bottom = 0,
                    Left = 120,
                    Right = 0,
                    Top = 0,
                },
            };

            LeftPartGrid.Children.Add(LeftPartMainTB);
            LeftPartGrid.Children.Add(LeftPartDownTB);
            LeftPartGrid.Children.Add(LeftPartNumTB);

            Grid RightPartGrid = new Grid
            {
                Margin = new Thickness
                {
                    Bottom = 0,
                    Left = 0,
                    Right = 25,
                    Top = 0,
                },
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            TextBlock RightPartMainTB = new TextBlock
            {
                Text = RightCurrence,
                FontSize = 25,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            TextBlock RightPartDownTB = new TextBlock
            {
                Text = "czkkkkk",
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            TextBlock RightPartNumTB = new TextBlock
            {
                Text = "1",
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness
                {
                    Bottom = 0,
                    Left = 0,
                    Right = 120,
                    Top = 0,
                },
            };

            RightPartGrid.Children.Add(RightPartMainTB);
            RightPartGrid.Children.Add(RightPartDownTB);
            RightPartGrid.Children.Add(RightPartNumTB);

            StackPanel BoxButtonsPanel = new StackPanel {
                Width = 20,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            Button XButton = new Button {
                Content = "X",
                FontSize = 11,
                BorderThickness = new Thickness(0),
            };

            Button UpButton = new Button
            {
                Content = "▲",
                FontSize = 11,
                BorderThickness = new Thickness(0),
            };

            Button DownButton = new Button
            {
                Content = "▼",
                FontSize = 11,
                BorderThickness = new Thickness(0),
            };

            BoxButtonsPanel.Children.Add(XButton);
            BoxButtonsPanel.Children.Add(UpButton);
            BoxButtonsPanel.Children.Add(DownButton);


            MainGrid.Children.Add(RightPartGrid);
            MainGrid.Children.Add(LeftPartGrid);
            MainGrid.Children.Add(BoxButtonsPanel);

            MainStackPanel.Children.Add(MainGrid);
        }
    }
}
