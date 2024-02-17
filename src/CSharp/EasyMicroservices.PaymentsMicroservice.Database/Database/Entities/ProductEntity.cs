﻿using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using System.Collections.Generic;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class ProductEntity : ProductSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public long? ParentId { get; set; }
        public ProductEntity Parent { get; set; }

        public ICollection<ProductEntity> Children { get; set; }
    }
}
