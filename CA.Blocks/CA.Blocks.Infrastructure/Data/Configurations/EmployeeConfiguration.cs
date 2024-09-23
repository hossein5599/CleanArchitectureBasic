using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Blocks.Domain.Entities;

namespace CA.Blocks.Infrastructure.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    //Fluent Api Configs
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        //builder.Property(t => t.FirstName)
        //    .HasMaxLength(200)
        //    .IsRequired();

        //......................
    }
}