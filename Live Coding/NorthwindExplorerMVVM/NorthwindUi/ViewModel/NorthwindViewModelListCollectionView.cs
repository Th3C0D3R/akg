using NorthwindDal;
using NorthwindUi.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace NorthwindUi
{
    public class NorthwindViewModelListCollectionView
    {
        NorthwindContext context = new NorthwindContext();

        public NorthwindViewModelListCollectionView()
        {
            // ListCollectionView zur Gruppierung und Sortierung von Datenstrukturen (flache Listen)
            ListCollectionView customers = new ListCollectionView(context.Customers.ToList());
            customers.GroupDescriptions.Add(new PropertyGroupDescription("Country"));
            customers.SortDescriptions.Add(new SortDescription("CompanyName", ListSortDirection.Ascending));
            // ListCollectionView als Property veröffentlichen
            this.Customers = customers;

            NewCustomerCommand = new RelayCommand(p => CanNewCustomer(), a => NewCustomer());
            EditCustomerCommand = new RelayCommand(p => CanEditCustomer(), a => EditCustomer());

            this.ButtonColor=ConsoleColor.

            //this.EditArea = new OrderInfo(null);
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

        public ListCollectionView Customers { get; set; }

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value;
                this.EditArea.Customer = value;
            }
        }

        public RelayCommand NewCustomerCommand { get; set; }
        public RelayCommand EditCustomerCommand { get; set; }


        public OrderInfo EditArea { get; set; }
        public ConsoleColor ButtonColor { get; set; }
    }
}
