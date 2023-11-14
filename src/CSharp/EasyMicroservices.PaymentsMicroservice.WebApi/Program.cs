using EasyMicroservices.Cores.AspEntityFrameworkCoreApi;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Contexts;
using EasyMicroservices.PaymentsMicroservice.Helpers;
using EasyMicroservices.PaymentsMicroservice.Interfaces;

namespace EasyMicroservices.PaymentsMicroservice.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = CreateBuilder(args);
            var build = await app.Build<PaymentContext>(true);
            build.MapControllers();
            await build.RunAsync();
        }

        static WebApplicationBuilder CreateBuilder(string[] args)
        {
            var app = StartUpExtensions.Create<PaymentContext>(args);
            app.Services.Builder<PaymentContext>();
            app.Services.AddTransient<IAppUnitOfWork>((serviceProvider) => new AppUnitOfWork(serviceProvider));
            app.Services.AddTransient(serviceProvider => new PaymentContext(serviceProvider.GetService<IEntityFrameworkCoreDatabaseBuilder>()));
            app.Services.AddTransient<IEntityFrameworkCoreDatabaseBuilder, DatabaseBuilder>();
            StartUpExtensions.AddWhiteLabel("Payments", "RootAddresses:WhiteLabel");
            return app;
        }

        public static async Task Run(string[] args, Action<IServiceCollection> use, Action<IServiceProvider> serviceProvider)
        {
            var app = CreateBuilder(args);
            use?.Invoke(app.Services);
            var build = await app.Build<PaymentContext>();
            build.MapControllers();
            serviceProvider(build.Services);
            await build.RunAsync();
        }
    }
}