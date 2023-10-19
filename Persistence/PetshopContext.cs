
using Microsoft.EntityFrameworkCore;



namespace Persistence
{
    public class PetshopContext : DbContext
    {

        // public FarmaciaContext(DbContextOptions<FarmaciaContext> options) : base(options)
        public PetshopContext(DbContextOptions options) : base(options)
        {

        }

        // public DbSet<>
        

        
    }
}