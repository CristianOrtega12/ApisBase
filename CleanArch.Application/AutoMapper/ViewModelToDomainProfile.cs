//using Application.Cqrs.Novelties.Queries;
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
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<CampaignDto, Campaign>();
            CreateMap<UsersCampaignsDto, UsersCampaigns>();
            CreateMap<UserDto, User>();
            CreateMap<UserRolDto, UserRol>();
            CreateMap<RolDto, Rol>();
        }
    }
}

