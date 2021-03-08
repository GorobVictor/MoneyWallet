using Core.Model;
using Core.Model.Interface;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> CheckLoginAndPasswordAsync(User user);
        Task<User> GetUserByLoginAndPasswordAsync(User user);
        Task<User> GetUserByLoginAndPasswordAsync(IUserAuth user);
        Task<User> GetUserByIdAsync(int userId);
        Task<bool> CheckLoginAsync(string login);
        Task AddUserAsync(User user);
    }
}
