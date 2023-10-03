using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.Payments.DataTypes;
using System;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Common
{
    public class OrderContract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public string Address { get; set; }
        public PaymentStatusType Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Url { get; set; }
        public string UniqueIdentity { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
