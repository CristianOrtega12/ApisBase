using Application.Common.Response;
using Application.Cqrs.User.Commands;
using Application.Cqrs.User.Queries;
using Application.DTOs.User;
using Application.Interfaces.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.User
{

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger _logger;

        private Guid? CreatedBy = null;
        private Guid? UpdatedBy = null;
        public UserService(ICurrentUserService currentUser, IUnitOfWork unitOfWork, IMapper autoMapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _autoMapper = autoMapper;
            CreatedBy = _currentUser.GetUserInfo().Id;
            UpdatedBy = _currentUser.GetUserInfo().Id;
            _logger = logger;


        }

        public async Task<ApiResponse<List<UserDto>>> GetUsers(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<UserDto>>();
            try
            {
                response.Data = _autoMapper.Map<List<UserDto>>(await _unitOfWork.UserRepository.Get()
                                                                                                   .Where(x => x.Status == request.Status)
                                                                                                   .ToListAsync());
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
                throw;
            }
            return response;
        }

        public async Task<ApiResponse<UserDto>> GetUserById(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<UserDto>();
                try
                {
                    response.Data = _autoMapper.Map<UserDto>(await _unitOfWork.UserRepository.GetById(request.Id));
                }
                catch (Exception ex)
                {
                    response.Result = false;
                    response.Message = $"Error al actualizar el obtener usuario por ID, consulte con el administrador. { ex.Message } ";
                    throw;
                }
                return response;
            }

        
        public async Task<ApiResponse<UserDto>> PostUser(PostUserCommand request, CancellationToken cancellationToken)
        {
            
            var response = new ApiResponse<UserDto>();
            try
            {
                response.Data = _autoMapper.Map<UserDto>(await _unitOfWork.UserRepository.Add(_autoMapper.Map<Domain.Models.User.User>(request.User)));
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
                throw;
            }
            return response;

        }

        public async Task<ApiResponse<UserDto>> PutUser(PutUserCommand request, CancellationToken cancellationToken)
        {

            var response = new ApiResponse<UserDto>();
            try
            {
                response.Data = _autoMapper.Map<UserDto>(await _unitOfWork.UserRepository.Put(_autoMapper.Map<Domain.Models.User.User>(request.User)));
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
                throw;
            }
            return response;

        }

        public async Task<ApiResponse<bool>> DeleteUser(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var response = new ApiResponse<bool>();
            try
            {
                response.Data = await _unitOfWork.UserRepository.Delete(_autoMapper.Map<Domain.Models.User.User>(request.User));
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
                throw;
            }
            return response;

        }

    }
}
