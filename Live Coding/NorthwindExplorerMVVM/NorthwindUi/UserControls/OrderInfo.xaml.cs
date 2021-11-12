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

namespace NorthwindUi.UserControls
{
    /// <summary>
    /// Interaction logic for OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : UserControl
    {
        OrderInfoViewModel viewModel;

        public OrderInfo()
        {
            InitializeComponent();
        }

        public OrderInfo(Customer customer)
        {
            InitializeComponent();

            viewModel = new OrderInfoViewModel(customer);

            if (customer != null)
            {
                this.Customer = customer;
            }

            this.DataContext = viewModel;
        }

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                viewModel.Customer = value;
            }
        }

    }


}


