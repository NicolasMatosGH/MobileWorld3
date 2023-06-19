using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using MobileWorld.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

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
