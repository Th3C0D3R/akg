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
                    tviKunde.Selected += Kunde_Selected;
                    landKnoten.Items.Add(tviKunde);
                }

            }
        }

        private void Kunde_Selected(object sender, RoutedEventArgs e)
        {
            if (sender is TreeViewItem tviKunde)
            {
                string customerId = tviKunde.Tag.ToString();

                //var kunde = context.Customers.Where(cu => cu.CustomerID == customerId).FirstOrDefault();
                var kunde = context.Customers.Find(customerId);
                cbxOrders.ItemsSource = kunde?.Orders;

                //var orders = context.Orders.Where(od => od.CustomerID == customerId).Select(od => od.ID);
                //cbxOrders.ItemsSource = orders.ToList();

            }
        }

        private void btnKundeEdit_Click(object sender, RoutedEventArgs e)
        {
            if (trvKunden.SelectedItem != null)
            {
                if (((TreeViewItem)trvKunden.SelectedItem).Tag != null)
                {
                    string customerId = ((TreeViewItem)trvKunden.SelectedItem).Tag.ToString();
                    Customer kunde = context.Customers.Find(customerId);

                    if (kunde != null)
                    {
                        AddEditKunde editKunde = new AddEditKunde(kunde);
                        if (editKunde.ShowDialog() == true)
                        {
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        private void btnKundeNeu_Click(object sender, RoutedEventArgs e)
        {
            Customer neuerKunde = new Customer();

            AddEditKunde addKunde = new AddEditKunde(neuerKunde);
            if (addKunde.ShowDialog() == true)
            {
                context.Customers.Add(neuerKunde);
                context.SaveChanges();
            }
        }

        //private void cbxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int? a = null;
        //    //int b = a.HasValue ? a.Value : -1;
        //    int b = a ?? -1;


        //    int orderId = (int)(cbxOrders.SelectedItem ?? -1);

        //    var qOrderinfo = context.Order_Details.Where(od => od.OrderID == orderId)
        //                                          .Select(od => new { od.Quantity, od.Product.ProductName, od.UnitPrice, od.Discount });

        //    dgOrderInfo.ItemsSource = qOrderinfo.ToList();
        //}
    }
}
