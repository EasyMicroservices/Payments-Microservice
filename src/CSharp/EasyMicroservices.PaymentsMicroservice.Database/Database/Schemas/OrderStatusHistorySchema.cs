using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.PaymentsMicroservice.DataTypes;
using System;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class OrderStatusHistorySchema : FullAbilitySchema
    {
        public OrderStatusType Status { get; set; }
    }
}
