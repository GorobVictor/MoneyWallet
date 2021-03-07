using Entity.Controller;
using Entity.Interface;
using Entity.Model;
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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        IUserRepository Users { get; set; } = new UserRepository(ConfigurationManager.ConnectionStrings["default"].ConnectionString);

        public Register()
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

        private async void btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            var check = Action.CheckBox(new List<TextBox>()
            {
                txtbox_Email,
                txtbox_Login,
                txtbox_Name,
                txtbox_Password,
                txtbox_Phone,
                txtbox_RepeatPassword,
                txtbox_Surname
            });

            if (!check)
            {
                MessageBox.Show("Нужно заполнить поля", "Ошибка");
                return;
            }

            if (txtbox_Password.Text != txtbox_RepeatPassword.Text)
            {
                MessageBox.Show("Повторите пароль", "Ошибка");
                return;
            }

            if(await Users.CheckLoginAsync(txtbox_Login.Text))
            {
                MessageBox.Show("Такой логин существует", "Ошибка");
                return;
            }

            await Users.AddUserAsync(new User(txtbox_Name.Text, txtbox_Surname.Text, txtbox_Login.Text, txtbox_Password.Text, txtbox_Email.Text, txtbox_Phone.Text));

            new Login().Show();

            this.Close();
        }
    }
}
