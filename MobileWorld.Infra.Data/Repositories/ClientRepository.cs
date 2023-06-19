using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MobileWorld.Domain.Entities;
using MobileWorld.Domain.Interfaces;
using MobileWorld.Infra.Data.Context;

namespace MobileWorld.Infra.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(MobileWorldDbContext context) : base(context)
        {
        }

        public Client GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var client = context.FirstOrDefault(c => c.Id == id);
            return client;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            var context = DbSet.AsQueryable();
            var client = await context.FirstOrDefaultAsync(c => c.Id == id);
            return client;
        }

        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public async Task<IEnumerable<Client>> SearchAsync(Expression<Func<Client, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return await context.Where(predicate).ToListAsync();
        }

        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public Client Add(Client entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<Client> AddAsync(Client entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public Client Update(Client entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Client, bool>> expression)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(expression);
            DbSet.RemoveRange(entities);
        }
    }
}
