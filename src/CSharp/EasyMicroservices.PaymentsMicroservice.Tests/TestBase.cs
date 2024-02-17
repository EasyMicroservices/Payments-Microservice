using EasyMicroservices.Payments.DataTypes;
using EasyMicroservices.Payments.VirtualServerForTests;
using EasyMicroservices.Payments.VirtualServerForTests.TestResources;
using EasyMicroservices.PaymentsMicroservice.Database.Contexts;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Interfaces;
using EasyMicroservices.PaymentsMicroservice.WebApi.Controllers;
using EasyMicroservices.WhiteLabelsMicroservice.VirtualServerForTests;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Payments.GeneratedServices;

namespace EasyMicroservices.PaymentsMicroservice.Tests
{
    public class TestBase
    {
        static bool IsStarted = false;
        static bool IsInitialized = false;

        protected static PaymentsVirtualTestManager PaymentsVirtualTestManager { get; set; } = new PaymentsVirtualTestManager();
        //protected static WhiteLabelVirtualTestManager WhiteLabelVirtualTestManager { get; set; } = new WhiteLabelVirtualTestManager();

        static IServiceProvider service = null;
        static async Task StartServer()
        {
            if (IsStarted)
                return;
            IsStarted = true;
            //if (await WhiteLabelVirtualTestManager.OnInitialize(WhiteLabelPort))
            //{
            //    foreach (var item in WhiteLabelResource.GetResources(new PaymentContext(new DatabaseBuilder(null)), "Payments"))
            //    {
            //        WhiteLabelVirtualTestManager.AppendService(WhiteLabelPort, item.Key, item.Value);
            //    }
            //}

            TaskCompletionSource taskCompletionSource = new TaskCompletionSource();
            Thread thread = new Thread(async () =>
            {
                await WebApi.Program.Run(null, (s) =>
                {
                    s.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(OrderController).Assembly));
                }, (p) =>
                {
                    service = p;
                    taskCompletionSource.SetResult();
                }).ConfigureAwait(false);
            });
            thread.Start();
            await taskCompletionSource.Task;

            if (await PaymentsVirtualTestManager.OnInitialize(PaymentComponentPort))
            {
                foreach (var item in StripeTestResource.GetResources("http://localhost/successpaymenthappens?orderid=0000",
                    $"http://localhost:{Port}/api/StripeCallback/SuccessPortalCallback?sessionId=cs_test_a1qlnJteMKipT19Jawvbnngbdfcdsj832YeARo1DAJjdPgNWYeHaP"))
                {
                    PaymentsVirtualTestManager.AppendService(PaymentComponentPort, item.Key, item.Value);
                }
            }
        }

        public static async Task Initialize()
        {
            await StartServer();
            if (IsInitialized)
                return;
            IsInitialized = true;
            await CheckDatabase(service);
        }

        protected static int PaymentComponentPort = 1061;
        static int Port = 1047;
        static int WhiteLabelPort = 1041;
        static HttpClient HttpClient = new HttpClient();
        public OrderPortalClient GetOrderPortalClient()
        {
            return new OrderPortalClient($"http://localhost:{Port}", HttpClient);
        }

        static async Task CheckDatabase(IServiceProvider service)
        {
            using var unit = service.GetService<IAppUnitOfWork>();
            var queryable = unit.GetQueryableOf<ServiceEntity>();
            var services = await queryable.ToListAsync();
            if (services.Count == 0)
            {
                await queryable.AddAsync(new ServiceEntity()
                {
                    Name = "TestServer",
                    ServiceType = PaymentServiceType.Stripe,
                    Addresses = new List<ServiceAddressEntity>()
                    {
                        new ServiceAddressEntity()
                        {
                            //ApiKey = "your live session",
                            //Address = Stripe.StripeClient.DefaultApiBase
                            ApiKey = "testapikey",
                            Address = $"http://localhost:{PaymentComponentPort}"
                        }
                    }
                });
                await queryable.SaveChangesAsync();
            }
        }
    }
}
