using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Freelancer) //um projeto tem um freelancer
                .WithMany(f => f.FreelanceProjects) //um freelancer tem muitos projetos
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client) 
                .WithMany(c => c.OwnedProjects) 
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProjectComment>()
               .HasOne(p => p.Project)
               .WithMany(p => p.Comments)
               .HasForeignKey(p => p.IdProject)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
               .HasOne(p => p.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(p => p.IdUser)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<UserSkill>()
               .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
               .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
               .HasMany(u => u.Skills)
               .WithOne()
               .HasForeignKey(u => u.IdSkill)
               .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
