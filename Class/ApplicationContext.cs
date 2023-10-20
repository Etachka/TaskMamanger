using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMamanger.Class
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connection = "Data Source=192.168.221.12;Initial Catalog=TaskMamanger;" +
            "User ID=user09;Password=09;TrustServerCertificate=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskColumn> TaskColumns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
