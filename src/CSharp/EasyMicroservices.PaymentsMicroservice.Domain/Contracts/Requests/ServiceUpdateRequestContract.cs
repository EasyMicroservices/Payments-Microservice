using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class ServiceUpdateRequestContract
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
