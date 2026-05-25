using bookmasterIS34RR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookmasterIS34RR.AppData
{
    /// <summary>
    /// Обеспечивает навигацию между книгами.
    /// </summary>

    public class PaginationController
    {
        private List<Book> _books = new();

        private const int PAGE_SIZE = 50;

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int BookCount => _books.Count;

        public bool CanGoPrevious => CurrentPage > 1;


        public bool CanGoNext => CurrentPage < TotalPages;

        public void Load(List<Book> books)
        {
            _books = books ?? new List<Book>();

            TotalPages = BookCount == 0 ? 1 : (int)Math.Ceiling(BookCount / (double)PAGE_SIZE);

            CurrentPage = 1;
        }

        public void GoToPage(int page)
        {
            CurrentPage = Math.Clamp(page, 1, TotalPages);
        }
        public List<Book> GetCurrentPage()
        {
            return _books.Skip((CurrentPage - 1) * PAGE_SIZE).Take(50).ToList();
        }
    }
}
