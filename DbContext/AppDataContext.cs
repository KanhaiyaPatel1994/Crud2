using Crud2.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            //modelBuilder.Entity<Employee>().Property(e => e.Name).IsRequired().HasMaxLength(100);
            //modelBuilder.Entity<Employee>().Property(e => e.Email).IsRequired().HasMaxLength(100);
        }
    }
}
