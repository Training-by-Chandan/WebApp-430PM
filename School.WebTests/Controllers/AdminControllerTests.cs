using Microsoft.VisualStudio.TestTools.UnitTesting;
using School.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace School.Web.Controllers.Tests
{
    [TestClass()]
    public class AdminControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var admin = new AdminController();
            var res = admin.Index(1) as ViewResult;
            Assert.IsNotNull(res);
            var resultAction = admin.Index(1);
            Assert.IsInstanceOfType(resultAction, typeof(ViewResult));

            res = admin.Index(0) as ViewResult;
            Assert.IsNotNull(res);
            resultAction = admin.Index(0);
            Assert.IsInstanceOfType(resultAction, typeof(ViewResult));
        }

        [TestMethod()]
        public void RolesTest()
        {
            //Assert.pass();
        }

        [TestMethod()]
        public void RoleCreateTest()
        {
            // Assert.Fail();
        }

        [TestMethod()]
        public void RoleCreateTest1()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void UsersTest()
        {
            // Assert.Fail();
        }

        [TestMethod()]
        public void UsersParialTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void UserCreateTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void UserCreateTest1()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void SendemailTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void SendEmailTest()
        {
            //Assert.Fail();
        }
    }
}