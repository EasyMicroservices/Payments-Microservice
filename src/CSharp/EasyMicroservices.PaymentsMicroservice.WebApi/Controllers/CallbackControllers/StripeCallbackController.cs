using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Logics;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers.CallbackControllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StripeCallbackController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;
        public StripeCallbackController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<MessageContract> SuccessPortalCallback(string sessionId, CancellationToken cancellationToken = default)
        {
            var paymentProvider = await _unitOfWork.GetPayment().AsCheckedResult();
            var retrieveResult = await paymentProvider.RetrieveOrderAsync(new Payments.Models.Requests.RetrieveOrderRequest()
            {
                Id = sessionId
            }).AsCheckedResult();
            var order = await _unitOfWork.GetLogic<OrderEntity, long>().GetBy(x => x.ExternalServiceId == sessionId, q => q.Include(x => x.Urls)).AsCheckedResult();
            await OrderLogic.AddAndUpdateOrderStatus(order.Id, retrieveResult.Status, _unitOfWork);
            var successUrl = order.Urls.FirstOrDefault(x => x.Type == Payments.DataTypes.RequestUrlType.SuccessUrl);
            successUrl.ThrowIfNull(nameof(successUrl));
            HttpContext.Response.StatusCode = StatusCodes.Status301MovedPermanently;
            HttpContext.Response.Headers.Location = successUrl.Url + order.Id;
            return true;
        }

        [HttpGet]
        public async Task<MessageContract> CancelPortalCallback(string sessionId, CancellationToken cancellationToken = default)
        {
            var req = HttpContext.Request.Query;
            var hearders = HttpContext.Response.Headers;

            return true;
        }
    }
}
