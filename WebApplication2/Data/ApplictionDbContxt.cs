using Microsoft.EntityFrameworkCore;

using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplictionDbContxt : DbContext
    {

        public ApplictionDbContxt(DbContextOptions<ApplictionDbContxt> options) : base(options)
        {
            
        }
        public DbSet<Catagory> Catagories { get; set; }
       
    }
}
