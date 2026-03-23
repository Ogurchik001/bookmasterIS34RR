using bookmasterIS34RR.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace bookmasterIS34RR.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookAuthorsDetailWindow.xaml
    /// </summary>
    public partial class BookAuthorsDetailWindow : Window
    {
        public BookAuthorsDetailWindow(ICollection<BookAuthor> bookAuthors)
        {
            InitializeComponent();
            AuthorsCmb.ItemsSource= bookAuthors;
            AuthorsCmb.DisplayMemberPath = "Author.Name";
            AuthorsCmb.SelectedIndex=0;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AuthorsCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext=AuthorsCmb.SelectedItem;
            if (AuthorsCmb.SelectedItem is BookAuthor bookAuthor)
            {
                if (string.IsNullOrWhiteSpace(bookAuthor.Author.Wikipedia))
                {
                    HyperLinkTbl.Visibility = Visibility.Collapsed;
                }
                else
                {
                    HyperLinkTbl.Visibility= Visibility.Visible;
                }
            }

        }

        private void WikipediaHl_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true,
                    Verb = "Open"
                };

                Process.Start(processStartInfo);
                e.Handled= true;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
