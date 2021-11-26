using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [Test]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountContoller = new AccountController();

            // Act
            var actualResult = accountContoller.ValidateEmail(email);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
