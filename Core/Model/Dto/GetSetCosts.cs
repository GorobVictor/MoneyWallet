using Core.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Model.Dto
{
    public class GetSetCosts : Abstract.Base
    {
        public GetSetCosts()
        {
        }

        public GetSetCosts(GetSetCosts costs, int userId)
        {
            Id = costs.Id;
            Name = costs.Name;
            Description = costs.Description;
            Value = costs.Value;
            Currency = costs.Currency;
            WasteType = costs.WasteType;
            UserId = userId;
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

        public int UserId { get; set; }
    }
}
