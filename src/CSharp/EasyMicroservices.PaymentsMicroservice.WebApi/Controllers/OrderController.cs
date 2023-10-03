using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Contracts.Responses;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Logics;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class OrderController : SimpleQueryServiceController<OrderEntity, CreateOrderRequestContract, UpdateOrderRequestContract, OrderContract, long>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        public OrderController(IAppUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<MessageContract<CreateOrderResponseContract>> CreateOrder(CreateOrderRequestContract request, CancellationToken cancellationToken = default)
        {
            var addedOrderId = await base.Add(request, cancellationToken).AsCheckedResult();
            var urls = await OrderLogic.CreateOrder(request, _unitOfWork);
            var getOrder = await base.GetById(addedOrderId, cancellationToken).AsCheckedResult();
            var orderUrls = await _unitOfWork.GetWritableOf<OrderUrlEntity>().AddBulkAsync(urls.Select(x => new OrderUrlEntity()
            {
                OrderId = addedOrderId,
                Type = x.Type,
                Url = x.Url
            }), cancellationToken);
            return new CreateOrderResponseContract()
            {
                Id = addedOrderId,
                PortalUrls = OrderLogic.GetRedirectToPortalUrls(orderUrls.Select(x => x.Entity.Id), _unitOfWork)
            };
        }
    }
}
