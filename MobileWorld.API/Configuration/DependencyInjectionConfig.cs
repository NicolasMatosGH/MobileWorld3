using MediatR;
using MobileWorld.Application.Interfaces;
using MobileWorld.Application.Services;
using MobileWorld.Domain.Interfaces;
using MobileWorld.Domain.Shared.Transaction;
using MobileWorld.Infra.Data.Context;
using MobileWorld.Infra.Data.Repositories;
using MobileWorld.Infra.Data.UoW;



namespace MobileWorld.API.Configuration


{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatr();
            services.AddRepositories();
            services.AddServices();
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            //Você deve adicionar para todos os projetos
            services.AddMediatR(AppDomain.CurrentDomain.Load("MobileWorld.Domain"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            //Você deve adicionar para todos os projetos
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MobileWorldDbContext>();

            //Altera para suas classes de repositório
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IVoucherAppService, VoucherAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IClientAppService, ClientAppService>();
        }
    }
}
