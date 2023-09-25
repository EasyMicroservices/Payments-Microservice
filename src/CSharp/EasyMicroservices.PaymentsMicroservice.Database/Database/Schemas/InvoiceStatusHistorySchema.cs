using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.PaymentsMicroservice.DataTypes;
using System;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class InvoiceStatusHistorySchema : FullAbilitySchema
    {
        public InvoiceStatusType Status { get; set; }
    }
}
