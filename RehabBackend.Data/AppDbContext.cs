using RehabBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace RehabBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
