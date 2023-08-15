using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Common
{
    public class InvoiceContract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public string Address { get; set; }
        public StatusType Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Url { get; set; }
        public string UniqueIdentity { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
