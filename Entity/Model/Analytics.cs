using Entity.Model.Abstract;
using Entity.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Model
{
    public class Analytics: Date
    {
        public TypeAnalytics TypeAnalytics { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
