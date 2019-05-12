using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Instagram.Data;
using Instagram.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Repository.Implementations
{
    public abstract class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected internal ApplicationDbContext Context { get; set; }

        protected BaseRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public async Task<IReadOnlyList<T>> FindAll()
        {
            return await Context.Set<T>()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> FindBy(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>()
                .Where(expression)
                .ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
