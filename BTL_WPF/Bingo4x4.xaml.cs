using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BTL_WPF
{
    /// <summary>
    /// Interaction logic for Bingo4x4.xaml
    /// </summary>
    public partial class Bingo4x4 : Window
    {
        int count = 0;
        bool bingo = false;
        public Bingo4x4() => InitializeComponent();
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the number of rows and columns
            int rows = 4;
            int columns = 4;

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
                    int n = new Random().Next(0, 10);
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
            for (int i = (int)point.X + 1; i < 4; i++)
            {
                if (Matrix[(int)point.Y][i].Content == button.Content && bingo == true)
                {
                    countRight++;
                }
                else
                    break;
            }
            return countLeft + countRight == 4;
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
            for (int i = (int)point.Y + 1; i < 4; i++)
            {
                if (Matrix[i][(int)point.X].Content == button.Content && bingo == true)
                {
                    countBot++;
                }
                else
                    break;
            }
            return countTop + countBot == 4;
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
            for (int i = 1; i <= 4 - (int)point.X; i++)
            {
                if ((int)point.X + i >= 4 || (int)point.Y + i >= 4)
                    break;

                if (Matrix[(int)point.X + i][(int)point.Y + i].Content == button.Content && bingo == true)
                {
                    countBot++;
                }
                else
                    break;
            }
            return countTop + countBot == 4;
        }
        private bool isEndXy(Button button)
        {
            Point point = GetPoint(button);

            int countTop = 0;
            for (int i = 0; i <= (int)point.X; i++)
            {
                if ((int)point.Y + i >= 4 || (int)point.X - i < 0)
                    break;

                if (Matrix[(int)point.X - i][(int)point.Y + i].Content == button.Content && bingo == true)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBot = 0;
            for (int i = 1; i <= 4 - (int)point.X; i++)
            {
                if ((int)point.Y - i < 0 || (int)point.X + i >= 4)
                    break;

                if (Matrix[(int)point.X + i][(int)point.Y - i].Content == button.Content && bingo == true)
                {
                    countBot++;
                }
                else
                    break;
            }
            return countTop + countBot == 4;
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
            count++;
            tbl1.Text = count.ToString();
            int n = new Random().Next(0, 10);
            tbl2.Text = n.ToString();
            if (count == 20)
            {
                tbl3.Text = "Ban Thua !";

                click.Content = ("Reset");
            }
            if (count == 21)
            {
                Bingo4x4 q = new Bingo4x4();
                q.Show();
                Close();
            }
        }
    }
}