using Daxone_API.Models;
using Daxone_API.ViewModels.Client.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daxone_API.Services.Client.Users
{
    public interface IUserService
    {
        Task<User> Login(UserLoginViewModel userLoginViewModel);

        Task<int> Register(UserRegisterViewModel userRegisterViewModel);
    }
}