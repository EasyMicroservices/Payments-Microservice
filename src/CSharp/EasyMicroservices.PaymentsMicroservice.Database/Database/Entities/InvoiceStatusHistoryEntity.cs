using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class InvoiceStatusHistoryEntity : InvoiceStatusHistorySchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long InvoiceId { get; set; }
        public InvoiceEntity Invoice { get; set; }
    }
}
