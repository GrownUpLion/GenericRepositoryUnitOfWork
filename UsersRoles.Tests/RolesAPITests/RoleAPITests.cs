using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsersAdmin.Controllers;
using Domain.Models;
using DAL.Repositories;
using DAL.Helper;
using System.Collections.Generic;
using System.Linq;

namespace UsersAdmin.Tests.RolesAPITests
{
    [TestClass]
    public class RoleAPITests
    {
        [TestMethod]
        public void GetAllRoles_should_return1()
        {
            NhibernateRepository _respository = new NhibernateRepository(new NHibernateConection());
            RolesAPIController controller = new RolesAPIController(_respository);

            IEnumerable<Role> result = controller.Get();
            Assert.AreEqual(1, result.Count());
        }
    }
}
