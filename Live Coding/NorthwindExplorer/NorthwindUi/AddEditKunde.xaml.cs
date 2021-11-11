using NorthwindDal;
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

namespace NorthwindUi
{
    /// <summary>
    /// Interaction logic for AddEditKunde.xaml
    /// </summary>
    public partial class AddEditKunde : Window
    {
        public AddEditKunde(Customer customer)
        {
            InitializeComponent();

            this.DataContext = customer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
