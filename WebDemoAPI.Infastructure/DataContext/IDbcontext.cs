using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebDemoAPI.Infastructure.DataContext
{
    public interface IDbcontext : IDisposable
    {
        DbSet<TEntity> SetTEntity<TEntity>() where TEntity : class;
        Task<int> CommitChageAsync();
    }
}
