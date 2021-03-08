using Entity.Model.Abstract;
using Entity.Model.Enum;

namespace Entity.Model
{
    public class User : Base
    {
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User(string name, string surname, string login, string password, string email, string phone)
            : this(login, password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
