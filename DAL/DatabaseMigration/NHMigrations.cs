using DAL.MappingClasses;
using Domain.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseMigration
{
    public static class NHMigrations
    {

        private static ISessionFactory _sessionFactory;

        public static bool CreateDatabase(string connectionString)
        {
            try
            {
                var configuration = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .BuildConfiguration();

                var exporter = new SchemaExport(configuration);
                exporter.Execute(true, true, false);

                _sessionFactory = configuration.BuildSessionFactory();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool AddRoleAdmin(string connectionString)
        {
            try
            {
                Role role = new Role
                {
                    Name = "Admin"
                };
                using (ISession session = _sessionFactory.OpenSession())
                    session.Save(role);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
