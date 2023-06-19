using Microsoft.EntityFrameworkCore;
using MobileWorld.Domain.Entities;
using MobileWorld.Domain.Interfaces;
using MobileWorld.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Infra.Data.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(MobileWorldDbContext context) : base(context)
        {
        }

        public OrderItem GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var orderItem = context.FirstOrDefault(c => c.Id == id);
            return orderItem;
        }

        public async Task<OrderItem> GetByIdAsync(Guid id)
        {
            var context = DbSet.AsQueryable();
            var OrderItem = await context.FirstOrDefaultAsync(c => c.Id == id);
            return OrderItem;
        }

        public IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public async Task<IEnumerable<OrderItem>> SearchAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return await context.Where(predicate).ToListAsync();
        }

        public IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public OrderItem Add(OrderItem entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<OrderItem> AddAsync(OrderItem entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public OrderItem Update(OrderItem entity)
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

        public void Remove(Expression<Func<OrderItem, bool>> expression)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(expression);
            DbSet.RemoveRange(entities);
        }
    }
}
