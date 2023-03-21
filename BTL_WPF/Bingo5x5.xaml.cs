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
using System.Windows.Shapes;

namespace BTL_WPF
{
    /// <summary>
    /// Interaction logic for Bingo5x5.xaml
    /// </summary>
    public partial class Bingo5x5 : Window
    {
        public Bingo5x5()
        {
            InitializeComponent();
        }
        int count = 0;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ;
            // Set the number of rows and columns
            int rows = 5;
            int columns = 5;

            // Create the rows and columns
            for (int i = 0; i < rows; i++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < columns; i++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Create the buttons
            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < columns; col++)
                {
                    int n = new Random().Next(0, 99);
                    Button myButton = new Button();
                    myButton.Content = n;
                    Grid.SetRow(myButton, row);
                    Grid.SetColumn(myButton, col);
                    myButton.Click += btn_Click;
                    myGrid.Children.Add(myButton);
                }
            }
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            if (tbl2.Text == button.Content.ToString())
            {
                button.Background = Brushes.Violet;
                button.BorderBrush = Brushes.Black;

            }

        }

        private void click_Click(object sender, RoutedEventArgs e)
        {
            count++;
            tbl1.Text = count.ToString();
            int n = new Random().Next(0, 99);
            tbl2.Text = n.ToString();
        }
    }
}