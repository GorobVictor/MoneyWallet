using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Model.Abstract
{
    public class Base
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
