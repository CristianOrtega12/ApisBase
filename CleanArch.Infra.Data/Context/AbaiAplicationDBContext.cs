using CleanArchitecture.Application.Common.Interfaces;
using Core.Models.Common;
using Domain.Models.Campaign;
using Domain.Models.Rol;
using Domain.Models.User;
using Domain.Models.UsersCampaigns;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Context
{
    public class AbaiAplicationDBContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public AbaiAplicationDBContext(
            DbContextOptions options,
            ICurrentUserService currentUserService
            ) : base(options)
        {
            _currentUserService = currentUserService;
        }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersCampaigns> UsersCampaigns { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var UserInfo = _currentUserService.GetUserInfo();
            var userName = string.Concat(UserInfo.Name, " ", UserInfo.LastName);

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity> entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.Id;
                        entry.Entity.CreatedByName = userName;
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.Id;
                        entry.Entity.UpdatedByName = userName;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.UpdatedByName = userName;
                        entry.Entity.UpdatedBy = _currentUserService.Id;
                        break;
                }
            }


            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<EntityWithIntId> entry in ChangeTracker.Entries<EntityWithIntId>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.Id;
                        entry.Entity.LastCreatedByName = userName;
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.Id;
                        entry.Entity.LastUpdatedByName = userName;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.LastUpdatedByName = userName;
                        entry.Entity.UpdatedBy = _currentUserService.Id;
                        break;
                }
            }




            var result = await base.SaveChangesAsync(cancellationToken);


            return result;
        }
    }
}
