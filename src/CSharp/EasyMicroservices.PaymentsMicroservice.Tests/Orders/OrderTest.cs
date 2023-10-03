using Payments.GeneratedServices;

namespace EasyMicroservices.PaymentsMicroservice.Tests.Orders
{
    public class OrderTest : TestBase
    {
        [Theory]
        [InlineData("Bag", 1000.0)]
        [InlineData("Shirt", 2000.0)]
        public async Task Createorder(string productName, decimal amount)
        {
            await Initialize();
            var orderPortalClient = GetOrderPortalClient();
            var result = await orderPortalClient.CreateOrderPortalAsync(new CreateOrderRequestContract()
            {
                Name = productName,
                CurrencyCode = CurrencyCodeType.USD,
                TotalAmount = (double)amount,
                Urls = new List<OrderUrlContract>()
                {
                    new OrderUrlContract()
                    {
                         Type = RequestUrlType.SuccessUrl,
                         Url = "http://localhost/successpaymenthappens?orderid="
                    }
                }
            });
            Assert.True(result.IsSuccess, result.Error?.Details);

            var redirectPortal = result.Result.PortalUrls.First();
            HttpClient httpClient = new HttpClient(new HttpClientHandler()
            {
                AllowAutoRedirect = false
            });
            var resultRedirectToPortal = await httpClient.GetAsync(redirectPortal);
            var url = resultRedirectToPortal.Headers.Location.ToString();
            resultRedirectToPortal = await httpClient.GetAsync(url);
            Assert.Contains("localhost/successpaymenthappens?orderid=", resultRedirectToPortal.Headers.Location.ToString());
        }
    }
}
