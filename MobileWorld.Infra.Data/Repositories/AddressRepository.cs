﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MobileWorld.Domain.Entities;
using MobileWorld.Domain.Interfaces;
using MobileWorld.Infra.Data.Context;


namespace MobileWorld.Infra.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(MobileWorldDbContext context) : base(context)
        {
        }

        public Address GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var address = context.FirstOrDefault(x => x.Id == id);
            return address;
        }

        public async Task<Address> GetByIdAsync(Guid id)
        {
            var context = DbSet.AsQueryable();
            var address = await context.FirstOrDefaultAsync(x => x.Id == id);
            return address;
        }

        public IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate)
        {
            var context = DbSet.AsQueryable();

            return context.Where(predicate).ToList();
        }

        public async Task<IEnumerable<Address>> SearchAsync(Expression<Func<Address, bool>> predicate)
        {
            var context = DbSet.AsQueryable();

            return await context.Where(predicate).ToListAsync();
        }

        public IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public Address Add(Address entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<Address> AddAsync(Address entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public Address Update(Address entity)
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

        public void Remove(Expression<Func<Address, bool>> expression)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(expression);
            DbSet.RemoveRange(entities);
        }
    }
}
