using System;
using System.Configuration;
using IndiaApplication.acceptance.test.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace IndiaApplication.acceptance.test
{
    [TestFixture]
    public class LogInTest
    {
        private const string DefaultPassword = "abcdefgh";
        private ChromeDriver _webDriver;
        private string _baseUri;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _baseUri = ConfigurationManager.AppSettings.Get("target");
            _webDriver = new ChromeDriver();
        }

        private object generateRandomUser(string password = DefaultPassword)
        {
            int randomInt = new Random().Next(0, 10000);
            return new
                       {
                           Username = "Joe" + randomInt,
                           Email = randomInt + "@home.com",
                           Password = password
                       };
        }


        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void ShouldBeAbleToRegisterOnSite()
        {
            var pageDriver = new PageDriver(_webDriver);
            var homePage = pageDriver.NavigateTo<HomePage>(_baseUri);
            var logInPage = homePage.ClickLogOn();
            logInPage.AssertHasRegistrationLink();
        }

        [Test]
        public void ShouldFailWithShortPassword()
        {
            var pageDriver = new PageDriver(_webDriver);
            var registerUserPage = pageDriver.NavigateTo<RegisterUserPage>(string.Format("{0}/Account/Register", _baseUri));

            var randomUser = generateRandomUser("short");
            var homePage = registerUserPage.RegisterUser(randomUser);
            homePage.AssertErrorMessagePresent();
        }
    }
}