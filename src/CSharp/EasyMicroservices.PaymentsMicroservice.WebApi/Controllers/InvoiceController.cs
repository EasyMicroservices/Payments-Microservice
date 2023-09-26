using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
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
    public class InvoiceController : SimpleQueryServiceController<InvoiceEntity, CreateInvoiceRequestContract, UpdateInvoiceRequestContract, InvoiceContract, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceController(IUnitOfWork unitOfWork) : base(null)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
