using Entity.Model.Abstract;
using Entity.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Model
{
    public class Costs : Date
    {
        public Costs()
        {
        }

        public Costs(string name, string description, double value, Currency currency, WasteType wasteType, int userId)
        {
            Name = name;
            Description = description;
            Value = value;
            Currency = currency;
            WasteType = wasteType;

            CreatedBy = userId;
            CreatedWhen = DateTime.Now;
            UpdatedBy = userId;
            UpdatedWhen = DateTime.Now;
        }

        public Costs(Costs costs, int userId)
        {
            Name = costs.Name;
            Description = costs.Description;
            Value = costs.Value;
            Currency = costs.Currency;
            WasteType = costs.WasteType;

            CreatedBy = userId;
            CreatedWhen = DateTime.Now;
            UpdatedBy = userId;
            UpdatedWhen = DateTime.Now;
        }

        [Description("Имя")]
        public string Name { get; set; }
        [Description("Описание")]
        public string Description { get; set; }
        [Description("Цена")]
        public double Value { get; set; }
        [Description("Валюта")]
        public Currency Currency { get; set; }
        [Description("Тип расраты")]
        public WasteType WasteType { get; set; }
    }
}
