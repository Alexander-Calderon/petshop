
using Microsoft.EntityFrameworkCore;



namespace Persistence
{
    public class PetshopContext : DbContext
    {

        public PetshopContext(DbContextOptions options) : base(options)
        {

        }

        // public DbSet<>
        

        
    }
}