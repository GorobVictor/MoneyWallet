using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Dto
{
    public class GetCurrency
    {
        public GetCurrency(double buy, double sell, DateTime oldReflesh)
        {
            Buy = buy;
            Sell = sell;
            OldReflesh = oldReflesh;
        }

        public double Buy { get; set; }
        public double Sell { get; set; }
        public DateTime OldReflesh { get; set; }
    }
}
