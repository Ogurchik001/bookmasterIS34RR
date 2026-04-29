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

            Title = "Добавление читателя";
            EditBtn.Visibility = Visibility.Collapsed;
            AddBtn.Visibility = Visibility.Visible;


            IDclientTb.Text = GenerateID();

        }
        public Add_Edit(Customer selectedCustomer)
        {
            InitializeComponent();
            
            _cities = App.GetContext().Cities.ToList();
            Title = "Редактирование читателя";
            EditBtn.Visibility = Visibility.Visible;
            AddBtn.Visibility = Visibility.Collapsed;
            IDclientTb.Text = selectedCustomer.Id;
            DataContext = selectedCustomer;
            
            LoadCities();
        }



        private void ZipCityCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

       

        private void AddCustomer()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(IDclientTb.Text)||
                    string.IsNullOrWhiteSpace(ClientNameTb.Text) ||
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
                            Id = IDclientTb.Text,
                            Name = ClientNameTb.Text,
                            Address = AddressClientTb.Text,
                            Phone = PhoneCustomerTb.Text,
                            Email = EmailCustomerTb.Text,
                            Zip = ZipCityTb.Text,
                            CityId = Convert.ToInt32(ZipCityCmb.SelectedValue)
                        };
                        App.GetContext().Customers.Add(newCustomer);
                        App.GetContext().SaveChanges();
                        FeedbackService.Information("Пользователь успешно создан");
                        DialogResult = true;
                        Close();
                        
                        
                        
                        
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
            EditCustomer();
          
        }
        private void EditCustomer()
        {
            try
            {

                App.GetContext().SaveChanges();
                FeedbackService.Information("Данные читателя успешно изменены!");
            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer();
        }
        private string GenerateID()
        {
            int lastId = Convert.ToInt32(App.GetContext().Customers.Max(x => x.Id).Substring(1));
            ++lastId;



            return $"C{lastId}";
        }
    }
}
