using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using System.Collections.Generic;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class ServiceEntity : PaymentSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public ICollection<ServiceAddressEntity> ServiceAddresses { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
