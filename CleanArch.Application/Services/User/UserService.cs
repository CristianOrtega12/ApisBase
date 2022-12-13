using Application.Common.Response;
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

        public async Task<ApiResponse<List<UserDto>>> GetUser(int without)
        {
            var response = new ApiResponse<List<UserDto>>();

            try
            {
                var source = _unitOfWork.UserRepository.Get();
 
                response.Data = without == 1 ?  await source.ProjectTo<UserDto>(_autoMapper.ConfigurationProvider).ToListAsync()
                                              : await source.Where(x => x.Status).ProjectTo<UserDto>(_autoMapper.ConfigurationProvider).ToListAsync();

                response.Message = "OK";
                response.Result = true;                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al cargar los registros, UserService en el método GetUser, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        
        public async Task<ApiResponse<UserDto>> PostUser(Domain.Models.User.User user)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                user.CreatedBy = CreatedBy;
          
                response.Data = _autoMapper.Map<UserDto>(await _unitOfWork.UserRepository.Add(user));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, UserService en el método PostUser, { ex.Message } ");             
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;


        }
    }
}
