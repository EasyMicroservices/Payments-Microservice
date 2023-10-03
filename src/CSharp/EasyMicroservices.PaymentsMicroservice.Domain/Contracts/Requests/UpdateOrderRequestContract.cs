using EasyMicroservices.Payments.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class UpdateOrderRequestContract
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public string Address { get; set; }
        public PaymentStatusType Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Url { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
