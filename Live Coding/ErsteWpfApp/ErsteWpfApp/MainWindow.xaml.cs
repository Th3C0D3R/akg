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

namespace ErsteWpfApp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnKnopf_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = "Hallo";
            e.Handled = true;
        }

        private void grdRechteHaelfte_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Grid-Klick durch {(e.Source as Button)?.Content}!");
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Window-Klick durch {(e.Source as Button)?.Content}!");

        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.GetPosition(this);
            txtBox.Text = $"{pos.X}, {pos.Y}";
        }
    }
}
