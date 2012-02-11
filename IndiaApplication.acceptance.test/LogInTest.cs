using System;
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

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _webDriver = new ChromeDriver();
        }

        [Test]
        public void ShouldBeAbleToRegisterOnSite()
        {
            var pageDriver = new PageDriver(_webDriver);
            var homePage = pageDriver.NavigateTo<HomePage>("http://localhost:53141");
            var logInPage = homePage.ClickLogOn();
            logInPage.AssertHasRegistrationLink();
        }

        [Test]
        public void ShouldBeAbleToRegisterDirectly()
        {
            var pageDriver = new PageDriver(_webDriver);
            var registerUserPage = pageDriver.NavigateTo<RegisterUserPage>("http://localhost:53141/Account/Register");

            var randomUser = generateRandomUserName();
            HomePage homePage = registerUserPage.RegisterUser(randomUser);
            homePage.AssertIsLoggedIn(randomUser);
            homePage.LogOff();
        }

        private static dynamic generateRandomUserName()
        {
            var randomInt = new Random().Next(0, 10000);
            return new
                       {
                           Username = "Joe" + randomInt,
                           Email = randomInt + "@home.com",
                           Password = DefaultPassword
                       };
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _webDriver.Quit();   
        }
    }
}