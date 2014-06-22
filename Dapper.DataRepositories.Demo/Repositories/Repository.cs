using MicroOrm.Pocos.SqlGenerator;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dapper.DataRepositories.Demo.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class Repository : DataConnection, IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public Repository(IDbConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        public IEnumerable<T> GetWhere<T>(object filters) where T : new()
        {
            //Creates the sql generator
            var sqlGenerator = IoC.Instance.Resolve<ISqlGenerator<T>>();

            //Creates the query 
            var query = sqlGenerator.GetSelect(filters);

            //Execute the query
            return Connection.Query<T>(query, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>() where T : new()
        {
            //Creates the sql generator
            var sqlGenerator = IoC.Instance.Resolve<ISqlGenerator<T>>();

            //Creates the query 
            var query = sqlGenerator.GetSelectAll();

            //Execute the query
            return Connection.Query<T>(query);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        public T GetFirst<T>(object filters) where T : new()
        {
            //Creates the sql generator
            var sqlGenerator = IoC.Instance.Resolve<ISqlGenerator<T>>();

            //Creates the query 
            var query = sqlGenerator.GetSelect(filters);

            //Execute the query
            return Connection.Query<T>(query, filters).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public void Add<T>(T instance) where T : new()
        {
            //Creates the sql generator
            var sqlGenerator = IoC.Instance.Resolve<ISqlGenerator<T>>();

            //Creates the query 
            var query = sqlGenerator.GetInsert();

            //Execute the query
            Connection.Execute(query, instance);
        }
    }
}