using Core.Model.Interface;

namespace Core.Model.Dto
{
    public class UserAuth : IUserAuth
    {
        public UserAuth()
        {
        }

        public UserAuth(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
