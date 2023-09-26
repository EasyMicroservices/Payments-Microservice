using EasyMicroservices.PaymentsMicroservice.Database.Schemas;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class InvoiceUrlEntity : InvoiceUrlSchema
    {
        public long Id { get; set; }

        public long InvoiceId { get; set; }
        public InvoiceEntity Invoice { get; set; }
    }
}
