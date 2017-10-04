using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.DatabaseMigration;
using System.Configuration;
using Domain.Interfaces;
using Domain.Models;
using DAL.Repositories;
using DAL.Helper;
using System.Linq;
using System.Collections.Generic;

namespace UsersAdmin.Tests.NHibernateMigration
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateDatabaseTestAndAddFirstRole()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
            Assert.IsTrue(NHMigrations.CreateDatabase(connectionString));
        }

        [TestMethod]
        public void AddRoleAdmin()
        {
            Role role = new Role
            {
                Name = "Admin"
            };
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            //using (Repository session = new Repository(new NHibernateConection()))
            //{
            //    session.Save(role);
            //}
        }

        [TestMethod]
        public void GetRoles()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            //using (Repository session = new Repository(new NHibernateConection()))
            //{
            //    List<Role> roles = session.GetAll<Role>(0,100).ToList<Role>();
            //    Assert.AreEqual(1,roles.Count);
            //}
        }

        [TestMethod]
        public void GetRoleAdmin()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            //using (IRepository<IEntity> session = new Repository(new NHibernateConection()))
            //{
            //    var role = session.GetById<Role>(1);
            //    Assert.Equals(((Role)role).Name, "Admin");
            //}
        }


        [TestMethod]
        public void GetByPropertyName()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            //using (Repository session = new Repository(new NHibernateConection()))
            //{
            //    Role role = session.GetByName<Role>("Name","Admin");
            //    Assert.AreEqual("Admin", role.Name);
            //}
        }
    }
}
