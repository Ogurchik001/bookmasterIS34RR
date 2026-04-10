using bookmasterIS34RR.Models;
using bookmasterIS34RR.View.Windows;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

namespace bookmasterIS34RR.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {

        private readonly List<Customer> _Customers;

        private Customer _selectedCustomer;
        public ManageCustomersPage()
        {
            InitializeComponent();

            _Customers = App.GetContext().Customers.ToList();

           LoadData();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCustomer = (Customer)CustomerLv.SelectedItem;

              
        }
        private void LoadData()
        {
            CustomerLv.ItemsSource = _Customers;
        }
    }
}
