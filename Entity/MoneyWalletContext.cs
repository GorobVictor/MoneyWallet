using Core.Model;
using Core.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Entity
{
    public class MoneyWalletContext : DbContext
    {
        private string ConnectionString { get; set; }
        public MoneyWalletContext(string connectionString)
        {
            ConnectionString = connectionString;

            //UpdateBase();
        }
        public MoneyWalletContext(DbContextOptions<MoneyWalletContext> options)
            : base(options)
        {
            //UpdateBase();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
                optionsBuilder.UseSqlServer(ConnectionString);
        }

        void UpdateBase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Users.Add(new User("Name", "Surname", "Admin", "admin", "gmail.com", "380636655888", Currency.UAH));

            SaveChanges();

            var user = Users.FirstOrDefault(x => x.Login == "Admin");

            //Costs.Add(new Costs("YouTube", "ютуб", 6,Currency.USD,WasteType.Subscription,user.Id));
            //Costs.Add(new Costs("Dezzer", "дизер", 6,Currency.USD,WasteType.Subscription,user.Id));
            //Costs.Add(new Costs("Сильпо", "продукты",550,Currency.UAH,WasteType.OnceOnly,user.Id));
            //Costs.Add(new Costs("Ноготки", "ноготки", 300,Currency.UAH,WasteType.OnceOnly,user.Id));

            //Salary.AddAsync(new Salary("ZP", "месячная зарплата", 1000, Currency.USD, SalaryType.Fixed, user.Id));
            //Salary.AddAsync(new Salary("Parser", "оплата за проект", 3000, Currency.UAH, SalaryType.OnceOnly, user.Id));

            SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Costs> Costs { get; set; }
        public DbSet<Analytics> Analytics { get; set; }
        public DbSet<Salary> Salary { get; set; }
    }
}
