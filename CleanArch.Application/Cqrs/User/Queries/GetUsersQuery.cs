using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.User.Queries
{
    public class GetUsersQuery : IRequest<ApiResponse<List<UserDto>>>
    {
        public bool Status { get; set; }
    }
    public class GetUsersQueriesHandler : IRequestHandler<GetUsersQuery, ApiResponse<List<UserDto>>>
    {
        private readonly IUserService _userService;
        public GetUsersQueriesHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<ApiResponse<List<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsers(request, cancellationToken);
        }
    }
}
