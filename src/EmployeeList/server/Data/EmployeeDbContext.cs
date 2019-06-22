using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.Data.Entites;

namespace server.Data
{
    public class EmployeeDbContext : DbContext
    {
        private readonly IConfiguration _config;
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<Employee>()
                .Property(employee => employee.Name)
                .HasMaxLength(100)
                .IsRequired();
            
            modelBuilder.Entity<Employee>()
                .Property(employee => employee.Email)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}