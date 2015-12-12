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
        /// <returns>返回一个事务</returns>
        DbTransaction BeginTransaction();
        /// <summary>
        /// 提交数据到数据库
        /// </summary>
        /// <returns>返回受影响的行数</returns>
        int Save();

        void Rollback(DbTransaction transaction);

        DbContext CurrentDbContext { get; }

        int ExecuteSqlCommand(string sql, params object[] parameters);
    }
}
