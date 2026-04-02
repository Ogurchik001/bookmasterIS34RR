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

namespace bookmasterIS34RR.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                Administrator administrator = App.GetContext().Administrators.FirstOrDefault(administrator => administrator.Username == LoginTb.Text && administrator.Password == PasswordPb.Password);

                if (administrator != null) 
                {
                    FeedbackService.Information("Успешная авторизация.");
                    DialogResult = true;
                }
                else
                {
                    FeedbackService.Error("Пользователь не найден.");
                }
            }
            

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                FeedbackService.Warning("Введите логин");
                LoginTb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                FeedbackService.Warning("Введите пароль");
                PasswordPb.Focus();
                return false;
            }
            return true;
        }
    }
}
