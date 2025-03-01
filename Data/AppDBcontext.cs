using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }


}
