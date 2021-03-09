using Core.Model;
using Core.Model.Enum;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {

        public Register()
        {
            InitializeComponent();
            combo_Currency.ItemsSource = Enum.GetValues(typeof(Currency)).Cast<Currency>();
            combo_Currency.SelectedIndex = 0;
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

            if (await MyRestClient.CheckLoginAsync(txtbox_Login.Text))
            {
                MessageBox.Show("Такой логин существует", "Ошибка");
                return;
            }

            await MyRestClient.AddUserAsync(new User(txtbox_Name.Text, txtbox_Surname.Text, txtbox_Login.Text, txtbox_Password.Text, txtbox_Email.Text, txtbox_Phone.Text, (Currency)combo_Currency.SelectedItem ));

            new Login().Show();

            this.Close();
        }
    }
}
