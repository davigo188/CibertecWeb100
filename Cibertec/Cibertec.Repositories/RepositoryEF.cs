using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cibertec.Repositories
{
    public class RepositoryEF<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        public RepositoryEF(DbContext context)
        {
            _context = context;
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return _context.Set<T>();
        }

        public int Insert(T entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public bool Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
