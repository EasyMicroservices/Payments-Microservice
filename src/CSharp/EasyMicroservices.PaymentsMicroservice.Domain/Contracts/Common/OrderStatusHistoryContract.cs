using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.Payments.DataTypes;
using System;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Common
{
    public class OrderStatusHistoryContract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public long OrderId { get; set; }
        public long Id { get; set; }
        public PaymentStatusType Status { get; set; }
        public string UniqueIdentity { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
