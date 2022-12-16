using Application.Common.Response;
using Application.DTOs.User;
using Application.Interfaces.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.User.Commands
{
    public class PutUserCommand : IRequest<ApiResponse<UserDto>>
    {
        //Objeto o parametros que se mostraran en view y se recibiran
        public PutUserDto User { get; set; }
    }


    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, ApiResponse<UserDto>>
    {
        // Se hace una instancia de la interfaz
        private readonly IUserService _userService;

        public PutUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResponse<UserDto>> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            //la interfaz accede al Metodo
            return await _userService.PutUser(request, cancellationToken);
        }
    }
}
