using AppDeslocamento.Data.Context;
using AppDeslocamento.Domain.Interfaces;
using AppDeslocamento.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _applicationDbContext;

        private Dictionary<Type, object> _repositories;

        public UnitOfWork(AppDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> CommitAsync()
        {
            var result = await _applicationDbContext.SaveChangesAsync();

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();

            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            _repositories[type] = new BaseRepository<TEntity>(_applicationDbContext);

            return (IBaseRepository<TEntity>)_repositories[type];
        }
    }
}
