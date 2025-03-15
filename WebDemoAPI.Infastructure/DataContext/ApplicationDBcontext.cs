using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDemoAPI.Domain;

namespace WebDemoAPI.Infastructure.DataContext
{
    public class ApplicationDBcontext : DbContext, IApplicationDBcontext
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options) { }
        public ApplicationDBcontext() { }
        public virtual DbSet<User> User { set; get; }

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
