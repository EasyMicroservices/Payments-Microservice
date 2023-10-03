using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Payments.DataTypes;

namespace EasyMicroservices.PaymentsMicroservice.Database.Schemas
{
    public class OrderUrlSchema : FullAbilitySchema
    {
        public string Url { get; set; }
        public string Key { get; set; }
        public string CustomParameters { get; set; }
        public RequestUrlType Type { get; set; }
    }
}
