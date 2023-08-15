using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class InvoiceEntity : InvoiceSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public ServiceEntity Service { get; set; }
        public ICollection<ProductEntity> Product { get; set; }
        public ICollection<InvoiceStatusHistoryEntity> InvoiceStatusHistory { get; set; }
    }
}
