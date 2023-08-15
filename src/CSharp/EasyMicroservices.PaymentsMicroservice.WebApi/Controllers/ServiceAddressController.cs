using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.ServiceContracts;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class ServiceAddressController : SimpleQueryServiceController<ServiceAddressEntity, ServiceAddressCreateRequestContract, ServiceAddressUpdateRequestContract, ServiceAddressContract, long>
    {
        private readonly IContractLogic<ServiceAddressEntity, ServiceAddressCreateRequestContract, ServiceAddressUpdateRequestContract, ServiceAddressContract, long> _contractlogic;
        private readonly IContractLogic<ServiceEntity, ServiceCreateRequestContract, ServiceUpdateRequestContract, ServiceContract, long> _servicelogic;


        public ServiceAddressController(IContractLogic<ServiceEntity, ServiceCreateRequestContract, ServiceUpdateRequestContract, ServiceContract, long> Servicelogic , IContractLogic<ServiceAddressEntity, ServiceAddressCreateRequestContract, ServiceAddressUpdateRequestContract, ServiceAddressContract, long> Contractlogic) : base(Contractlogic)
        {
            _servicelogic = Servicelogic;
            _contractlogic = ContractLogic;
        }
        public override async Task<MessageContract<long>> Add(ServiceAddressCreateRequestContract request, CancellationToken cancellationToken = default)
        {
            var serviceExist = await _servicelogic.GetById(new GetIdRequestContract<long> { Id = request.ServiceId });
            if (!serviceExist.IsSuccess)
                return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "ServiceId is incorrect");

            return await base.Add(request, cancellationToken);
        }
        public override async  Task<MessageContract<ServiceAddressContract>> Update(ServiceAddressUpdateRequestContract request, CancellationToken cancellationToken = default)
        {
            var serviceExist = await _servicelogic.GetById(new GetIdRequestContract<long> { Id = request.ServiceId });
            if (!serviceExist.IsSuccess)
                return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "ServiceId is incorrect");

            return await base.Update(request, cancellationToken);
        }
    }
}
