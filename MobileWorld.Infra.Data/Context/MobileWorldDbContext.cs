using Microsoft.EntityFrameworkCore;
using MobileWorld.Infra.Data.Mapping;


namespace MobileWorld.Infra.Data.Context
{

    public class MobileWorldDbContext : DbContext
    {
        public MobileWorldDbContext(DbContextOptions<MobileWorldDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new VoucherMap());

            base.OnModelCreating(modelBuilder);
        }
    }

}
