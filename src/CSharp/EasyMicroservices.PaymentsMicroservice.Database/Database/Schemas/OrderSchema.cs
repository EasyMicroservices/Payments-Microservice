using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Domain.DataTypes;
using EasyMicroservices.Payments.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class OrderSchema : FullAbilitySchema
    {
        public bool HasCallbackCalledByUser { get; set; }
        public PaymentStatusType Status { get; set; } = PaymentStatusType.Created;
        public decimal TotalAmount { get; set; }
        public string ExternalServiceId { get; set; }
        public CurrencyCodeType CurrencyCode { get; set; }
    }
}
