using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MobileWorld.Domain.Interfaces;
using MobileWorld.Infra.Data.Repositories;

namespace MobileWorld.Infra.CrossCutting.IoC
{
    public static class Container
    {

        public static IServiceCollection AddNativeInjectorBootStrapper(this IServiceCollection services)
        {
            return services;
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("MobileWorld.Domain"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
        }
    }
}
