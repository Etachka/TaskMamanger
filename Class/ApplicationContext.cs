﻿using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TaskMamanger.Class
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connection = "Data Source=DESKTOP-3FU748J;Database=TaskMamanger;Integrated Security = sspi; Encrypt=False;";
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskColumn> TaskColumns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
        public void UpdateColumnItemCounts()
        {
            var columns = TaskColumns.Include(c => c.Tasks).ToList();

            foreach (var column in columns)
            {
                column.ItemCount = column.Tasks.Count();
            }

            SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Task>()
            .HasOne(b => b.TaskColumn)
            .WithMany(a => a.Tasks)
            .HasForeignKey(b => b.TaskColumnID);

            modelBuilder.Entity<Task>()
            .HasOne(b => b.User)
            .WithMany(a => a.Tasks)
            .HasForeignKey(b => b.UserID);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is Task))
            {
                var TC = (Task)entry.Entity;
                if (TC.TaskColumn != null)
                {
                    TC.TaskColumn.ItemCount += 1;
                }
            }


            return base.SaveChanges();
        }
        public void RemoveTask(Task task)
        {
            if (task != null && Tasks.Contains(task))
            {
                Tasks.Remove(task);
                SaveChanges();
            }
        }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
    }
}
