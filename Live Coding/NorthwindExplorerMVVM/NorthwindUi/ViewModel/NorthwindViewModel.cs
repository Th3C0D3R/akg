using NorthwindDal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NorthwindUi
{
    public class NorthwindViewModel
    {
        NorthwindContext context = new NorthwindContext();

        public NorthwindViewModel()
        {
            var q = context.Customers.GroupBy(cu => cu.Country);
            this.Customers = new ObservableCollection<IGrouping<string, Customer>>(q.ToList());

            NewCustomerCommand = new RelayCommand(p => CanNewCustomer(), a => NewCustomer());
            EditCustomerCommand = new RelayCommand(p => CanEditCustomer(), a => EditCustomer());
        }

        private bool CanEditCustomer()
        {
            return SelectedCustomer != null;
        }

        private void EditCustomer()
        {
            // RequestAddEditCustomer(); löst ViewRequested-Event aus, dass die benötigte View bei einem ViewManager order dergl. anfordert.
            Customer kunde = this.SelectedCustomer;

            if (kunde != null)
            {
                AddEditKunde editKunde = new AddEditKunde(kunde);
                if (editKunde.ShowDialog() == true)
                {
                    context.SaveChanges();

                }
            }
        }

        private bool CanNewCustomer()
        {
            return true;
        }

        private void NewCustomer()
        {
            // RequestAddEditCustomer(); löst ViewRequested-Event aus, dass die benötigte View bei einem ViewManager order dergl. anfordert.
            Customer neuerKunde = new Customer();

            AddEditKunde addKunde = new AddEditKunde(neuerKunde);

            if (addKunde.ShowDialog() == true)
            {
                context.Customers.Add(neuerKunde);
                context.SaveChanges();

                // TODO: Neuer Kunde in den Baum + auswählen
            }

        }

        public ObservableCollection<IGrouping<string, Customer>> Customers { get; set; }

        public Customer SelectedCustomer { get; set; }

        public RelayCommand NewCustomerCommand { get; set; }
        public RelayCommand EditCustomerCommand { get; set; }
    }
}
