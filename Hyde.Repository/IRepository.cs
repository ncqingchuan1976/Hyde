using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace Hyde.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 追加一个实体到实体集合
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);

        void Add(IEnumerable<T> items);

        void Edit(T item, params string[] properties);

        /// <summary>
        /// 从实体集中移除一个实体
        /// </summary>
        /// <param name="item"></param>
        void Remove(T item);
        /// <summary>
        /// 修改实体集合中的一个实体
        /// </summary>
        /// <param name="item"></param>
        void Edit(T item);
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="item">返回创建成功的实体</param>
        /// <returns></returns>
        T Create(T item);
        /// <summary>
        /// 根据主键查询并返回查询到的实体
        /// </summary>
        /// <param name="keys">主键</param>
        /// <returns>返回已查找到的实体</returns>
        T FindSingle(params object[] keys);
        /// <summary>
        /// 根据条件查询并返回查询到的实体集合
        /// </summary>
        /// <param name="condition">查询条件，可为空</param>
        /// <param name="includes">Include加载，可为空</param>
        /// <returns>返回已查找到的集合</returns>
        IQueryable<T> Find(Expression<Func<T, bool>> condition = null, params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// 根据条件查询并返回查询到的实体
        /// </summary>
        /// <param name="condition">查询条件，可为空</param>
        /// <param name="includes">Includes加载，可为空</param>
        /// <returns>返回已查询到的实体</returns>
        T FindSingle(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        IUnitOfWork UnitOfWork { get; }
        /// <summary>
        /// 改变实体状态
        /// </summary>
        /// <param name="item">要更改的实体</param>
        /// <param name="state">需要更改的状态</param>
        void ChangeState(T item, EntityState state);

        DbRawSqlQuery<T> SqlQuery(string sql, params object[] parameters);

    }
}
