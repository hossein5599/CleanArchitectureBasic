using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Blocks.Domain.Entities;

namespace CA.Blocks.Infrastructure.Data.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    //Fluent Api Configs
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        //builder.Property(t => t.Description)
        //    .HasMaxLength(1000)
        //    .IsRequired();
         //................................
    }
}