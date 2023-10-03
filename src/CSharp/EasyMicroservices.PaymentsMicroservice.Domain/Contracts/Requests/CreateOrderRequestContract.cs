using EasyMicroservices.Domain.DataTypes;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using System.Collections.Generic;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Requests
{
    public class CreateOrderRequestContract
    {
        public string Name { get; set; }
        public long ServiceId { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public CurrencyCodeType CurrencyCode { get; set; }
        public List<OrderUrlContract> Urls { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
