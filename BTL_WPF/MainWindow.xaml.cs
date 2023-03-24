using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BTL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Bingo3x3 q = new Bingo3x3();
            q.Show();
            Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Bingo4x4 r = new Bingo4x4();
            r.Show();
            Close();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Bingo5x5 t = new Bingo5x5();
            t.Show();
            Close();
        }

        private void click1_Click(object sender, RoutedEventArgs e)
        {
          huongdan huongdan = new huongdan();
            huongdan.Show();
            Close();
        }
    }
}
