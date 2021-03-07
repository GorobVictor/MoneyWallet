using Entity.Controller;
using Entity.Interface;
using Entity.Model;
using Entity.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        IUserRepository Users { get; set; } = new UserRepository(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        ICostsRepository Costs { get; set; } = new CostsRepository(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        private User User { get; set; }

        public Main(User user)
        {
            InitializeComponent();
            User = user;
            labl_NameSurname.Content = User.ToString();
            btn_Update_Click(null, null);
        }

        private void btn_Subscription_Click(object sender, RoutedEventArgs e)
        {
            tab_Subscription.IsSelected = true;
        }

        private void btn_OnceOnly_Click(object sender, RoutedEventArgs e)
        {
            tab_OnceOnly.IsSelected = true;
        }
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.Description;
            if (string.IsNullOrWhiteSpace(propertyDescriptor.Description))
            {
                e.Cancel = true;
            }
        }

        private async void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var Subscription = grid_Subscription.ItemsSource as List<Costs>;
            var OnceOnly = grid_OnceOnly.ItemsSource as List<Costs>;
            List<Costs> newList = new List<Costs>();

            foreach (var newObj in Subscription)
            {
                if (newObj.Id == 0)
                {
                    newList.Add(new Costs(newObj, User.Id));
                }
            }

            foreach (var newObj in OnceOnly)
            {
                if (newObj.Id == 0)
                {
                    newList.Add(new Costs(newObj, User.Id));
                }
            }

            if (newList.Count > 0)
            {
                await Costs.AddCostsAsync(newList);
            }

            await Costs.UpdateCostsAsync(Subscription);
            await Costs.UpdateCostsAsync(grid_OnceOnly.ItemsSource as List<Costs>);
            btn_Update_Click(sender, e);
        }

        private async void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            grid_Subscription.ItemsSource = await Costs.GetCostsAsync(User.Id, WasteType.Subscription);
            grid_OnceOnly.ItemsSource = await Costs.GetCostsAsync(User.Id, WasteType.OnceOnly);
        }
    }
}
