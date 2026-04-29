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
using static System.Reflection.Metadata.BlobBuilder;

namespace bookmasterIS34RR.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {

        //Создадим список для вытягивания данных из таблиц
        private readonly List<Book> _bookAuthors;

        private Book _selectedBook;
        public BrowseCatalogPage()
        {
            InitializeComponent();

            //Заполняем локальный список
            _bookAuthors = App.GetContext().Books.ToList();

            LoadData();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsLv.ItemsSource = _bookAuthors.Where(book => book.Title.ToLower().Contains(NameTb.Text.ToLower()) &&
                                                           book.Authors.ToLower().Contains(AuthorsTb.Text.ToLower()) &&
                                                           book.Subjects.ToLower().Contains(SubjectTb.Text.ToLower()))
                                                           .ToList();
        }


        private void LoadData()
        {
            BookAuthorsLv.ItemsSource = _bookAuthors;
        }

        private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookAutorsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = (Book)BookAuthorsLv.SelectedItem;

            BookDetailsGrid.DataContext = _selectedBook;
        }

        private void BookAutorsDetailisHl_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null)
            {
                BookAuthorsDetailWindow bookAuthorsDetailsWindow =
                    new BookAuthorsDetailWindow(_selectedBook.BookAuthors);

                bookAuthorsDetailsWindow.ShowDialog();
            }
        }

        private void PageNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}