using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Contexts;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.ServiceContracts;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class InvoiceStatusHistoryController : SimpleQueryServiceController<InvoiceStatusHistoryEntity, InvoiceStatusHistoryCreateRequestContract, InvoiceStatusHistoryUpdateRequestContract, InvoiceStatusHistoryContract, long>
    {
        private readonly IContractLogic<InvoiceStatusHistoryEntity, InvoiceStatusHistoryCreateRequestContract, InvoiceStatusHistoryUpdateRequestContract, InvoiceStatusHistoryContract, long> _contractlogic;
        private readonly IContractLogic<InvoiceEntity, InvoiceCreateRequestContract, InvoiceUpdateRequestContract, InvoiceContract, long> _invoicelogic;

        public InvoiceStatusHistoryController(PaymentContext context, IContractLogic<InvoiceEntity, InvoiceCreateRequestContract, InvoiceUpdateRequestContract, InvoiceContract, long> invoicelogic, IContractLogic<InvoiceStatusHistoryEntity, InvoiceStatusHistoryCreateRequestContract, InvoiceStatusHistoryUpdateRequestContract, InvoiceStatusHistoryContract, long> contractLogic) : base(contractLogic)
        {
            _invoicelogic = invoicelogic;
            _contractlogic = contractLogic;
        }
        public override async Task<MessageContract<long>> Add(InvoiceStatusHistoryCreateRequestContract request, CancellationToken cancellationToken = default)
            {
            var serviceExist = await _invoicelogic.GetById(new GetIdRequestContract<long> { Id = request.InvoiceId});
            if (!serviceExist.IsSuccess)
                return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "InvoiceId is incorrect");

            return await _contractlogic.Add(request, cancellationToken);
        }
        public override async Task<MessageContract<InvoiceStatusHistoryContract>> Update(InvoiceStatusHistoryUpdateRequestContract request, CancellationToken cancellationToken = default)
        {
            var serviceExist = await _invoicelogic.GetById(new GetIdRequestContract<long> { Id = request.InvoiceId });
            if (!serviceExist.IsSuccess)
                return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "InvoiceId is incorrect");

            return await _contractlogic.Update(request, cancellationToken);
        }
    }
}
