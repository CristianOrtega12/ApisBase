using Application.Common.Response;
using Application.Core.Exceptions;
using Application.DTOs.User;
using Application.Interfaces.User;
using Application.ViewModel.Auth;
using CleanArch.Application.Interfaces.Auths;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.User.Commands
{
    public class PostUserCommand : IRequest<ApiResponse<UserDto>>
    {
        //Objeto o parametros que se mostraran en view y se recibiran
        public CommandUserDto User { get; set; }
    }


    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, ApiResponse<UserDto>>
    {
        // Se hace una instancia de la interfaz
        private readonly IUserService _userService;

        public PostUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResponse<UserDto>> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            //la interfaz accede al Metodo
            return await _userService.PostUser(request, cancellationToken);
        }
    }
}
