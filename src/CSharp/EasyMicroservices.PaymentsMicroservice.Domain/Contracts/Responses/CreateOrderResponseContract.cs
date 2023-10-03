using System.Collections.Generic;

namespace EasyMicroservices.PaymentsMicroservice.Contracts.Responses
{
    public class CreateOrderResponseContract
    {
        public long Id { get; set; }
        public List<string> PortalUrls { get; set; }
    }
}
