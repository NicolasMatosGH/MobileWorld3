using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Domain.Entities;
using MobileWorld.Domain.Shared.Parameters;


namespace MobileWorld.Infra.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(TableNames.TbClient);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Cpf).HasMaxLength(14).IsRequired();
            builder.Property(c => c.Active).HasDefaultValue(true);
            builder.Property(c => c.AddressId).IsRequired();

            builder.Ignore(c => c.Deleted);
        }
    }
}
