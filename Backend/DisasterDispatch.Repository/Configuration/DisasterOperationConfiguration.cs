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
    public class DisasterOperationConfiguration : IEntityTypeConfiguration<DisasterOperation>
    {
        public void Configure(EntityTypeBuilder<DisasterOperation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.DisasterCategory).WithMany(x=>x.DisasterOperations).HasForeignKey(x=>x.DisasterCategoryId);
            
        }
    }
}
