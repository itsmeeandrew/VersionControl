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
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountContoller = new AccountController();

            // Act
            var actualResult = accountContoller.ValidateEmail(email);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [
            Test,
            TestCase("jeLSzójeLSzó", false),
            TestCase("JELSZÓJELSZÓ", false),
            TestCase("jelszójelszó", false),
            TestCase("rövid", false),
            TestCase("Jelszó123", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidatePassword(password);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TestRegisterHappyPath(string email, string password)
        {
            var accountController = new AccountController();
            var actualResult = accountController.Register(email, password);
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }
    }
}
