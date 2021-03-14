using Core.Model.Abstract;
using Core.Model.Dto;
using Core.Model.Enum;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Core.Model
{
    public class Costs : Date
    {
        public Costs()
        {
        }

        public Costs(Costs cost, GetSetCosts newCost, int userUpdated)
        {
            var now = DateTime.Now;

            Id = newCost.Id;
            Name = newCost.Name;
            Description = newCost.Description;
            Value = newCost.Value;
            Currency = newCost.Currency;
            WasteType = newCost.WasteType;
            UserId = newCost.UserId;
            CreatedBy = cost != null ? cost.CreatedBy : userUpdated;
            CreatedWhen = cost != null ? cost.CreatedWhen : now;

            UpdatedBy = userUpdated;
            UpdatedWhen = now;
        }

        public Costs(GetSetCosts newCost, int userUpdated)
        {
            var now = DateTime.Now;

            Id = 0;
            Name = newCost.Name;
            Description = newCost.Description;
            Value = newCost.Value;
            Currency = newCost.Currency;
            WasteType = newCost.WasteType;
            UserId = newCost.UserId;
            CreatedBy = userUpdated;
            CreatedWhen = now;

            UpdatedBy = userUpdated;
            UpdatedWhen = now;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public Currency Currency { get; set; }
        public WasteType WasteType { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
