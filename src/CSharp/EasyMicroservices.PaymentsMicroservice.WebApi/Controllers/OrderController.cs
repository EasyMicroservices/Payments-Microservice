using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.PaymentsMicroservice.Contracts.Common;
using EasyMicroservices.PaymentsMicroservice.Contracts.Requests;
using EasyMicroservices.PaymentsMicroservice.Contracts.Responses;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using EasyMicroservices.PaymentsMicroservice.Interfaces;
using EasyMicroservices.PaymentsMicroservice.Logics;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.PaymentsMicroservice.WebApi.Controllers
{
    public class OrderController : SimpleQueryServiceController<OrderEntity, CreateOrderRequestContract, UpdateOrderRequestContract, OrderContract, long>
    {
        private readonly IAppUnitOfWork _unitOfWork;
        public OrderController(IAppUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
