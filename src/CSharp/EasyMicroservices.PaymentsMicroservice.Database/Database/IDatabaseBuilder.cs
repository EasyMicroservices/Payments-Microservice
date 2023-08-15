using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.PaymentsMicroservice.Database
{
    public interface IDatabaseBuilder
    {
        void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}
