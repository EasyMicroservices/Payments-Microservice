using EasyMicroservices.PaymentsMicroservice.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class CreateOrderRequestContract
    {
        public long ServiceId { get; set; }
        public string Address { get; set; }
        public OrderStatusType Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Url { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
