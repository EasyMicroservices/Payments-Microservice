using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.ServiceContracts;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EasyMicroservices.PaymentsMicroservice.Validations
{
    public static class ServiceEntityValidation
    {
        public static MessageContract Validate(this ServiceEntity service)
        {
            if (service == null)
                return (FailedReasonType.NotFound, "No service provider found in ServiceEntity, Please add your service provider!");
            else if (service.Addresses.IsNullOrEmpty())
                return (FailedReasonType.Empty, $"No address found for service provider Id: {service.Id}");
            return true;
        }
    }
}
