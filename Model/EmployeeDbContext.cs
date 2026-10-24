using Microsoft.EntityFrameworkCore;

namespace EmpoyeeAPI.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeModel>()
                .HasIndex(e => e.contactNo)
                .IsUnique();

            modelBuilder.Entity<EmployeeModel>()
                .HasIndex(e => e.email)
                .IsUnique();

            //modelBuilder.Entity<EmployeeModel>()
            //    .Property(e => e.name)
            //    .HasMaxLength(50);

            modelBuilder.Entity<EmployeeModel>()
                .Property(e => e.contactNo)
                .HasMaxLength(10);

            modelBuilder.Entity<EmployeeModel>()
                .Property(e => e.email)
                .HasMaxLength(254);
        }

    }
}