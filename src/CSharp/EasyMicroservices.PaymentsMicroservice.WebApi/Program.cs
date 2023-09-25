using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Contexts;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.WebApi
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var app = StartUpExtensions.Create<PaymentContext>(args);
            app.Services.Builder<PaymentContext>();
            app.Services.AddScoped((serviceProvider) => new UnitOfWork(serviceProvider));
            app.Services.AddScoped((serviceProvider) => serviceProvider.GetService<IUnitOfWork>().GetLongContractLogic<InvoiceEntity, CreateInvoiceRequestContract, UpdateInvoiceRequestContract, InvoiceContract>());
            app.Services.AddScoped((serviceProvider) => serviceProvider.GetService<IUnitOfWork>().GetLongContractLogic<InvoiceStatusHistoryEntity, CreateInvoiceStatusHistoryRequestContract, UpdateInvoiceStatusHistoryRequestContract, InvoiceStatusHistoryContract>());
            app.Services.AddScoped((serviceProvider) => serviceProvider.GetService<IUnitOfWork>().GetLongContractLogic<ProductEntity, CreateProudctRequestContract, UpdateProudctRequestContract, ProductContract>());
            app.Services.AddScoped((serviceProvider) => serviceProvider.GetService<IUnitOfWork>().GetLongContractLogic<ServiceAddressEntity, CreateServiceAddressRequestContract, UpdateServiceAddressRequestContract, ServiceAddressContract>());
            app.Services.AddScoped((serviceProvider) => serviceProvider.GetService<IUnitOfWork>().GetLongContractLogic<ServiceEntity, CreateServiceRequestContract, UpdateServiceRequestContract, ServiceContract>());
            app.Services.AddTransient(serviceProvider => new PaymentContext(serviceProvider.GetService<IEntityFrameworkCoreDatabaseBuilder>()));
            app.Services.AddScoped<IEntityFrameworkCoreDatabaseBuilder>(serviceProvider => new DatabaseBuilder());
            StartUpExtensions.AddWhiteLabel("Ordering", "RootAddresses:WhiteLabel");

            var build = await app.Build<PaymentContext>();
            build.MapControllers();
            build.Run();
        }
    }
}