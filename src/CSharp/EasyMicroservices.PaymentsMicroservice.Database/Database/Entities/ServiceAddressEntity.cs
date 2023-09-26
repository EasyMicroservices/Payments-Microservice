using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class ServiceAddressEntity : ServiceAddressSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long ServiceId { get; set; }
        public ServiceEntity Service { get; set; }
    }
}
