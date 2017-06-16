using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizMeApp.Controllers;
using System.Web.Mvc;

namespace QuizMeApp.Tests.Controllers
{
    [TestClass]
    public class CoursControllerTest
    {
      

        [TestMethod]
        public void CreateCours()
        {
            // Arrange
            CoursController controller = new CoursController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditCoursByID(int? id)
        {
            // Arrange
            CoursController controller = new CoursController();

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteCoursByID(int? id)
        {
            // Arrange
            CoursController controller = new CoursController();

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }



    }
}
