using LearnNow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnNow.Domain
{
    public class LearnNowDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public LearnNowDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
