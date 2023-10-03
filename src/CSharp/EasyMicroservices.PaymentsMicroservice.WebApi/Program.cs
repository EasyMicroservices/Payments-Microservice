using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using EasyMicroservices.Payments.Interfaces;
using EasyMicroservices.Payments.Stripe.Providers;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Contexts;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = CreateBuilder(args);
            var build = await app.Build<PaymentContext>();
            build.MapControllers();
            build.Run();
        }

        static WebApplicationBuilder CreateBuilder(string[] args)
        {
            var app = StartUpExtensions.Create<PaymentContext>(args);
            app.Services.Builder<PaymentContext>();
            app.Services.AddTransient((serviceProvider) => new AppUnitOfWork(serviceProvider));
            app.Services.AddTransient(serviceProvider => new PaymentContext(serviceProvider.GetService<IEntityFrameworkCoreDatabaseBuilder>()));
            app.Services.AddTransient<IEntityFrameworkCoreDatabaseBuilder, DatabaseBuilder>();
            StartUpExtensions.AddWhiteLabel("Payments", "RootAddresses:WhiteLabel");
            return app;
        }

        public static async Task Run(string[] args, Action<IServiceCollection> use)
        {
            var app = CreateBuilder(args);
            use?.Invoke(app.Services);
            var build = await app.Build<PaymentContext>();
            build.MapControllers();
            build.Run();
        }
    }
}