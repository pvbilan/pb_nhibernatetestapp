using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateTestApp.DAL
{
    public sealed class PostgreSqlManager
    {
        #region Variables

        private static String _connectionString;
        private static ISessionFactory _sessionFactory;

        #endregion Variables

        #region Properties

        private static ISessionFactory sessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                                              .Database(FluentNHibernate.Cfg.Db.PostgreSQLConfiguration.PostgreSQL82.ConnectionString(_connectionString).ShowSql())
                                              .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                                              .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, false))
                                              .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        #endregion Properties

        #region Methods

        public static void Initialize(String _connectionString)
        {
            PostgreSqlManager._connectionString = _connectionString;
        }

        public static ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }

        #endregion Methods
    }
}