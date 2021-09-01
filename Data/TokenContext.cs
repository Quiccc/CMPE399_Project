using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ARD_project.Data;

namespace ARD_project.Data
{
    public partial class DemoTokenContext : DbContext
    {
        public DemoTokenContext()
        {
        }

        public DemoTokenContext(DbContextOptions<DemoTokenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<RolesMaster> RolesMaster { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UsersMaster> UsersMaster { get; set; }
        public virtual DbSet<UserTasks> UserTasks { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_UserRoles");

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserTasks>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.UserId })
                    .HasName("PK_UserTasks");

                entity.HasIndex(e => e.TaskId);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.TaskId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
