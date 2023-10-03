using EasyMicroservices.PaymentsMicroservice.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Tests
{
    public class TestBase
    {
        static TestBase()
        {
            StartServer().GetAwaiter().GetResult();
        }

        static bool IsStarted = false;

        static async Task StartServer()
        {
            if (IsStarted)
                return;
            IsStarted = true;
            _ = Task.Run(async () =>
            {
                await WebApi.Program.Run(null, (s) =>
                {
                    s.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(OrderController).Assembly));
                });
            });
            await Task.Delay(2000);
        }
    }
}
