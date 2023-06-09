﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
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
        int count;
        bool bingo = false;
        bool bingo2 = false;
        int lever;
        int lever1;
        public Bingo5x5() => InitializeComponent();
        public Bingo5x5(int Lever) : this()
        {
            lever = Lever;
            if (lever == 1)
            { tbl4.Text = "Dễ";
                count = 16;
                lever1 = 25;
            }
            if (lever == 2)
            { tbl4.Text = "Trung bình";
                count = 21;
                lever1 = 50;
            }
            if (lever == 3)
            { tbl4.Text = "Khó";
                count = 26;
                lever1 = 99;
            }
        }
        MediaPlayer player = new MediaPlayer();
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
            Matrix = new List<List<Button>>();
            // Create the buttons
            for (int row = 0; row < rows; row++)
            {
                Matrix.Add(new List<Button>());
                for (int col = 0; col < columns; col++)
                {
                    int n = new Random().Next(0, lever1);
                    Button myButton = new Button();
                    myButton.Content = n;
                    Grid.SetRow(myButton, row);
                    Grid.SetColumn(myButton, col);
                    myButton.FontWeight = FontWeights.Bold;
                    myButton.FontSize = 20;
                    myButton.Click += btn_Click;
                    myButton.Tag = row.ToString();
                    myGrid.Children.Add(myButton);
                    Matrix[row].Add(myButton);
                }

            }
        }
        private bool isEndGame(Button button)
        {
            return isEndH(button) || isEndV(button) || isEndX(button) || isEndXy(button);
        }
        private void EndGame()
        {
            tbl3.Text = "BingGo!!";
            player.Close();
            player.Open(new Uri("C:\\Users\\huyng\\Documents\\Bt\\BTL_WPF\\BTL_WPF\\sound\\Tieng-vo-tay-tra-loi-dung-www_tiengdong_com.mp3", UriKind.Relative));
            player.Play();
            click.Content = ("Reset");
            bingo2 = true;

        }

        private Point GetPoint(Button button)
        {
            int vertical = Convert.ToInt32(button.Tag);
            int horziontal = Matrix[vertical].IndexOf(button);
            Point point = new Point(horziontal, vertical);
            return point;
        }
        private bool isEndH(Button button)
        {

            Point point = GetPoint(button);

            int countLeft = 0;
            for (int i = (int)point.X; i >= 0; i--)
            {
                if (Matrix[(int)point.Y][i].Content == button.Content && bingo == true)
                {
                    countLeft++;
                }
                else
                    break;
            }
            int countRight = 0;
            for (int i = (int)point.X + 1; i < 5; i++)
            {
                if (Matrix[(int)point.Y][i].Content == button.Content && bingo == true)
                {
                    countRight++;
                }
                else
                    break;
            }
            return countLeft + countRight == 5;
        }
        private bool isEndV(Button button)
        {

            Point point = GetPoint(button);

            int countTop = 0;
            for (int i = (int)point.Y; i >= 0; i--)
            {
                if (Matrix[i][(int)point.X].Content == button.Content && bingo == true)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBot = 0;
            for (int i = (int)point.Y + 1; i < 5; i++)
            {
                if (Matrix[i][(int)point.X].Content == button.Content && bingo == true)
                {
                    countBot++;
                }
                else
                    break;
            }
            return countTop + countBot == 5;
        }
        private bool isEndX(Button button)
        {

            Point point = GetPoint(button);

            int countTop = 0;
            for (int i = 0; i <= (int)point.X; i++)
            {
                if ((int)point.X - i < 0 || (int)point.Y - i < 0)
                    break;

                if (Matrix[(int)point.X - i][(int)point.Y - i].Content == button.Content && bingo == true)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBot = 0;
            for (int i = 1; i <= 5 - (int)point.X; i++)
            {
                if ((int)point.X + i >= 5 || (int)point.Y + i >= 5)
                    break;

                if (Matrix[(int)point.X + i][(int)point.Y + i].Content == button.Content && bingo == true)
                {
                    countBot++;
                }
                else
                    break;
            }
            return countTop + countBot == 5;
        }
        private bool isEndXy(Button button)
        {
            Point point = GetPoint(button);

            int countTop = 0;
            for (int i = 0; i <= (int)point.X; i++)
            {
                if ((int)point.Y + i >= 5 || (int)point.X - i < 0)
                    break;

                if (Matrix[(int)point.X - i][(int)point.Y + i].Content == button.Content && bingo == true)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBot = 0;
            for (int i = 1; i <= 5 - (int)point.X; i++)
            {
                if ((int)point.Y - i < 0 || (int)point.X + i >= 5)
                    break;

                if (Matrix[(int)point.X + i][(int)point.Y - i].Content == button.Content && bingo == true)
                {
                    countBot++;
                }
                else
                    break;
            }
            return countTop + countBot == 5;
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (tbl2.Text == button.Content.ToString())
            {
                button.Background = Brushes.Violet;
                button.BorderBrush = Brushes.Black;
                button.Content = "BG";
                bingo = true;
            }
            if (isEndGame(button))
            {
             
                EndGame();
            }

        }

        private void click_Click(object sender, RoutedEventArgs e)
        {
            count--;
            tbl1.Text = count.ToString();
            int n = new Random().Next(0, lever1);
            tbl2.Text = n.ToString();
            player.Close();
            
            player.Open(new Uri("C:\\Users\\huyng\\Documents\\Bt\\BTL_WPF\\BTL_WPF\\sound\\Tieng-lac-xuc-xac.mp3", UriKind.Relative));
            player.Play();
            if (count == 0)
            {
                if (!bingo2)
                {
                    tbl3.Text = "Ban Thua !";
                }
                click.Content = ("Reset");
            }
            if (count <0 || bingo2)
            {
                player.Close();
                Bingo5x5 q = new Bingo5x5(lever);
                q.Show();
                Close();
            }
        }

        private void click1_Click(object sender, RoutedEventArgs e)
        {
            player.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}