using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class InvoiceUrlSchema : FullAbilitySchema
    {
        public string Url { get; set; }
    }
}
