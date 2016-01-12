using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;
namespace Hyde.Repository
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 开启一个事务
        /// </summary>
        /// <returns>返回connecction开启的事务</returns>
        DbTransaction BeginTransaction();
        /// <summary>
        /// 提交数据到数据库
        /// </summary>
        /// <returns>返回受影响的行数</returns>
        int Save();
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="transaction">事务</param>
        void Rollback(DbTransaction transaction);
        /// <summary>
        /// Dbcontext，只读
        /// </summary>
        DbContext Context { get; }
        /// <summary>
        /// 执行Sql语句，并返回受影响的行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">sql中的变量，可为空</param>
        /// <returns>返回受影响的行数</returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        IRepository<T> GetRepository<T>() where T : class;
    }
}
