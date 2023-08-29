using Microsoft.EntityFrameworkCore;

namespace ApiBibliotecaSourcestree
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
