using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Model.Abstract
{
    public class Date : Base
    {
        public DateTime CreatedWhen { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedWhen { get; set; }
        public int UpdatedBy { get; set; }
    }
}
