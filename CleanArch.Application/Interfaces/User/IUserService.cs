using Application.Common.Response;
using Application.Cqrs.User.Commands;
using Application.Cqrs.User.Queries;
using Application.DTOs.User;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.User
{
    public interface IUserService
    {
        Task<ApiResponse<UserDto>> PostUser(PostUserCommand request, CancellationToken cancellationToken);
        Task<ApiResponse<List<UserDto>>> GetUsers(GetUsersQuery request, CancellationToken cancellationToken);
    }
}

