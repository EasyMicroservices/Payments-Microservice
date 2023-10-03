using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Payments.DataTypes;
using EasyMicroservices.Payments.Models;
using EasyMicroservices.Payments.Models.Responses;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Logics
{
    public static class OrderLogic
    {
        public static List<PaymentUrl> GetOrderUrls(IAppUnitOfWork unitOfWork, PaymentServiceType paymentServiceType)
        {
            var config = unitOfWork.GetConfiguration();
            var callbackUrl = config.GetValue<string>("PaymentAddresses:CallbackUrl");
            string successUrl = paymentServiceType switch
            {
                PaymentServiceType.Stripe => $"{callbackUrl}/api/StripeCallback/SuccessPortalCallback?sessionId={{CHECKOUT_SESSION_ID}}",
                PaymentServiceType.PayPal => $"{callbackUrl}/api/PayPalCallback/SuccessPortalCallback?sessionId={{CHECKOUT_SESSION_ID}}",
                _ => throw new NotSupportedException($"Payment service type: {paymentServiceType} not support!")
            };

            string cancelUrl = paymentServiceType switch
            {
                PaymentServiceType.Stripe => $"{callbackUrl}/api/StripeCallback/CancelPortalCallback?sessionId={{CHECKOUT_SESSION_ID}}",
                PaymentServiceType.PayPal => $"{callbackUrl}/api/PayPalCallback/CancelPortalCallback?sessionId={{CHECKOUT_SESSION_ID}}",
                _ => throw new NotSupportedException($"Payment service type: {paymentServiceType} not support!")
            };

            return new List<PaymentUrl>()
            {
                new PaymentUrl()
                {
                     Type = Payments.DataTypes.RequestUrlType.SuccessUrl,
                     Url = successUrl
                },
                new PaymentUrl()
                {
                     Type = Payments.DataTypes.RequestUrlType.CancelUrl,
                     Url = cancelUrl
                }
            };
        }

        public static List<string> GetRedirectToPortalUrls(IEnumerable<string> orderUrlIds, IAppUnitOfWork unitOfWork)
        {
            var config = unitOfWork.GetConfiguration();
            var redirectUrl = config.GetValue<string>("PaymentAddresses:RedirectToPortalUrl");
            return orderUrlIds.Select(x => string.Format(redirectUrl, x)).ToList();
        }

        public static async Task<PaymentOrderResponse> CreateOrder(CreateOrderRequestContract request, IAppUnitOfWork unitOfWork)
        {
            var paymentProvider = await unitOfWork.GetPayment().AsCheckedResult();
            var createOrderResult = await paymentProvider.CreateOrderAsync(new Payments.Models.Requests.PaymentOrderRequest()
            {
                Urls = GetOrderUrls(unitOfWork, paymentProvider.ServiceType),
                Orders = new List<Payments.Models.PaymentOrder>()
                {
                    new Payments.Models.PaymentOrder()
                    {
                         Name = request.Name,
                         Amount = request.TotalAmount,
                         CurrencyCode = request.CurrencyCode,
                    }
                }
            }).AsCheckedResult();
            return createOrderResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="status"></param>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static async Task AddAndUpdateOrderStatus(long orderId, PaymentStatusType status, IAppUnitOfWork unitOfWork)
        {
            var logic = unitOfWork.GetLogic<OrderStatusHistoryEntity, long>();
            var orderlogic = unitOfWork.GetLogic<OrderEntity, long>();
            var order = await orderlogic.GetById(orderId).AsCheckedResult();

            await logic.Add(new OrderStatusHistoryEntity()
            {
                OrderId = orderId,
                Status = status
            }).AsCheckedResult();
            order.Status = status;
            await orderlogic.Update(order).AsCheckedResult();
        }
    }
}
