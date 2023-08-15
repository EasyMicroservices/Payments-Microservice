using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using EasyMicroservices.PaymentsMicroservice.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.PaymentsMicroservice.Database.Contexts
{
    public class PaymentContext : RelationalCoreContext
    {
        IDatabaseBuilder _builder;
        public PaymentContext(IDatabaseBuilder builder)
        {
            _builder = builder;
        }

        public DbSet<InvoiceEntity> Invoice { get; set; }
        public DbSet<InvoiceStatusHistoryEntity> InvoiceStatusHistory { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<ServiceAddressEntity> ServiceAddress { get; set; }
        public DbSet<ServiceEntity> Service { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_builder != null)
                _builder.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvoiceEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(x => x.Service)
                .WithMany(x => x.Invoice)
                .HasForeignKey(x => x.ServiceId);
            });
            modelBuilder.Entity<InvoiceStatusHistoryEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceStatusHistory)
                .HasForeignKey(x => x.InvoiceId);
            });
            modelBuilder.Entity<ProductEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(x => x.Invoice)
                .WithMany(x => x.Product)
                .HasForeignKey(x => x.InvoiceId);
            });
            modelBuilder.Entity<ServiceAddressEntity>(model =>
            {
                model.HasOne(x => x.Service)
                .WithMany(x => x.ServiceAddress)
                .HasForeignKey(x => x.ServiceId);

                model.HasKey(x => x.Id);
            });
            modelBuilder.Entity<ServiceEntity>(model =>
            {
                model.HasKey(x => x.Id);
            });

        }
    }
}