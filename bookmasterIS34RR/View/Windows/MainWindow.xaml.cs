using bookmasterIS34RR.AppData;
using bookmasterIS34RR.Models;
using bookmasterIS34RR.View.Pages;
using bookmasterIS34RR.View.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bookmasterIS34RR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LoginMI_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            if (authorizationWindow.ShowDialog()==true)
            {
                LibraryMI.Visibility= Visibility.Visible;
                LoginMI.Visibility = Visibility.Collapsed;
                LogoutMI.Visibility = Visibility.Visible;
            }
        }

        private void LogoutMI_Click(object sender, RoutedEventArgs e)
        {
            LibraryMI.Visibility = Visibility.Collapsed;
            LoginMI.Visibility = Visibility.Collapsed;
            LogoutMI.Visibility = Visibility.Visible;
        }

        private void CloseMI_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BrowseCatalogMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BrowseCatalogPage());
        }

        private void ManageCustomersMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate( new ManageCustomersPage());
        }

        private void CirculationMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CirculationPage());

        }

        private void ReportsMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());

        }
    }
}