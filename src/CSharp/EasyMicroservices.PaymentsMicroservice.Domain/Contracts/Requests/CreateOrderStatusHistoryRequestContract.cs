using EasyMicroservices.Payments.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class CreateOrderStatusHistoryRequestContract
    {
        public long OrderId { get; set; }
        public PaymentStatusType Status { get; set; }
        public string UniqueIdentity { get; set; }

    }
}
