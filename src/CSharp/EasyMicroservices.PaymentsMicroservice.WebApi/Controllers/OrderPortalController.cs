using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Contracts.Responses;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Logics;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderPortalController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;
        public OrderPortalController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<MessageContract<CreateOrderResponseContract>> CreateOrderPortal(CreateOrderRequestContract request, CancellationToken cancellationToken = default)
        {
            var orderContractLogic = _unitOfWork.GetLongContractLogic<OrderEntity, CreateOrderRequestContract, UpdateOrderRequestContract, OrderContract>();
            var orderLogic = _unitOfWork.GetLogic<OrderEntity, long>();
            var addedOrderId = await orderContractLogic.Add(request, cancellationToken).AsCheckedResult();
            await OrderLogic.AddAndUpdateOrderStatus(addedOrderId, Payments.DataTypes.PaymentStatusType.Created, _unitOfWork);
            var paymentOrderResponse = await OrderLogic.CreateOrder(request, _unitOfWork);
            var getOrder = await orderLogic.GetById(addedOrderId, cancellationToken).AsCheckedResult();
            var queryable = _unitOfWork.GetQueryableOf<OrderUrlEntity>();
            await queryable.AddBulkAsync(paymentOrderResponse.Urls.Select(x => new OrderUrlEntity()
            {
                OrderId = addedOrderId,
                Type = x.Type,
                Url = x.Url,
                Key = Guid.NewGuid().ToString()
            }), cancellationToken);
            await queryable.SaveChangesAsync();
            getOrder.ExternalServiceId = paymentOrderResponse.Id;
            await orderLogic.Update(getOrder, cancellationToken).AsCheckedResult();

            var orderUrls = await queryable.Where(x => x.OrderId == addedOrderId && x.Type == Payments.DataTypes.RequestUrlType.RedirectUrl).ToListAsync();
            return new CreateOrderResponseContract()
            {
                Id = addedOrderId,
                PortalUrls = OrderLogic.GetRedirectToPortalUrls(orderUrls.Select(x => x.Key), _unitOfWork)
            };
        }

        [HttpGet]
        public async Task<MessageContract> OpenPortal(string portalKey, CancellationToken cancellationToken = default)
        {
            var url = await _unitOfWork.GetLogic<OrderUrlEntity, long>().GetBy(x => x.Key == portalKey, cancellationToken: cancellationToken).AsCheckedResult();
            await OrderLogic.AddAndUpdateOrderStatus(url.OrderId, Payments.DataTypes.PaymentStatusType.RedirectedToBankPortal, _unitOfWork);
            HttpContext.Response.StatusCode = StatusCodes.Status301MovedPermanently;
            HttpContext.Response.Headers.Location = url.Url;
            return true;
        }
    }
}
