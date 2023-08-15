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
    public class ProductController : SimpleQueryServiceController<ProductEntity, ProudctCreateRequestContract, ProudctUpdateRequestContract, ProductContract, long>
    {
        private readonly IContractLogic<InvoiceEntity, InvoiceCreateRequestContract, InvoiceUpdateRequestContract, InvoiceContract, long> _invoicelogic;
        private readonly IContractLogic<ProductEntity, ProudctCreateRequestContract, ProudctUpdateRequestContract, ProductContract, long> _contractlogic;

        public ProductController(PaymentContext context, IContractLogic<InvoiceEntity, InvoiceCreateRequestContract, InvoiceUpdateRequestContract, InvoiceContract, long> invoicelogic, IContractLogic<ProductEntity, ProudctCreateRequestContract, ProudctUpdateRequestContract, ProductContract, long> contractlogic) : base(contractlogic)
        {
            _invoicelogic = invoicelogic;
            _contractlogic = contractlogic;
        }
        public override async Task<MessageContract<long>> Add(ProudctCreateRequestContract request, CancellationToken cancellationToken = default)
        {
            var serviceExist = await _invoicelogic.GetById(new GetIdRequestContract<long> { Id = request.InvoiceId });
            if (!serviceExist.IsSuccess)
                return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "InvoiceId is incorrect");

            return await _contractlogic.Add(request, cancellationToken);
        }
        public override async Task<MessageContract<ProductContract>> Update(ProudctUpdateRequestContract request, CancellationToken cancellationToken = default)
        {
            var serviceExist = await _invoicelogic.GetById(new GetIdRequestContract<long> { Id = request.InvoiceId });
            if (!serviceExist.IsSuccess)
                return (EasyMicroservices.ServiceContracts.FailedReasonType.Empty, "InvoiceId is incorrect");
            return await _contractlogic.Update(request, cancellationToken);
        }
    }
}
