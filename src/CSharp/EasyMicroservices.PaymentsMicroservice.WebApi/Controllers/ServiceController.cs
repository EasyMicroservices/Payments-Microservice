using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class ServiceController : SimpleQueryServiceController<ServiceEntity, ServiceCreateRequestContract, ServiceUpdateRequestContract, ServiceContract, long>
    {
        public ServiceController(IContractLogic<ServiceEntity, ServiceCreateRequestContract, ServiceUpdateRequestContract, ServiceContract, long> contractReadable) : base(contractReadable)
        {

        }
    }
}
