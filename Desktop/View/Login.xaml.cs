using RestSharp;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static RestClient Client { get; set; } = new RestClient("https://localhost:44312/api");
        public static string Token { get; set; }
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

            var request = new RestRequest("login", RestSharp.DataFormat.Json)
                .AddJsonBody(new { login = txtbox_Login.Text, password = txtbox_Password.Text });

            var response = await Client.PostAsync<>(request);


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
