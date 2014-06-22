using Autofac;
using Dapper.DataRepositories.Demo.Models;
using Dapper.DataRepositories.Demo.Repositories;
using MicroOrm.Pocos.SqlGenerator;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.DataRepositories.Demo
{
    public class IoC : ContainerBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly static IoC _instance = new IoC();

        /// <summary>
        /// 
        /// </summary>
        private static object _lock;

        /// <summary>
        /// 
        /// </summary>
        private IContainer _componentsContainer;

        /// <summary>
        /// 
        /// </summary>
        public static IoC Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IContainer GetComponentsContainer()
        {
            if (_componentsContainer == null)
            {
                lock (_lock)
                {
                    if (_componentsContainer == null)
                        _componentsContainer = this.Build();
                }
            }

            return _componentsContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return GetComponentsContainer().Resolve<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        private IoC()
        {
            _lock = new object();
            ConfigureDependencies();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConfigureDependencies()
        {
            //Configure all your depedendencies here!!

            //Database connection
            var connectionString = ConfigurationManager.ConnectionStrings["DapperDemo"].ConnectionString;
            this.Register(c => new SqlConnection(connectionString)).As<IDbConnection>().InstancePerLifetimeScope();

            //Sql generators
            this.RegisterType<SqlGenerator<User>>().As<ISqlGenerator<User>>().SingleInstance();

            //Repository
            this.RegisterType<Repository>().As<IRepository>().SingleInstance();
        }
    }
}