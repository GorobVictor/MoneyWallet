using Core.Model.Enum;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Model.Dto
{
    public class GetSetSalary : Abstract.Base
    {
        public GetSetSalary()
        {
        }

        public GetSetSalary(GetSetSalary salary, int userId)
        {
            Id = salary.Id;
            Name = salary.Name;
            Description = salary.Description;
            Value = salary.Value;
            Currency = salary.Currency;
            SalaryType = salary.SalaryType;
            ValueToCurrency = salary.ValueToCurrency;
            UserId = userId;
        }

        [Description("Имя")]
        public string Name { get; set; }
        [Description("Описание")]
        public string Description { get; set; }
        [Description("Сумма")]
        public double Value { get; set; }
        [Description("Валюта")]
        public Currency Currency { get; set; }
        [Description("Тип")]
        public SalaryType SalaryType { get; set; }
        public int UserId { get; set; }
        public double ValueToCurrency { get; set; }
    }
}
