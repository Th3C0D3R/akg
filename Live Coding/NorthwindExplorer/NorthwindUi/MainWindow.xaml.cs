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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NorthwindUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindContext context = new NorthwindContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Länder distinktiert aus der DB holen
            // SELECT DISTINCT Country FROM Customers

            var qLaender = context.Customers.Select(cu => cu.Country).Distinct();

            foreach (string land in qLaender)
            {
                TreeViewItem tviLand = new TreeViewItem() { Header = land };
                tviLand.Items.Add(new TreeViewItem());
                tviLand.Expanded += Landknoten_Expanded;

                trvKunden.Items.Add(tviLand);
            }
        }

        private void Landknoten_Expanded(object sender, RoutedEventArgs e)
        {
            // Kunden des ausgewählten Landes
            TreeViewItem landKnoten = sender as TreeViewItem;
            if (landKnoten != null)
            {
                landKnoten.Items.Clear();

                string land = landKnoten.Header.ToString();

                var qKunden = context.Customers.Where(cu => cu.Country == land);

                foreach (Customer customer in qKunden)
                {
                    TreeViewItem tviKunde = new TreeViewItem() { Header = customer.CompanyName, Tag = customer.CustomerID };
                    landKnoten.Items.Add(tviKunde);
                }

            }
        }
    }
}
