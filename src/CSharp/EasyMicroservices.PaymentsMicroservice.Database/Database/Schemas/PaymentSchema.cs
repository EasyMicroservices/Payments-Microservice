using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class PaymentSchema : FullAbilitySchema
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

