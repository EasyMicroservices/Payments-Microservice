using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class OrderUrlSchema : FullAbilitySchema
    {
        public string Url { get; set; }
    }
}
