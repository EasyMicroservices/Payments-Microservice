using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.PaymentsMicroservice.Database.Contexts
{
    public class PaymentContext : RelationalCoreContext
    {
        public PaymentContext(IEntityFrameworkCoreDatabaseBuilder builder) : base(builder)
        {

        }

        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderUrlEntity> OrderUrls { get; set; }
        public DbSet<OrderStatusHistoryEntity> OrderStatusHistories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ServiceAddressEntity> ServiceAddresses { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.AutoModelCreating(modelBuilder);
        }
    }
}