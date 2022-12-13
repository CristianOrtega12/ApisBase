using CleanArch.Infra.Data.Context;
using Domain.Interfaces;
using Domain.Models.Campaign;
using Domain.Models.Rol;
using Domain.Models.User;
using Domain.Models.UsersCampaigns;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbaiAplicationDBContext _ctx;
        public IRepository<UserRol> UserRolRepository => new BaseRepository<UserRol>(_ctx);
        public IRepository<User> UserRepository => new BaseRepository<User>(_ctx);
        public IRepository<Rol> RolRepository => new BaseRepository<Rol>(_ctx);
        public IRepository<Campaign> CampaignRepository => new BaseRepository<Campaign>(_ctx);
        public IRepository<UsersCampaigns> UsersCampaignsRepository => new BaseRepository<UsersCampaigns>(_ctx);

        public UnitOfWork(AbaiAplicationDBContext ctx)
        {
            _ctx = ctx;

        }

        public string GetDbConnection()
        {
            return _ctx.Database.GetDbConnection().ConnectionString;
        }


        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }




        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
