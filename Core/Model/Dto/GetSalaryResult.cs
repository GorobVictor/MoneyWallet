using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Dto
{
    public class GetSalaryResult : Salary
    {
        public GetSalaryResult(Salary salary, double valueToCurrency)
            : base(salary.Name, salary.Description, salary.Value, salary.Currency, salary.SalaryType, salary.CreatedBy)
        {
            Id = salary.Id;
            ValueToCurrency = valueToCurrency;
        }

        public double ValueToCurrency { get; set; }
    }
}
