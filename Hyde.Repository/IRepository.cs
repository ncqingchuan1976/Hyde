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
        /// <summary>
        /// 批量将实体追加到实体集中
        /// </summary>
        /// <param name="items">要追加的实体集</param>
        void Add(IEnumerable<T> items);
        /// <summary>
        /// 断开状态下，修改实体
        /// </summary>
        /// <param name="item">需要修改的实体</param>
        /// <param name="properties">需要修改实体的属性集合，可为空</param>
        void Edit(T item, params string[] properties);

        /// <summary>
        /// 断开状态下删除实体
        /// </summary>
        /// <param name="item">需要删除的实体</param>
        void Delete(T item);

        /// <summary>
        /// 断开状态下将实体集合移除
        /// </summary>
        /// <param name="items">需要移除的实体集合</param>
        void Delete(IEnumerable<T> items);

        /// <summary>
        /// 从实体集中移除一个实体
        /// </summary>
        /// <param name="item"></param>
        void Remove(T item);
        /// <summary>
        /// 批量将实体从集合中移除
        /// </summary>
        /// <param name="items">需要移除的实体</param>
        void Remove(IEnumerable<T> items);

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="item">返回创建成功的实体</param>
        /// <returns></returns>
        T Create();
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
        /// <summary>
        /// 当前的工作单元
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
        /// <summary>
        /// 改变实体状态
        /// </summary>
        /// <param name="item">要更改的实体</param>
        /// <param name="state">需要更改的状态</param>
        void ChangeState(T item, EntityState state);
        /// <summary>
        /// 通过执行Sql,返回实体集合
        /// </summary>
        /// <param name="sql">需执行的Sql语句</param>
        /// <param name="parameters">Sql语句中的变量</param>
        /// <returns>返回执行成功Sql的实体集合</returns>
        DbRawSqlQuery<T> SqlQuery(string sql, params object[] parameters);
        /// <summary>
        /// 根据条件检查实体是否已经存在
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回bool值，true：存在，false：不存在</returns>
        bool Exist(Expression<Func<T, bool>> condition);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        DbEntityEntry<T> Entry(T item);
    }
}
