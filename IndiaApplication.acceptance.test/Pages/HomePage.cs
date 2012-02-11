using FluentAssertions;
using OpenQA.Selenium;

namespace IndiaApplication.acceptance.test.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _webDriver;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement LogOnLink
        {
            get { return _webDriver.FindElement(By.LinkText("Log On")); }
        }

        public LogInPage ClickLogOn()
        {
            LogOnLink.Click();
            return new LogInPage(_webDriver);
        }

        public void AssertIsLoggedIn(dynamic user)
        {
            LoggedInName.Text.Should().Be(user.Username);
        }

        private IWebElement LoggedInName
        {
            get { return _webDriver.FindElement(By.CssSelector("#logindisplay b")); }
        }

        public void LogOff()
        {
            _webDriver.FindElement(By.LinkText("Log Off")).Click();
        }
    }
}