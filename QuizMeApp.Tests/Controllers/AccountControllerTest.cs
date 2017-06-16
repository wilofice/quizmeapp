using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizMeApp.Controllers;
using System.Web.Mvc;

namespace QuizMeApp.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Login(string returnUrl)
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            ViewResult result = controller.Login(returnUrl) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
