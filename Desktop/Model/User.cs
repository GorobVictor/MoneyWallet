using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    class User : IUserAuth
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
