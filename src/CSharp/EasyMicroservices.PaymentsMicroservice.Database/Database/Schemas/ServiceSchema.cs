using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Payments.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class ServiceSchema : FullAbilitySchema
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PaymentServiceType ServiceType { get; set; }
    }
}

