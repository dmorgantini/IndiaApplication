using OpenQA.Selenium;
using FluentAssertions;

namespace IndiaApplication.acceptance.test.Pages
{
    public class RegisterUserPage
    {
        private readonly IWebDriver _webDriver;

        public RegisterUserPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public RegisterUserPage RegisterUser(dynamic user)
        {
            UserName.SendKeys(user.Username);
            Email.SendKeys(user.Email);
            Password.SendKeys(user.Password);
            ConfirmPassword.SendKeys(user.Password);
            Register.Click();
            return new RegisterUserPage(_webDriver);
        }

        public void AssertErrorMessagePresent()
        {
            PasswordValidationError.Displayed.Should().BeTrue();
        }

        private IWebElement Register
        {
            get { return _webDriver.FindElement(By.Id("Register")); }
        }

        private IWebElement ConfirmPassword
        {
            get { return _webDriver.FindElement(By.Name("ConfirmPassword")); }
        }

        private IWebElement Password
        {
            get { return _webDriver.FindElement(By.Name("Password")); }
        }

        private IWebElement Email
        {
            get { return _webDriver.FindElement(By.Name("Email")); }
        }

        private IWebElement UserName
        {
            get { return _webDriver.FindElement(By.Name("UserName")); }
        }

        private IWebElement PasswordValidationError
        {
            get { return _webDriver.FindElement(By.CssSelector("#Password.input-validation-error")); }
        }
    }
}