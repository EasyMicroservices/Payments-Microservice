using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.PaymentsMicroservice.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Common
{
    public class OrderStatusHistoryContract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public long OrderId { get; set; } 
        public long Id { get; set; }
        public OrderStatusType Status { get; set; }
        public string UniqueIdentity { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
