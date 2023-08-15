using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using EasyMicroservices.PaymentsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class InvoiceStatusHistoryEntity : InvoiceStatusHistorySchema, IIdSchema<long>
    {
        public long InvoiceId { get; set; }
        public InvoiceEntity Invoice { get; set; }
        public long Id { get; set; }
    }
}
