
using Application.Auth.Commands;
using Application.DTOs.User;
using Application.ViewModel.Auth;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces.Auths
{
    public interface IAuthService
    {
        Task<UserDto> GetUserByLogin(string login);
        Task<AuthViewModel> GetAuth(PostLoginCommand auth);
        Task<UserDto> GetUserById(Guid? Id);
    }
}
