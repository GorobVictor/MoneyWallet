using Entity.Model.Interface;

namespace WebApi.Model.Dto
{
    public class UserAuth : IUserAuth
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
