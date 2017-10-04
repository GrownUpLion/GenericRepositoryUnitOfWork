using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models;
using DAL.Repositories;
using DAL.Helper;
using System.Configuration;
using DAL.NHUnitOfWork;
using System.Collections.Generic;

namespace UsersAdmin.Tests.UsersTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            User user = new User
            {
                UserName = "JosePelayo",
                FirstName = "Jose",
                LastName = "Pelayo",
                Email = "jmpelayot@gmail.com",
                Active = true
            };



            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            NhibernateRepository _respository = new NhibernateRepository(new NHibernateConection());
            using (NHUnitOfWork unitOfWOrk = new NHUnitOfWork(_respository))
            {
                Role role = unitOfWOrk._repository.GetById<Role>(1);
                user.Roles.Add(role);
                unitOfWOrk._repository.Save(user);
                unitOfWOrk.Commit();
            }
        }


        [TestMethod]
        public void TestUpdate_User()
        {
            User user = new User()
            {
                Active = true,
                Email = "new values",
                FirstName = "new values",
                LastName = "new values",
                Id = 4,
                Roles = new List<Role>(),
                UserName = "new values",
            };

            NhibernateRepository _respository = new NhibernateRepository(new NHibernateConection());
            using (NHUnitOfWork unitOfWOrk = new NHUnitOfWork(_respository))
            {
                Role role = unitOfWOrk._repository.GetById<Role>(1);
                user.Roles.Add(role);
                unitOfWOrk._repository.Update(user);
                unitOfWOrk.Commit();
            }
        }
    }
}
