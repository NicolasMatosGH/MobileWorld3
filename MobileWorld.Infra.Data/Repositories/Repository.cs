using Microsoft.EntityFrameworkCore;
using MobileWorld.Core.DomainObjects;
using MobileWorld.Domain.Interfaces;
using MobileWorld.Infra.Data.Context;
using System.Linq.Expressions;

namespace MobileWorld.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly MobileWorldDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(MobileWorldDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        protected IQueryable<T> Query()
        {
            return DbSet;
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }

        public long Count()
        {
            return DbSet.LongCount();
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            var result = DbSet.LongCount(predicate);
            return result;
        }
    }
}
