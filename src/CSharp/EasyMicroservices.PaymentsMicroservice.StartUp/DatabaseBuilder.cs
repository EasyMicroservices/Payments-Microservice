using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyMicroservices.PaymentsMicroservice
{
    public class DatabaseBuilder : IEntityFrameworkCoreDatabaseBuilder
    {
        readonly IConfiguration _config;
        public DatabaseBuilder(IConfiguration config)
        {
            _config = config;
        }

        public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PaymentDatabase");
            //optionsBuilder.UseSqlServer(_config.GetConnectionString("local"));
        }
    }
}
