using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        }

        private void ExcRate_Click(object sender, RoutedEventArgs e)
        {
            Grid MainGrid = new Grid {
                Width = 380,
                Height = 50,
                Margin = new Thickness{ 
                    Bottom = 10,
                    Left = 10,
                    Right = 10,
                    Top = 10,
                },
                Background = Brushes.White,
            };

            TextBlock ArrowText = new TextBlock {
                Text = "-",
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            TextBlock ValueChangesText = new TextBlock
            {
                Text = "0.0000",
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            MainGrid.Children.Add(ValueChangesText);
            MainGrid.Children.Add(ArrowText);

            Grid LeftPartGrid = new Grid {
                HorizontalAlignment= HorizontalAlignment.Left,
            };

            TextBlock LeftPartMainTB = new TextBlock {
                Text = "USD",
                FontSize = 25,
                Background = Brushes.Red,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            TextBlock LeftPartDownTB = new TextBlock
            {
                Text = "uss",
                FontSize = 15,
                Background = Brushes.Blue,
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
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            TextBlock RightPartMainTB = new TextBlock
            {
                Text = "CZK",
                FontSize = 25,
                Background = Brushes.Red,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            TextBlock RightPartDownTB = new TextBlock
            {
                Text = "czkkkkk",
                FontSize = 15,
                Background = Brushes.Blue,
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

            MainGrid.Children.Add(RightPartGrid);
            MainGrid.Children.Add(LeftPartGrid);

            MainStackPanel.Children.Add(MainGrid);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
