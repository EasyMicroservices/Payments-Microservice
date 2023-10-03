using EasyMicroservices.Payments.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Common
{
    public class OrderUrlContract
    {
        public string Url { get; set; }
        public RequestUrlType Type { get; set; }
    }
}
