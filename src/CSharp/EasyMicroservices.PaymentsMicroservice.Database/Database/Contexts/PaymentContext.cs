using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.PaymentsMicroservice.Database.Contexts
{
    public class PaymentContext : RelationalCoreContext
    {
        readonly IEntityFrameworkCoreDatabaseBuilder _builder;
        public PaymentContext(IEntityFrameworkCoreDatabaseBuilder builder)
        {
            _builder = builder;
        }

        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<InvoiceUrlEntity> InvoiceUrls { get; set; }
        public DbSet<InvoiceStatusHistoryEntity> InvoiceStatusHistories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ServiceAddressEntity> ServiceAddresses { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _builder?.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.AutoModelCreating(modelBuilder);
        }
    }
}