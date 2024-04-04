using Microsoft.EntityFrameworkCore;
using ProductOffergRPCService.Entities;

namespace ProductOffergRPCService.Data
{
    public class DbContextClass(IConfiguration configuration) : DbContext
    {
        protected readonly IConfiguration Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Offer> Offer {  get; set; }
    }
}
