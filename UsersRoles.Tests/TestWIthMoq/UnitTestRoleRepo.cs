using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Interfaces;
using Moq;
using DAL.Helper;

namespace UsersAdmin.Tests.TestWIthMoq
{
    [TestClass]
    public class UnitTestRoleRepo
    {
        [TestMethod]
        public void Test_Save_Admin_Role_once()
        {
            Role role = new Role
            {
                Name = "Admin"
            };
            Mock<IRepository<Role>> mockRepository = new Mock<IRepository<Role>>();
            mockRepository.Setup(x => x.Save(role));

            mockRepository.Object.Save(role);
            mockRepository.Verify(x => x.Save(role), Times.Once()); //Assert that the Add method was called once
        }



        [TestMethod]
        public void Get_Role_By_Id()
        {
            Role role = new Role
            {
                Id = 1,
                Name = "Admin"
            };
            Mock<IRepository<Role>> mockRepository = new Mock<IRepository<Role>>();
            mockRepository.Setup(x => x.Save(role));
            mockRepository.Object.Save(role);


            mockRepository.Setup(x => x.GetById<Role>(1))
            .Returns(role); //return role
            mockRepository.Object.GetById<Role>(1).Equals(role); //Assert expected value equal to actual value
            mockRepository.Verify(x => x.GetById<Role>(role.Id), Times.Once()); //Assert that the Get method was called once

        }

        [TestMethod]
        public void Delete_Role()
        {
            Role role = new Role
            {
                Id = 1,
                Name = "Admin"
            };
            Mock<IRepository<Role>> mockRepository = new Mock<IRepository<Role>>();
            mockRepository.Setup(x => x.Save(role));
            mockRepository.Object.Save(role);


            mockRepository.Setup(x => x.GetById<Role>(1))
            .Returns(role); //return role
            mockRepository.Object.GetById<Role>(1).Equals(role); //Assert expected value equal to actual value


            mockRepository.Setup(x => x.Delete(role));
            mockRepository.Object.Delete(role);

            mockRepository.Setup(x => x.GetById<Role>(1))
            .Returns(role); //return role
            mockRepository.Object.GetById<Role>(1).Equals(null); //Assert expected value equal to actual value

            mockRepository.Verify(x => x.Delete(role), Times.Once); //Assert that the Delete method was called once



        }
    }
}
