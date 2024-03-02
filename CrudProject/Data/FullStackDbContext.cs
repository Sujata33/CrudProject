using CrudProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Banks> Banks { get; set; }
        public DbSet<Branches> Branches { get; set; }

    }
}
