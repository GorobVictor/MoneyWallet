using Core.Model;
using Core.Model.Dto;
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

        private void btn_Salary_Click(object sender, RoutedEventArgs e)
        {
            tab_Salary.IsSelected = true;
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

            var subscription = grid_Subscription.ItemsSource as List<GetSetCosts>;
            var onceOnly = grid_OnceOnly.ItemsSource as List<GetSetCosts>;
            var sumList = subscription.Concat(onceOnly).ToList();

            List<Costs> newList = new List<Costs>();

            for (int i = 0; i < sumList.Count(); i++)
            {
                if (sumList[i].Id == 0)
                {
                    sumList[i] = new GetSetCosts(sumList[i], User.Id);
                }
            }

            await MyRestClient.UpdateCostsAsync(sumList);

            var salarys = grid_Salary.ItemsSource as List<GetSetSalary>;

            for (int i = 0; i < salarys.Count(); i++)
            {
                if (salarys[i].Id == 0)
                {
                    salarys[i] = new GetSetSalary(salarys[i], User.Id);
                }
            }

            await MyRestClient.UpdateSalaryAsync(salarys);

            btn_Update_Click(sender, e);

            Enabled(true);
        }

        private async void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            var costs = await MyRestClient.GetCostsAsync();
            grid_Subscription.ItemsSource = costs.Where(x => x.WasteType == WasteType.Subscription).ToList();
            grid_OnceOnly.ItemsSource = costs.Where(x => x.WasteType == WasteType.OnceOnly).ToList();

            var salarys = await MyRestClient.GetSalaryAsync();
            grid_Salary.ItemsSource = salarys.ToList();

            string salary = salarys.Where(x => x.SalaryType == SalaryType.Fixed).Count() > 0
                ? $"ЗП: {salarys.Where(x => x.SalaryType == SalaryType.Fixed).Sum(x => x.ValueToCurrency)}" : string.Empty;

            if (!string.IsNullOrWhiteSpace(salary))
                salary += ", ";

            salary += salarys.Where(x => x.SalaryType == SalaryType.OnceOnly).Count() > 0 ?
                $"разовая ЗП: {salarys.Where(x => x.SalaryType == SalaryType.OnceOnly).Sum(x => x.ValueToCurrency)}" : string.Empty;

            labl_Salary.Content = salary;
        }

        private void Enabled(bool isEnabled)
        {
            grid_OnceOnly.IsEnabled = isEnabled;
            grid_Subscription.IsEnabled = isEnabled;
        }
    }
}
