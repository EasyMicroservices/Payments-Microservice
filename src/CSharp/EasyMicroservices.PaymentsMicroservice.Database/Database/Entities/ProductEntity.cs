using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class ProductEntity : ProductSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public long InvoiceId { get; set; }
        public InvoiceEntity Invoice { get; set; }


    }
}
