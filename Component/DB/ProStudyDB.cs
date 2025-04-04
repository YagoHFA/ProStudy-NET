using Microsoft.EntityFrameworkCore;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Component.DB
{
    public class ProStudyDB : DbContext
    {
         public ProStudyDB(DbContextOptions<ProStudyDB> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SkillTest> SkillTests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Video> Videos { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            
            modelBuilder.Entity<SkillTest>()
                .HasMany(st => st.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId);

            modelBuilder.Entity<SkillTest>()
                .HasMany(st => st.Users)
                .WithMany(u => u.SkillTests)
                .UsingEntity(j => j.ToTable("SkillTestUsers"));

            modelBuilder.Entity<Category>()
                .HasMany(c => c.SkillTestList)
                .WithMany(st => st.CategoryList)
                .UsingEntity(j => j.ToTable("TestCategory"));

            modelBuilder.Entity<Category>()
                .HasMany(c => c.ProjectList)
                .WithMany(p => p.Tools)
                .UsingEntity(j => j.ToTable("ProjectTools"));

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectsUser)
                .WithMany(u => u.UserProjects)
                .UsingEntity(j => j.ToTable("ProjectUsers"));

                modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}