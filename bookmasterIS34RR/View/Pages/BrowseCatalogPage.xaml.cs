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
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        //Создаем локальный список для единоразового вытягивания данных из таблицы БД
        private readonly List<Book> _books;
        private Book _selectedBook;

        public BrowseCatalogPage()
        {
            InitializeComponent();
            _books=App.GetContext().Books.ToList();
            LoadData();
           
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LoadData()
        {
           BookAuthorLv.ItemsSource = _books;
        }
        private void NextCoverBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookAuthorsDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsDetailWindow bookAuthorsDetailWindow = new BookAuthorsDetailWindow(_selectedBook.BookAuthors);
            bookAuthorsDetailWindow.ShowDialog();
        }

        private void BookAuthorLv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = (Book)BookAuthorLv.SelectedItem;
            BookDetailGrid.DataContext = _selectedBook;
        }
    }
}
