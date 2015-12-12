using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.Infrastructure;

namespace Hyde.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {

        IUnitOfWork _unitofwork;

        public Repository(IUnitOfWork unitofWork)
        {
            if (unitofWork == null)
            {
                throw new ArgumentNullException("UnitOfWork");
            }
            _unitofwork = unitofWork;

        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitofwork;
            }
        }

        public void Add(T item)
        {
            Set().Add(item);
        }

        public void ChangeState(T item, EntityState state)
        {
            var entry = _unitofwork.CurrentDbContext.Entry(item);
            entry.State = state;
        }

        public T Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_unitofwork != null)
                _unitofwork.Dispose();
        }

        public void Edit(T item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> condition = null, params Expression<Func<T, object>>[] includes)
        {
            var query = Include(includes);

            return condition != null ? query.Where(condition) : query;
        }

        public T FindSingle(params object[] keys)
        {
            return Set().Find(keys);
        }

        public T FindSingle(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            var query = Include(includes);

            return query.SingleOrDefault(condition);
        }

        public void Remove(T item)
        {
            Set().Remove(item);
        }

        private DbSet<T> Set()
        {
            return _unitofwork.CurrentDbContext.Set<T>();
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            var query = Set().AsQueryable<T>();

            if (includes != null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public DbRawSqlQuery<T> SqlQuery(string sql, params object[] parameters)
        {
            return Set().SqlQuery(sql, parameters);
        }

        public void Add(IEnumerable<T> items)
        {
            Set().AddRange(items);
        }
    }
}
