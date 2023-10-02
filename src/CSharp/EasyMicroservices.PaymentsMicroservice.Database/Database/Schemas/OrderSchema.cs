using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Domain.DataTypes;
using EasyMicroservices.PaymentsMicroservice.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class OrderSchema : FullAbilitySchema
    {
        public bool HasCallbackCalledByUser { get; set; }
        public OrderStatusType Status { get; set; }
        public decimal TotalAmount { get; set; }
        public CurrencyCodeType CurrencyCode { get; set; }
    }
}
