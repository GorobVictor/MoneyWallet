using Core.Model.Abstract;
using Core.Model.Dto;
using Core.Model.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Model
{
    public class Salary : Date
    {
        public Salary()
        {
        }

        public Salary(Salary salary, GetSetSalary newSalary, int userUpdated)
        {
            var now = DateTime.Now;

            Id = newSalary.Id;
            Name = newSalary.Name;
            Description = newSalary.Description;
            Value = newSalary.Value;
            Currency = newSalary.Currency;
            SalaryType = newSalary.SalaryType;
            UserId = newSalary.UserId;
            CreatedBy = salary != null ? salary.CreatedBy : userUpdated;
            CreatedWhen = salary != null ? salary.CreatedWhen : now;

            UpdatedBy = userUpdated;
            UpdatedWhen = now;
        }

        public Salary(GetSetSalary newSalary, int userUpdated)
        {
            var now = DateTime.Now;

            Id = newSalary.Id;
            Name = newSalary.Name;
            Description = newSalary.Description;
            Value = newSalary.Value;
            Currency = newSalary.Currency;
            SalaryType = newSalary.SalaryType;
            UserId = newSalary.UserId;
            CreatedBy = userUpdated;
            CreatedWhen = now;

            UpdatedBy = userUpdated;
            UpdatedWhen = now;
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
