using bookmasterIS34RR.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace bookmasterIS34RR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BookmasterEgorRis34Context _context;
        public static BookmasterEgorRis34Context GetContext() 
        {
            if (_context == null)
            {
                _context=new BookmasterEgorRis34Context();
            }
            return _context;
        }

    }

}
