using EasyMicroservices.PaymentsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class InvoiceStatusHistoryCreateRequestContract
    {
        public long InvoiceId { get; set; }
        public StatusType status { get; set; }
        public string UniqueIdentity { get; set; }

    }
}
