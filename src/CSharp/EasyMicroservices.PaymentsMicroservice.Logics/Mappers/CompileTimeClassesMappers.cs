//using System.Threading.Tasks;
//using EasyMicroservices.Mapper.CompileTimeMapper.Interfaces;
//using EasyMicroservices.Mapper.Interfaces;
//using System.Linq;

//namespace CompileTimeMapper
//{
//    public class PaymentEntity_PaymentContract_Mapper : IMapper
//    {
//        readonly IMapperProvider _mapper;
//        public PaymentEntity_PaymentContract_Mapper(IMapperProvider mapper)
//        {
//            _mapper = mapper;
//        }
//        public global::EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity Map(global::EasyMicroservices.PaymentsMicroservice.Contracts.Common.OrderContract fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            var mapped = new global::EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity()
//            {
//                Id = fromObject.Id,
//                ServiceId = fromObject.ServiceId,
//                Address = fromObject.Address,
//                Status = fromObject.Status,
//                Url = fromObject.Url,
//                TotalAmount = fromObject.TotalAmount,
//                CreationDateTime = fromObject.CreationDateTime,
//                ModificationDateTime = fromObject.ModificationDateTime,
//                IsDeleted = fromObject.IsDeleted,
//                DeletedDateTime = fromObject.DeletedDateTime,
//                UniqueIdentity = fromObject.UniqueIdentity
//            };
//            return mapped;
//        }
//        public global::EasyMicroservices.PaymentsMicroservice.Contracts.Common.OrderContract Map(global::EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            var mapped = new global::EasyMicroservices.PaymentsMicroservice.Contracts.Common.OrderContract()
//            {
//                Id = fromObject.Id,
//                ServiceId = fromObject.ServiceId,
//                Address = fromObject.Address,
//                Status = fromObject.Status,
//                Url = fromObject.Url,
//                TotalAmount = fromObject.TotalAmount,
//                CreationDateTime = fromObject.CreationDateTime,
//                ModificationDateTime = fromObject.ModificationDateTime,
//                IsDeleted = fromObject.IsDeleted,
//                DeletedDateTime = fromObject.DeletedDateTime,
//                UniqueIdentity = fromObject.UniqueIdentity
//            };
//            return mapped;
//        }
//        public async Task<global::EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity> MapAsync(global::EasyMicroservices.PaymentsMicroservice.Contracts.Common.OrderContract fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            var mapped = new global::EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity()
//            {
//                Id = fromObject.Id,
//                ServiceId = fromObject.ServiceId,
//                Address = fromObject.Address,
//                Status = fromObject.Status,
//                Url = fromObject.Url,
//                TotalAmount = fromObject.TotalAmount,
//                CreationDateTime = fromObject.CreationDateTime,
//                ModificationDateTime = fromObject.ModificationDateTime,
//                IsDeleted = fromObject.IsDeleted,
//                DeletedDateTime = fromObject.DeletedDateTime,
//                UniqueIdentity = fromObject.UniqueIdentity
//            };
//            return mapped;
//        }
//        public async Task<global::EasyMicroservices.PaymentsMicroservice.Contracts.Common.OrderContract> MapAsync(global::EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            var mapped = new global::EasyMicroservices.PaymentsMicroservice.Contracts.Common.OrderContract()
//            {
//                Id = fromObject.Id,
//                ServiceId = fromObject.ServiceId,
//                Address = fromObject.Address,
//                Status = fromObject.Status,
//                Url = fromObject.Url,
//                TotalAmount = fromObject.TotalAmount,
//                CreationDateTime = fromObject.CreationDateTime,
//                ModificationDateTime = fromObject.ModificationDateTime,
//                IsDeleted = fromObject.IsDeleted,
//                DeletedDateTime = fromObject.DeletedDateTime,
//                UniqueIdentity = fromObject.UniqueIdentity

//            };
//            return mapped;
//        }
//        public object MapObject(object fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            if (fromObject.GetType() == typeof(EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity))
//                return Map((EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity)fromObject, uniqueRecordId, language, parameters);
//            return Map((EasyMicroservices.PaymentsMicroservice.Contracts.Common.OrderContract)fromObject, uniqueRecordId, language, parameters);
//        }
//        public async Task<object> MapObjectAsync(object fromObject, string uniqueRecordId, string language, object[] parameters)
//        {
//            if (fromObject == default)
//                return default;
//            if (fromObject.GetType() == typeof(EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity))
//                return await MapAsync((EasyMicroservices.PaymentsMicroservice.Database.Entities.OrderEntity)fromObject, uniqueRecordId, language, parameters);
//            return await MapAsync((EasyMicroservices.PaymentsMicroservice.Contracts.Common.OrderContract)fromObject, uniqueRecordId, language, parameters);
//        }
//    }
//}