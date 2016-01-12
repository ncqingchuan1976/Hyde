using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private DbContext _dbcontext;

        public UnitOfWork(DbContext dbcontext)
        {
            if (dbcontext == null)
            {
                throw new ArgumentNullException("DbContext");
            }

            _dbcontext = dbcontext;
        }

        public DbContext Context
        {
            get
            {
                return _dbcontext;
            }
        }

        public DbTransaction BeginTransaction()
        {
            var connection = _dbcontext.Database.Connection;

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return connection.BeginTransaction();
        }

        public void Dispose()
        {
            if (_dbcontext != null)
                _dbcontext.Dispose();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbcontext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(this);
        }

        public void Rollback(DbTransaction transaction)
        {
            transaction.Rollback();
        }

        public int Save()
        {
            return _dbcontext.SaveChanges();
        }
    }
}
