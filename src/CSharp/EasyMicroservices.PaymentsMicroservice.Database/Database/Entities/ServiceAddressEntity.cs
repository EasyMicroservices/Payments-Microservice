using EasyMicroservices.PaymentsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace EasyMicroservices.PaymentsMicroservice.Database.Entities
{
    public class ServiceAddressEntity : ServiceAddressSchema, IIdSchema<long>
    {
        public long ServiceId { get; set; }
        public ServiceEntity Service { get; set; }
        public long Id { get; set; }
    }
}
