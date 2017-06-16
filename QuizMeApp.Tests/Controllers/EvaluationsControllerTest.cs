using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizMeApp.Controllers;
using System.Web.Mvc;

namespace QuizMeApp.Tests.Controllers
{

    [TestClass]
    public class EvaluationsControllerTest
    {

       
        [TestMethod]
        public void CreateEvaluation()
        {
            // Arrange
            EvaluationsController controller = new EvaluationsController();
    
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditEvaluationByID(int? id)
        {
            // Arrange
            EvaluationsController controller = new EvaluationsController();

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
