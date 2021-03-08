using Entity.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity.Model
{
    public class MoneyWalletContext : DbContext
    {
        private string ConnectionString { get; set; }
        public MoneyWalletContext(string connectionString)
        {
            ConnectionString = connectionString;

            UpdateBase();
        }
        public MoneyWalletContext(DbContextOptions<MoneyWalletContext> options)
            : base(options)
        {
            UpdateBase();
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

            Users.Add(new User("Name", "Surname", "Admin", "admin", "gmail.com", "380636655888"));

            SaveChanges();

            var user = Users.FirstOrDefault(x => x.Login == "Admin");

            Costs.Add(new Costs()
            {
                CreatedBy = user.Id,
                CreatedWhen = DateTime.Now,
                UpdatedBy = user.Id,
                UpdatedWhen = DateTime.Now,
                Name = "YouTube",
                Description = "ютуб",
                Value = 6,
                Currency = Currency.USD,
                WasteType = WasteType.Subscription,
                Deleted = false
            });
            Costs.Add(new Costs()
            {
                CreatedBy = user.Id,
                CreatedWhen = DateTime.Now,
                UpdatedBy = user.Id,
                UpdatedWhen = DateTime.Now,
                Name = "Dezzer",
                Description = "дизер",
                Value = 6,
                Currency = Currency.EUR,
                WasteType = WasteType.Subscription,
                Deleted = false
            });
            Costs.Add(new Costs()
            {
                CreatedBy = user.Id,
                CreatedWhen = DateTime.Now,
                UpdatedBy = user.Id,
                UpdatedWhen = DateTime.Now,
                Name = "Сильпо",
                Description = "продукты",
                Value = 550,
                Currency = Currency.UAH,
                WasteType = WasteType.OnceOnly,
                Deleted = false
            });
            Costs.Add(new Costs()
            {
                CreatedBy = user.Id,
                CreatedWhen = DateTime.Now,
                UpdatedBy = user.Id,
                UpdatedWhen = DateTime.Now,
                Name = "Ноготки",
                Description = "ноготки",
                Value = 300,
                Currency = Currency.UAH,
                WasteType = WasteType.OnceOnly,
                Deleted = false
            });

            SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Costs> Costs { get; set; }
        public DbSet<Analytics> Analytics { get; set; }
    }
}
