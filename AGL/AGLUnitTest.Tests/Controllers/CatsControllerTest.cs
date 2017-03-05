using AGLTest.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGLTest.Results;
using System.Net;

namespace AGLUnitTest.Tests.Controllers
{
    [TestClass]
    public class CatsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CatsController controller = new CatsController();

            // Act
            NewtonJsonResult result = controller.GetAllCats() as NewtonJsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
