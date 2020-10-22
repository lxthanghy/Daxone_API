using Daxone_API.Models;
using Daxone_API.ViewModels.Client.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.Users
{
    public class UserService : IUserService
    {
        private readonly DaxoneDBContext _daxoneDBContext;

        public UserService(DaxoneDBContext daxoneDBContext)
        {
            _daxoneDBContext = daxoneDBContext;
        }

        public async Task<User> Login(UserLoginViewModel userLoginViewModel)
        {
            var user = await _daxoneDBContext.Users.FirstOrDefaultAsync(u => u.Username == userLoginViewModel.Username && u.Password == userLoginViewModel.Password);
            return user;
        }

        public async Task<int> Register(UserRegisterViewModel userRegisterViewModel)
        {
            User user = new User()
            {
                Username = userRegisterViewModel.Username,
                Password = userRegisterViewModel.Password,
                Address = userRegisterViewModel.Address,
                Email = userRegisterViewModel.Email,
                Phone = userRegisterViewModel.Phone
            };
            _daxoneDBContext.Users.Add(user);
            int res = await _daxoneDBContext.SaveChangesAsync();
            return res;
        }
    }
}