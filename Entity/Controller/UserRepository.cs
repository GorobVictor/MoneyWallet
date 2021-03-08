using Entity.Interface;
using Core.Model;
using Core.Model.Interface;
using System.Threading.Tasks;

namespace Entity.Controller
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MoneyWalletContext context)
            : base(context)
        {

        }

        public async Task<bool> CheckLoginAndPasswordAsync(User user)
        {
            if (await GetFirst(x =>
                    x.Login.ToLower() == user.Login.ToLower() &&
                    x.Password.ToLower() == user.Password.ToLower()
                    ) == null)
                return false;

            return true;
        }

        public async Task<User> GetUserByLoginAndPasswordAsync(User user)
        {
            return await GetFirst(x =>
                    x.Login.ToLower() == user.Login.ToLower() &&
                    x.Password.ToLower() == user.Password.ToLower()
                    );
        }

        public async Task<User> GetUserByLoginAndPasswordAsync(IUserAuth user)
        {
            return await GetFirst(x =>
                    x.Login.ToLower() == user.Login.ToLower() &&
                    x.Password.ToLower() == user.Password.ToLower()
                    );
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await GetFirst(x => x.Id == userId);
        }

        public async Task<bool> CheckLoginAsync(string login)
        {
            if (await GetFirst(x =>
                    x.Login.ToLower() == login.ToLower()
                    ) == null)
                return false;

            return true;
        }

        public async Task AddUserAsync(User user)
        {
            await AddAsync(user);
        }
    }
}
