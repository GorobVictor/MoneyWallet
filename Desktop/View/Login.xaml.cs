using Entity.Controller;
using Entity.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        IUserRepository Users { get; set; } = new UserRepository(ConfigurationManager.ConnectionStrings["default"].ConnectionString);

        public Login()
        {
            InitializeComponent();
        }

        private void MyGotFocus(object sender, RoutedEventArgs e)
        {
            Action.MyGotFocus(sender as TextBox);
        }

        private void MyLostFocus(object sender, RoutedEventArgs e)
        {
            Action.MyLostFocus(sender as TextBox);
        }

        private async void btn_Authorization_Click(object sender, RoutedEventArgs e)
        {

            var check = Action.CheckBox(new List<TextBox>()
           {
               txtbox_Login,
               txtbox_Password
           });

            if (!check)
            {
                MessageBox.Show("Нужно заполнить поля", "Ошибка");
                return;
            }

            var user = await Users.GetUserByLoginAndPasswordAsync(new User(txtbox_Login.Text, txtbox_Password.Text));

            if (user != null)
            {
                new Main(user).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка");
            }
        }

        private void btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            new Register().Show();
            this.Close();
        }
    }
}
