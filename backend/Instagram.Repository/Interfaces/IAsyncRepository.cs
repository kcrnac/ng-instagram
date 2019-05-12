using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Instagram.Repository.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> FindAll();
        Task<IReadOnlyList<T>> FindBy(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveAsync();
    }
}
