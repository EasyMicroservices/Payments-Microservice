using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class ServiceAddressController : SimpleQueryServiceController<ServiceAddressEntity, CreateServiceAddressRequestContract, UpdateServiceAddressRequestContract, ServiceAddressContract, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceAddressController(IUnitOfWork unitOfWork) : base(null)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
