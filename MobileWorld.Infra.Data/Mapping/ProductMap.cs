﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Domain.Entities;
using MobileWorld.Domain.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableNames.TbProduct);
            builder.Property(p => p.Brand).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Model).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(240);
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.Price).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(200);
            builder.Property(p => p.DateRegister).HasDefaultValue(DateTime.Now);

            builder.Ignore(p => p.Deleted);
        }
    }
}
