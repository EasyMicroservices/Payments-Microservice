﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class ServiceAddressUpdateRequestContract
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public string Address { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
