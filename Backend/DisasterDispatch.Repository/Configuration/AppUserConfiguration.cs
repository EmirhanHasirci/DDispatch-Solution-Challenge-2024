using DisasterDispatch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Repository.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Surname).IsRequired();
            builder.Property(x=>x.Tc).IsRequired();
            builder.Property(x=>x.Email).IsRequired();                        
        }
    }
}
