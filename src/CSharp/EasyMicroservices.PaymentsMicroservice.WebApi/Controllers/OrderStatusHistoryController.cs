using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Contexts;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.ServiceContracts;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class OrderStatusHistoryController : SimpleQueryServiceController<OrderStatusHistoryEntity, CreateOrderStatusHistoryRequestContract, UpdateOrderStatusHistoryRequestContract, OrderStatusHistoryContract, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderStatusHistoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
