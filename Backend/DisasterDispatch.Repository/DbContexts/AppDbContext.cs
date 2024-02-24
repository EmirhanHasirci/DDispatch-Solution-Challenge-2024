using DisasterDispatch.Core.Entities;
using DisasterDispatch.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Repository.DbContexts
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole,string,IdentityUserClaim<string>,AppUserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);            
            base.OnModelCreating(builder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityRefference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            Entry(entityRefference).Property(x => x.UpdatedDate).IsModified = false;
                            entityRefference.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            Entry(entityRefference).Property(x => x.CreatedDate).IsModified = false;
                            entityRefference.UpdatedDate = DateTime.Now; break;
                    }
                }
            }
            return base.SaveChangesAsync();
        }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<Certificate> Certificates{ get; set; }
        public DbSet<DisasterCategory> DisasterCategories{ get; set; }
        public DbSet<DisasterOperation> DisasterOperations{ get; set; }
        public DbSet<EmergencyReport> EmergencyReports{ get; set; }
        public DbSet<CustomOperation> CustomOperations{ get; set; }
        public DbSet<OperationEmployee>  OperationEmployees{ get; set; }        
        public DbSet<PhoneNumber>  PhoneNumbers{ get; set; }
        public DbSet<Skill>  Skills{ get; set; }
        public DbSet<SkillCategory>  SkillCategories{ get; set; }
        public DbSet<Title>  Titles{ get; set; }
        public DbSet<TitleType>  TitleTypes{ get; set; }
        public DbSet<Contact>  Contacts{ get; set; }
        public DbSet<Needer>  Needers{ get; set; }
        public DbSet<Notification>  Notifications{ get; set; }
        public DbSet<NotificationUser> NotificationUsers  { get; set; }
    }
}
