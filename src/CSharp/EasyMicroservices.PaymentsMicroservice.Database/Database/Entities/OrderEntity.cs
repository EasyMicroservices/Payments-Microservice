using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using System.Collections.Generic;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class OrderEntity : OrderSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long ServiceId { get; set; }
        public ServiceEntity Service { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
        public ICollection<OrderStatusHistoryEntity> OrderStatusHistories { get; set; }
        public ICollection<OrderUrlEntity> OrderUrls { get; set; }
    }
    
}
