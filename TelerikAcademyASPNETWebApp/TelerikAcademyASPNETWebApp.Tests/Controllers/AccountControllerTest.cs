using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelerikAcademyASPNETWebApp.Controllers;
using System.Web.Mvc;

namespace TelerikAcademyASPNETWebApp.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Login_ViewLoad()
        {
            // Arrange
            AccountController accountService = new AccountController();

            // Act
            ViewResult result = accountService.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Register_ViewLoad()
        {
            // Arrange
            AccountController accountService = new AccountController();

            // Act
            ViewResult result = accountService.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
