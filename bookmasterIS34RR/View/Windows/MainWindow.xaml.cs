using bookmasterIS34RR.Models;
using bookmasterIS34RR.View.Pages;
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

        }

        private void LogoutMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseMI_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BrowseCatalogMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BrowseCatalogPage());
        }

        private void ManageCustomerMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CirculationMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReportsMI_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}