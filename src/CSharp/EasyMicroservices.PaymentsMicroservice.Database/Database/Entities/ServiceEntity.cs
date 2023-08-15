using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class ServiceEntity : PaymentSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public ICollection<ServiceAddressEntity> ServiceAddress { get; set;}
        public ICollection<InvoiceEntity> Invoice { get; set; }

    }
}
