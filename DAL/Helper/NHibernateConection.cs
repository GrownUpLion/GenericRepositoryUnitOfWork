using DAL.MappingClasses;
using Domain.Interfaces;
using Domain.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public class NHibernateConection : INHConnection
    {

        private static readonly ISessionFactory _sessionFactory;

        public ISession Session { get; set; }

        static NHibernateConection()
        {
            _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ShowSql().ConnectionString(x => x.FromConnectionStringWithKey("DefaultConnectionString")))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
               .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
               .BuildSessionFactory();
        }


        public NHibernateConection()
        {
            Session = _sessionFactory.OpenSession();
        }


        public void Dispose()
        {
            Session.Close();
            Session.Dispose();
            Session = null;
        }
    }
}
