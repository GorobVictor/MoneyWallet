﻿using Entity.Model;
using Entity.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> CheckLoginAndPasswordAsync(User user);
        Task<User> GetUserByLoginAndPasswordAsync(User user);
        Task<User> GetUserByLoginAndPasswordAsync(IUserAuth user);
        Task<bool> CheckLoginAsync(string login);
        Task AddUserAsync(User user);
    }
}
