using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using System.Collections.Generic;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class ProductEntity : ProductSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long InvoiceId { get; set; }
        public InvoiceEntity Invoice { get; set; }

        public long? ProductId { get; set; }
        public ProductEntity Parent { get; set; }

        public ICollection<ProductEntity> Children { get; set; }
    }
}
