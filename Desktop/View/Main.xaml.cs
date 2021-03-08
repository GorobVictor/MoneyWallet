using Core.Model;
using Core.Model.Enum;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
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
            Enabled(false);

            var subscription = grid_Subscription.ItemsSource as List<Costs>;
            var onceOnly = grid_OnceOnly.ItemsSource as List<Costs>;
            var sumList = subscription.Concat(onceOnly).ToList();

            List<Costs> newList = new List<Costs>();

            for (int i = 0; i < sumList.Count(); i++)
            {
                if (sumList[i].Id == 0)
                {
                    sumList[i] = new Costs(sumList[i], User.Id);
                }
            }

            await MyRestClient.UpdateCostsAsync(sumList);

            btn_Update_Click(sender, e);

            Enabled(true);
        }

        private async void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            var response = await MyRestClient.GetCostsAsync();
            grid_Subscription.ItemsSource = response.Where(x => x.WasteType == WasteType.Subscription).ToList();
            grid_OnceOnly.ItemsSource = response.Where(x => x.WasteType == WasteType.OnceOnly).ToList();
        }

        private void Enabled(bool isEnabled)
        {
            grid_OnceOnly.IsEnabled = isEnabled;
            grid_Subscription.IsEnabled = isEnabled;
        }
    }
}
