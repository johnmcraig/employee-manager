using System;
using Microsoft.EntityFrameworkCore;
using server.Data.Entites;

namespace server.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //     modelBuilder.Entity<Employee>()
        //         .HasData(new 
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Richard Hendricks",
        //            Email = "contact@richardhendrinks.com"
        //        },
        //        new 
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Bertram Gilfoye",
        //            Email = "contact@bertramgilfoye.com"
        //        },
        //        new
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Denish Chugtai",
        //            Email = "contact@denishchutai.com"
        //        });
        // }
    }
}