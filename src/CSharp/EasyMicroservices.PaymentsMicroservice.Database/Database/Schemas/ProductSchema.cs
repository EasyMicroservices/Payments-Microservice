using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Domain.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class ProductSchema : FullAbilitySchema
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public CurrencyCodeType CurrencyCode { get; set; }
    }
}
