using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelerikAcademyASPNETWebApp.Account.Interfaces;

namespace TelerikAcademyASPNETWebApp.Tests.AccountManagement
{
    [TestClass]
    public class AccountManagementTest
    {
        #region Login
        [TestMethod]
        public void Login_WithEmptyUsername_ShouldReturnFalse()
        {
            IAccountManagement management = new TelerikAcademyASPNETWebApp.Account.Models.AccountManagement();
            bool result = management.UserLogin(new Account.BusinessLayer.LoginViewModel()
            {
                Username = "",
                Password = "Test",
                RememberMe = false
            });
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Login_WithEmptyPassword_ShouldReturnFalse()
        {
            IAccountManagement management = new TelerikAcademyASPNETWebApp.Account.Models.AccountManagement();
            bool result = management.UserLogin(new Account.BusinessLayer.LoginViewModel()
            {
                Username = "Test",
                Password = "",
                RememberMe = false
            });
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Login_WithNotCorrectData_ShouldReturnFalse()
        {
            IAccountManagement management = new TelerikAcademyASPNETWebApp.Account.Models.AccountManagement();
            bool result = management.UserLogin(new Account.BusinessLayer.LoginViewModel()
            {
                Username = "Test",
                Password = "Testov",
                RememberMe = false
            });
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Login_WithCorrectData_ShouldReturnTrue()
        {
            IAccountManagement management = new TelerikAcademyASPNETWebApp.Account.Models.AccountManagement();
            bool result = management.UserLogin(new Account.BusinessLayer.LoginViewModel()
            {
                Username = "Test",
                Password = "Test",
                RememberMe = false
            });
            Assert.IsTrue(result);
        }
        #endregion

        #region Register
        [TestMethod]
        public void Register_WithEmptyUsername_ShouldReturnFalse()
        {
            IAccountManagement management = new TelerikAcademyASPNETWebApp.Account.Models.AccountManagement();
            bool result = management.UserRegister(new Account.BusinessLayer.RegisterViewModel()
            {
                Username = "",
                Password = "Test123",
                ConfirmPassword = "Test123",
                UserRoles = "2"
            });
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Register_WithEmptyPassword_ShouldReturnFalse()
        {
            IAccountManagement management = new TelerikAcademyASPNETWebApp.Account.Models.AccountManagement();
            bool result = management.UserRegister(new Account.BusinessLayer.RegisterViewModel()
            {
                Username = "Test123",
                Password = "",
                ConfirmPassword = "",
                UserRoles = "2"
            });
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Register_WithEmptyUserRoles_ShouldReturnFalse()
        {
            IAccountManagement management = new TelerikAcademyASPNETWebApp.Account.Models.AccountManagement();
            bool result = management.UserRegister(new Account.BusinessLayer.RegisterViewModel()
            {
                Username = "Test123",
                Password = "Test123",
                ConfirmPassword = "Test123",
                UserRoles = ""
            });
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Register_WithCorrectData_ShouldReturnTrue()
        {
            IAccountManagement management = new TelerikAcademyASPNETWebApp.Account.Models.AccountManagement();
            bool result = management.UserRegister(new Account.BusinessLayer.RegisterViewModel()
            {
                Username = "Test123",
                Password = "Test123",
                ConfirmPassword = "Test123",
                UserRoles = "2"
            });
            Assert.IsTrue(result);
        }
        #endregion
    }
}
