using Dapper.DataRepositories.Demo.Models;
using Dapper.DataRepositories.Demo.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace Dapper.DataRepositories.Demo.Controllers.API
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        private IRepository Repository;

        /// <summary>
        /// 
        /// </summary>
        public UsersController(IRepository repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return Repository.GetAll<User>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Get(int id)
        {
            return Repository.GetFirst<User>(new { id });
        }
    }
}
