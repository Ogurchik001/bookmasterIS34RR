using bookmasterIS34RR;
using bookmasterIS34RR.AppData;
using bookmasterIS34RR.Models;
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

namespace bookmasterIS36RR.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add_Edit.xaml
    /// </summary>
    public partial class Add_Edit : Window
    {
        private Customer _selectedCustomer;
        List<Customer> customers;
        private List <City> _cities;
        public Add_Edit()
        {
            InitializeComponent();
            _cities = App.GetContext().Cities.ToList();
            LoadCities();
        }
       


        private void ZipCityCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            AddCustomer();
        }

        private void AddCustomer()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ClientNameTb.Text) ||
                string.IsNullOrWhiteSpace(AddressClientTb.Text) ||
                string.IsNullOrWhiteSpace(PhoneCustomerTb.Text)||
                string.IsNullOrWhiteSpace(EmailCustomerTb.Text))
                {
                    FeedbackService.Warning("Заполните все поля!");
                }
                else
                {
                    {
                        Customer newCustomer = new Customer()
                        {
                            
                            Name= ClientNameTb.Text,
                            Address = AddressClientTb.Text,
                            Phone= PhoneCustomerTb.Text,
                            Email = EmailCustomerTb.Text,
                            Zip = ZipCityTb.Text,
                            CityId = Convert.ToInt32(ZipCityCmb.SelectedValue)
                        };
                        App.GetContext().Customers.Add(newCustomer);
                        FeedbackService.Information("Пользователь успешно создан");
                        Close();
                        App.GetContext().SaveChanges();
                        
                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex);
            }
        }

        private void LoadCities()
        {
            ZipCityCmb.ItemsSource = _cities;
            
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            FeedbackService.Information("Изменения успешно сохранены");
            App.GetContext().SaveChanges();
        }
    }
}
