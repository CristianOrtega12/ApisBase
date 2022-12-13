using Domain.Models.Campaign;
using Domain.Models.Rol;
using Domain.Models.User;
using Domain.Models.UsersCampaigns;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Campaign> CampaignRepository { get; }
        IRepository<Rol> RolRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<UserRol> UserRolRepository { get; }
        IRepository<UsersCampaigns> UsersCampaignsRepository { get; }
        


        void SaveChanges();
        Task SaveChangesAsync();

        string GetDbConnection();
    }
}
