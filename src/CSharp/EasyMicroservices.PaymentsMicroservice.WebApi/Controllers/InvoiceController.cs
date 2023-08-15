using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Contexts;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.ServiceContracts;
using Microsoft.Identity.Client;
using System.Threading;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class InvoiceController : SimpleQueryServiceController<InvoiceEntity, InvoiceCreateRequestContract, InvoiceUpdateRequestContract, InvoiceContract, long>
    {
        private readonly IContractLogic<InvoiceEntity, InvoiceCreateRequestContract, InvoiceUpdateRequestContract, InvoiceContract, long> _contractLogic;
        private readonly IContractLogic<ServiceEntity, ServiceCreateRequestContract, ServiceUpdateRequestContract, ServiceContract, long> _serviceLogic;
        private readonly IConfiguration _config;
        private readonly PaymentContext _context;


        public InvoiceController(PaymentContext context , IContractLogic<InvoiceEntity, InvoiceCreateRequestContract, InvoiceUpdateRequestContract, InvoiceContract, long> contractLogic, IContractLogic<ServiceEntity, ServiceCreateRequestContract, ServiceUpdateRequestContract, ServiceContract, long> servicelogic , IConfiguration config) : base(contractLogic)
        {
            _contractLogic = contractLogic;
            _config = config;
            _context = context;
            _serviceLogic = servicelogic;
        }
        public override async Task<MessageContract<long>> Add(InvoiceCreateRequestContract request, CancellationToken cancellationToken = default)
        {
            var serviceExist = await _serviceLogic.GetById(new GetIdRequestContract<long> { Id = request.ServiceId});
            if (!serviceExist.IsSuccess)
                return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "ServiceId is incorrect");

            return await _contractLogic.Add(request,cancellationToken);

        }
        public override async Task<MessageContract<InvoiceContract>> Update(InvoiceUpdateRequestContract request, CancellationToken cancellationToken = default)
        {
            var serviceExist = await _serviceLogic.GetById(new GetIdRequestContract<long> { Id = request.ServiceId });
            if (!serviceExist.IsSuccess)
                return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "ServiceId is incorrect");

            return  await _contractLogic.Update(request, cancellationToken);
        }
    }
}
