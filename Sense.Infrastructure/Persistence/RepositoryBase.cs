using Sense.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(SenseDbContext context) => _context = context;
        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression);
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Create(List<T> entities) => _context.Set<T>().AddRange(entities);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public void ClearAll(Expression<Func<T, bool>> expression) => _context.Set<T>().RemoveRange(FindByCondition(expression));
        public void ClearAll() => _context.Set<T>().RemoveRange(_context.Set<T>());
        public void ClearAll(List<T> entities) => _context.Set<T>().RemoveRange(entities);
    }
}