using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class UpdateProudctRequestContract
    {
        public long Id { get; set; }
        public long InvoiceId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
