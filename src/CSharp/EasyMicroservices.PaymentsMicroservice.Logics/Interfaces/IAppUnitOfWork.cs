using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Payments.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Interfaces
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IConfiguration GetConfiguration();
        Task<MessageContract<IPaymentProvider>> GetPayment();
        Task<MessageContract<IPaymentProvider>> GetPayment(long serviceId);
    }
}
