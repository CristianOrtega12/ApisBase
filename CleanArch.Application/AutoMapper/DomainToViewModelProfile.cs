using Application.DTOs;
using Application.DTOs.Campaign;
using Application.DTOs.Rol;
using Application.DTOs.User;
using Application.DTOs.UsersCampaigns;
using AutoMapper;
using Domain.Models.Campaign;
using Domain.Models.Rol;
using Domain.Models.User;
using Domain.Models.UsersCampaigns;

namespace CleanArch.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Campaign, CampaignDto>();
            CreateMap<UsersCampaigns, UsersCampaignsDto>();
            CreateMap<User, UserDto>();
            CreateMap<User, CommandUserDto>();
            CreateMap<UserRol, UserRolDto>();
            CreateMap<Rol, RolDto>();

        }
    }
}