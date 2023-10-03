using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Payments.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class OrderStatusHistorySchema : FullAbilitySchema
    {
        public PaymentStatusType Status { get; set; }
    }
}
