using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Cqrs.User.Queries
{
    public class GetUsersByIdQuery : IRequest<ApiResponse<UserDto>>
    {
        public Guid Id { get; set; }
    }
    public class GetUsersByIdQueriesHandler : IRequestHandler<GetUsersByIdQuery, ApiResponse<UserDto>>
    {
        private readonly IUserService _userService;
        public GetUsersByIdQueriesHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<ApiResponse<UserDto>> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserById(request, cancellationToken);
        }

        public Task<ApiResponse<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
