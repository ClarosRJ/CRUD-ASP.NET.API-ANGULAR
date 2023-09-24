using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    public class AplicactionDbContext : DbContext
    {
        public DbSet<Comentario> Comentario { get; set; }   
        public AplicactionDbContext(DbContextOptions<AplicactionDbContext> options):base(options)
        {
            
        }
    }
}
