using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Repositories;
using UsersAdmin.Controllers;
using DAL.Helper;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace UsersAdmin.Tests.UsersAPItests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GEtUsers_Should_return_1()
        {
            //Repository _respository = new Repository(new NHibernateConection());
            //UsersAPIController controller = new UsersAPIController(_respository);

            //IEnumerable<User> result = controller.Get();
            //Assert.AreEqual(1, result.Count());
        }
    }
}
