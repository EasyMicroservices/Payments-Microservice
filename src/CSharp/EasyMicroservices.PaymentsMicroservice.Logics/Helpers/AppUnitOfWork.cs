using EasyMicroservices.Cores.AspEntityFrameworkCoreApi;
using EasyMicroservices.Payments.Interfaces;
using EasyMicroservices.Payments.Stripe.Providers;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Validations;
using EasyMicroservices.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Helpers
{
    public class AppUnitOfWork : UnitOfWork, IAppUnitOfWork
    {
        public AppUnitOfWork(IServiceProvider service) : base(service)
        {

        }

        public async Task<MessageContract<IPaymentProvider>> GetPayment()
        {
            var service = await GetReadableOf<ServiceEntity>().FirstOrDefaultAsync();
            return await GetPayment((service?.Id).GetValueOrDefault());
        }

        public async Task<MessageContract<IPaymentProvider>> GetPayment(long serviceId)
        {
            var service = await GetReadableOf<ServiceEntity>().Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == serviceId);
            Console.WriteLine($"{serviceId} {service == null}");
            var validate = service.Validate();
            if (!validate)
                return validate.ToContract<IPaymentProvider>();
            var address = service.Addresses.First();
            return new StripeProvider(address.ApiKey, new StripeClient(address.ApiKey, apiBase: address.Address));
        }
    }
}
