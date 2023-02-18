using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExchangeRate
{
    internal class MyExchangeRate
    {
        public string OneCurrencyName { get; set; }
        public string TwoCurrencyName { get; set; }
        public Grid Grid { get; set; }

        public MyExchangeRate(string oneCurrency, string twoCurrency)
        {
            OneCurrencyName = oneCurrency;
            TwoCurrencyName = twoCurrency;

            Grid = CreateNewExchangeGrid(oneCurrency, twoCurrency);
        }

        private Grid CreateNewExchangeGrid(string LeftCurrence, string RightCurrence)
        {
            Grid MainGrid = new Grid
            {
                Width = 380,
                Height = 50,
                Margin = new Thickness
                {
                    Bottom = 0,
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
                    Right = 0,
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
                    Right = 0,
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

            TextBox LeftPartNumTB = new TextBox
            {
                Text = "1",
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment= TextAlignment.Right,
                MaxLength = 6,
                Width = 110,
                Margin = new Thickness
                {
                    Bottom = 0,
                    Left = 60,
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
                    Right = 0,
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

            TextBox RightPartNumTB = new TextBox
            {
                Text = "1",
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                MaxLength = 6,
                Margin = new Thickness
                {
                    Bottom = 0,
                    Left = 0,
                    Right = 60,
                    Top = 0,
                },
                Width = 110,
            };

            RightPartGrid.Children.Add(RightPartNumTB);
            
            RightPartGrid.Children.Add(RightPartDownTB);
            RightPartGrid.Children.Add(RightPartMainTB);


            StackPanel BoxButtonsPanel = new StackPanel
            {
                Width = 20,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            //Button XButton = new Button
            //{
            //    Content = "X",
            //    FontSize = 11,
            //    BorderThickness = new Thickness(0),
            //};

            //XButton.Click += (s, e) => { ExchangeRateBoxes.DeleteExchange(this); };

            //Button UpButton = new Button
            //{
            //    Content = "▲",
            //    FontSize = 11,
            //    BorderThickness = new Thickness(0),
            //};

            //Button DownButton = new Button
            //{
            //    Content = "▼",
            //    FontSize = 11,
            //    BorderThickness = new Thickness(0),
            //};

            //BoxButtonsPanel.Children.Add(UpButton);
            //BoxButtonsPanel.Children.Add(DownButton);
            //BoxButtonsPanel.Children.Add(XButton);

            MainGrid.Children.Add(RightPartGrid);
            MainGrid.Children.Add(LeftPartGrid);
            MainGrid.Children.Add(BoxButtonsPanel);

            return MainGrid;
        }
    }
}
