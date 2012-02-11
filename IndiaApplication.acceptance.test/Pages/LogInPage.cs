using FluentAssertions;
using OpenQA.Selenium;

namespace IndiaApplication.acceptance.test.Pages
{
    public class LogInPage
    {
        private readonly IWebDriver _webDriver;

        public LogInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement RegisterLink
        {
            get { return _webDriver.FindElement(By.LinkText("Register")); }
        }

        public void AssertHasRegistrationLink()
        {
            RegisterLink.Displayed.Should().BeTrue();
        }
    }
}