using DisasterDispatch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Repository.Configuration
{
    public class CustomOperationConfiguration : IEntityTypeConfiguration<CustomOperation>
    {
        public void Configure(EntityTypeBuilder<CustomOperation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.DisasterOperation).WithMany(x=>x.Operations).HasForeignKey(x=>x.DisasterOperationId);
            builder.HasOne(x => x.EmergencyReport).WithMany(x => x.CustomOperations).HasForeignKey(x => x.EmergencyReportId);
            builder.HasMany(x => x.Workers).WithMany(x => x.Operations);
            
        }
    }
}
