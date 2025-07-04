using Microsoft.EntityFrameworkCore;
using ProductionCFD2.Models;

namespace ProductionCFD2.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
            public DbSet<Shift> Shifts { get; set; }
            public DbSet<ShiftIncharge> ShiftIncharges { get; set; }
            public DbSet<Material> Materials { get; set; }
            public DbSet<ProductionTable> ProductionTables { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
}
