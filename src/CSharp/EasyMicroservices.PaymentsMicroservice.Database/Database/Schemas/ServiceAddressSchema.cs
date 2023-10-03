using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class ServiceAddressSchema : FullAbilitySchema
    {
        public string Address { get; set; }
        public string ApiKey { get; set; }
    }
}
