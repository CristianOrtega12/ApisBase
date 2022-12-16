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
    public class DeleteUserCommand : IRequest<ApiResponse<bool>>
    {
        //Objeto o parametros que se mostraran en view y se recibiran
        public DeleteUserDto User { get; set; }
    }


    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ApiResponse<bool>>
    {
        // Se hace una instancia de la interfaz
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //la interfaz accede al Metodo
            return await _userService.DeleteUser(request, cancellationToken);
        }
    }
}
