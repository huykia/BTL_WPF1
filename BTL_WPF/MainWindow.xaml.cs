using System;
using System.Windows;
using System.Windows.Media;

namespace BTL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int manchoi;
        int lever;
        MediaPlayer player = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            player.Open(new Uri("C:\\Users\\huyng\\Documents\\Bt\\BTL_WPF\\BTL_WPF\\sound\\Nhac-chuong-khai-mac.mp3", UriKind.Relative));
            player.Play();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            manchoi = 1;
            btn1.Background = Brushes.Blue;
            btn2.Background = Brushes.Green;
            btn3.Background = Brushes.Green;   
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            manchoi = 2;
            btn2.Background = Brushes.Blue;
            btn1.Background = Brushes.Green;
            btn3.Background = Brushes.Green;
            
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            manchoi = 3;
            btn3.Background = Brushes.Blue;
            btn2.Background = Brushes.Green;
            btn1.Background = Brushes.Green;
            
        }

        private void click1_Click(object sender, RoutedEventArgs e)
        {
            huongdan huongdan = new huongdan();
            huongdan.Show();
            player.Close();
            Close();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            player.Close();
            lever = 1;
            if (manchoi == 1)
            {
                Bingo3x3 bingo3X3 = new Bingo3x3(lever);
                bingo3X3.Show();
                Close();
            }
            else if (manchoi == 2)
            {
                Bingo4x4 bingo4X4 = new Bingo4x4(lever);
                bingo4X4.Show();
                Close();
            }
            else if (manchoi == 3)
            {
                Bingo5x5 bingo5X5 = new Bingo5x5(lever);
                bingo5X5.Show();
                Close();
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            player.Close();
            lever = 2;
            if (manchoi == 1)
            {
                Bingo3x3 bingo3X3 = new Bingo3x3(lever);
                bingo3X3.Show();
                Close();
            }
            else if (manchoi == 2)
            {
                Bingo4x4 bingo4X4 = new Bingo4x4(lever);
                bingo4X4.Show();
                Close();
            }
            else if (manchoi == 3)
            {
                Bingo5x5 bingo5X5 = new Bingo5x5(lever);
                bingo5X5.Show();
                Close();
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            player.Close();
            lever = 3;
            if (manchoi == 1)
            {
                Bingo3x3 bingo3X3 = new Bingo3x3(lever);
                bingo3X3.Show();
                Close();
            }
            else if (manchoi == 2)
            {
                Bingo4x4 bingo4X4 = new Bingo4x4(lever);
                bingo4X4.Show();
                Close();
            }
            else if (manchoi == 3)
            {
                Bingo5x5 bingo5X5 = new Bingo5x5(lever);
                bingo5X5.Show();
                Close();
            }
        }
    }
}
