using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class ProductController : SimpleQueryServiceController<ProductEntity, CreateProudctRequestContract, UpdateProudctRequestContract, ProductContract, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork) : base(null)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
