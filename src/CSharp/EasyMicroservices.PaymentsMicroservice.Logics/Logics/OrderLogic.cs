using EasyMicroservices.Payments.Models;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Logics
{
    public static class OrderLogic
    {
        public static List<PaymentUrl> GetOrderUrls(IAppUnitOfWork unitOfWork)
        {
            var config = unitOfWork.GetConfiguration();

            var successUrl = config.GetValue<string>("PaymentAddresses:SuccessCallbackUrl");
            var cancelUrl = config.GetValue<string>("PaymentAddresses:FailedCallbackUrl");
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

        public static List<string> GetRedirectToPortalUrls(IEnumerable<long> orderUrlIds, IAppUnitOfWork unitOfWork)
        {
            var config = unitOfWork.GetConfiguration();
            var redirectUrl = config.GetValue<string>("PaymentAddresses:RedirectToPortalUrl");
            return orderUrlIds.Select(x => redirectUrl + $"?{x}").ToList();
        }

        public static async Task<List<PaymentUrl>> CreateOrder(CreateOrderRequestContract request, IAppUnitOfWork unitOfWork)
        {
            var paymentProvider = await unitOfWork.GetPayment().AsCheckedResult();
            var createOrderResult = await paymentProvider.CreateOrderAsync(new Payments.Models.Requests.PaymentOrderRequest()
            {
                Urls = GetOrderUrls(unitOfWork),
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
            return createOrderResult.Urls;
        }
    }
}
