using Dapper.DataRepositories.Demo.Models;
using Dapper.DataRepositories.Demo.Repositories;
using System;
using System.Collections.Generic;
using System.Transactions;
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

        /// <summary>
        /// 
        /// </summary>
        public void AddUsers(IEnumerable<User> users)
        { 
            //This functions needs to be handled as an atomic transaction

            try
            {
                using (var lifetimeScope = IoC.Instance.BeginLifetimeScope())
                {
                    using (var transaction = new TransactionScope())
                    {
                        var repository = IoC.Instance.Resolve<IRepository>();

                        foreach (var user in users)
                        {
                            repository.Add<User>(user);
                        }

                        transaction.Complete();
                    }
                }
            }
            catch (Exception ex)
            { 
            }
        }
    }
}
