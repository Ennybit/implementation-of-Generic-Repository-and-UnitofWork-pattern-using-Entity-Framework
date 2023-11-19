using Microsoft.EntityFrameworkCore;

namespace GenericRepo
{
    public class datacontext : DbContext
    {
        public datacontext(DbContextOptions<datacontext> optionms) : base(optionms)
        {

        }

        public DbSet<Home>? Homes { get; set; }

    }
}
