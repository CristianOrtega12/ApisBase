using Application.Common.Response;
using Application.DTOs.User;
using System.Threading.Tasks;

namespace Application.Interfaces.User
{
    public interface IUserService
    {
        Task<ApiResponse<UserDto>> PostUser(Domain.Models.User.User user);
    }
}
