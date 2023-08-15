using EasyMicroservices.PaymentsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class InvoiceUpdateRequestContract
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public string Address { get; set; }
        public StatusType Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Url { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
