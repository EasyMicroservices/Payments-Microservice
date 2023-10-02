using EasyMicroservices.PaymentsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class CreateOrderStatusHistoryRequestContract
    {
        public long OrderId { get; set; }
        public OrderStatusType Status { get; set; }
        public string UniqueIdentity { get; set; }

    }
}
