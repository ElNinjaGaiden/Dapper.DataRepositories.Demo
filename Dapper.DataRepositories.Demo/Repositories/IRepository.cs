using System.Collections.Generic;

namespace Dapper.DataRepositories.Demo.Repositories
{
    public interface IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        IEnumerable<T> GetWhere<T>(object filters) where T : new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>() where T : new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        T GetFirst<T>(object filters) where T : new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        void Add<T>(T instance) where T : new();
    }
}
