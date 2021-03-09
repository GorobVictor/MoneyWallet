using Core.Model.Abstract;
using Core.Model.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Salary : Date
    {
        public Salary()
        {
        }

        public Salary(string name, string description, double value, Currency currency, SalaryType salaryType, int userId)
        {
            Name = name;
            Description = description;
            Value = value;
            Currency = currency;
            SalaryType = salaryType;
            UserId = userId;

            var now = DateTime.Now;

            CreatedWhen = now;
            CreatedBy = userId;
            UpdatedWhen = now;
            UpdatedBy = userId;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public Currency Currency { get; set; }
        public SalaryType SalaryType { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public override string ToString()
        {
            return $"{Value} {Currency}";
        }
    }
}
