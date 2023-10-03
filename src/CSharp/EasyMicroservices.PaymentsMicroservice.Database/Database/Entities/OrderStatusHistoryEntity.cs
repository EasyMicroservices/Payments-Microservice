using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class OrderStatusHistoryEntity : OrderStatusHistorySchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long OrderId { get; set; }
        public OrderEntity Order { get; set; }
    }
}
