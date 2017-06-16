using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using QuizMeApp.Controllers;

namespace QuizMeApp.Tests.Controllers
{
    [TestClass]
    public class PasserEvaluationControllerTest
    {
        [TestMethod]
        public void IndexPasserEvaluation()
        {
            // Arrange
            PasserEvaluationController controller = new PasserEvaluationController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }


}