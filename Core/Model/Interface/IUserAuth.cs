using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interface
{
    public interface IUserAuth
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
