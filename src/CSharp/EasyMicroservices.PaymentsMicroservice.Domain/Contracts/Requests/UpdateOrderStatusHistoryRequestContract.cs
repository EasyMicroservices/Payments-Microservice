using EasyMicroservices.Payments.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class UpdateOrderStatusHistoryRequestContract
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public PaymentStatusType Status { get; set; }
        public string UniqueIdentity { get; set; }

    }
}
