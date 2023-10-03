using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class OrderUrlEntity : OrderUrlSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long OrderId { get; set; }
        public OrderEntity Order { get; set; }
    }
}
