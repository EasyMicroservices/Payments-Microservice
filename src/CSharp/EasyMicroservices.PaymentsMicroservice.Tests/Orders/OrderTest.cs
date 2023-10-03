namespace EasyMicroservices.PaymentsMicroservice.Tests.Orders
{
    public class OrderTest : TestBase
    {
        [Theory]
        [InlineData("Bag", 1000.0)]
        public static Task Createorder(string productName, decimal amount)
        {
            return Task.CompletedTask;
        }
    }
}
