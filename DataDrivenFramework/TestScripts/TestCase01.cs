using DataDrivenFramework.Framework;
using DataDrivenFramework.Utilities;


namespace DataDrivenFramework.TestScripts
{
    public class TestCase01 : TestBase
    {

        [Test]
        public void TestLogin()
        {
            // Arrange: Set up the test data and expected results
            string username = ConfigReader.GetUsername();
            string password = ConfigReader.GetPassword();
        //    string expectedTitle = "Dashboard / nopCommerce administration";

            Console.WriteLine($"Username: {username}");
            // Act: Perform the login action
            // LoginPage loginPage = new LoginPage(Driver);
            // loginPage.Login(username, password);

            // Assert: Verify that the login was successful by checking the page title
            // Assert.AreEqual(expectedTitle, Driver.Title, "Login failed or page title is incorrect.");
        }

    }
}