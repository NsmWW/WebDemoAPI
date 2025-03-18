using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDemoAPI.Domain;
using WebDemoAPI.Domain.UsersFuntion;

namespace WebDemoAPI.Infastructure.DataContext
{
    public class ApplicationDBcontext : DbContext, IApplicationDBcontext
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options) { }
        public ApplicationDBcontext() { }
        public virtual DbSet<User> User { set; get; }
        public virtual DbSet<Role> Role { set; get; }
        public virtual DbSet<Permission> Permissions { set; get; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(e=>e.Id);
            });
            modelBuilder.Entity<Permission>(p =>
            {
                p.HasOne(e => e.Role)
                .WithMany(e => e.Permissions)
                .HasForeignKey(e => e.RoleId).HasConstraintName("FK_Permission_Role");
                p.HasOne(e => e.User)
                .WithMany(e => e.Permissions)
                .HasForeignKey(e => e.UserId).HasConstraintName("FK_Permission_User");
            });
            modelBuilder.Entity<User>(e => {
               e.HasKey(e=> e.Id);  
            });

        }
        private static void SeedData(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role { RoleCode = "Admin", RoleName = "Admin", Id = 1},
                new Role { RoleCode = "Teacher", RoleName = "Teacher", Id = 2 },
                new Role { RoleCode = "Student", RoleName = "Student", Id = 3 }
            );
        }
        public async Task<int> CommitChageAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<TEntity> SetTEntity<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
