using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.DomainObjects;
using MobileWorld.Core.Enums;
using MobileWorld.Domain.Entities;
using MobileWorld.Domain.Shared.Parameters;

namespace MobileWorld.Infra.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(TableNames.TbOrder);
            builder.Property(o => o.ClientId).IsRequired();
            builder.Property(o => o.TotalValue).HasPrecision(10, 2);
            builder.Property(o => o.Discount).HasPrecision(10, 2);

            builder.Ignore(o => o.Deleted);
        }
    }
}
