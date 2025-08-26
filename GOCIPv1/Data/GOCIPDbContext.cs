using Microsoft.EntityFrameworkCore;
using GOCIPv1.Model;
namespace GOCIPv1.Data
{
    public class GOCIPDbContext : DbContext
    {
        public GOCIPDbContext(DbContextOptions<GOCIPDbContext> options) : base(options){ }
        public DbSet<User> Users => Set<User>();
    }
}
