using bookmasterIS34RR.AppData;
using bookmasterIS34RR.Models;
using bookmasterIS34RR.View.Windows;
using bookmasterIS36RR.View.Windows;
using Castle.Core.Resource;
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

        private  List<Customer> _Customers;

        private Customer _selectedCustomer;
        public ManageCustomersPage()
        {
            InitializeComponent();

            _Customers = App.GetContext().Customers.ToList();

           LoadData();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameCutomerTb.Text != null || IdCustomerTb.Text != null)
            {
                CustomerLv.ItemsSource = _Customers.Where(customer => customer.Id.ToLower().Contains(IdCustomerTb.Text.ToLower()) &&
                                                    customer.Name.ToLower().Contains(NameCutomerTb.Text.ToLower())).ToList();
            }
            else 
            {
                FeedbackService.Error("Заполните хотя бы одно поле");
            }

            }
        

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer? selectedCustomer = CustomerLv.SelectedItem as Customer;
            if (selectedCustomer!=null)
            {
                Add_Edit add_Edit = new Add_Edit(selectedCustomer);
                add_Edit.ShowDialog();
                CustomerLv.ItemsSource = _Customers = App.GetContext().Customers.ToList();

            }
            else
            {
                FeedbackService.Error("Невозможно открыть окно для редактирования читателя. Сначала выберите его из списка.");


            }
            
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_Edit add_Edit = new Add_Edit();
           if(add_Edit.ShowDialog() == true)
            {
                CustomerLv.ItemsSource = _Customers = App.GetContext().Customers.ToList();
            }
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
