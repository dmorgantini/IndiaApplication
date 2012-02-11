using OpenQA.Selenium;

namespace IndiaApplication.acceptance.test.Pages
{
    public class RegisterUserPage
    {
        private readonly IWebDriver _webDriver;

        public RegisterUserPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public HomePage RegisterUser(dynamic user)
        {
            UserName.SendKeys(user.Username);
            Email.SendKeys(user.Email);
            Password.SendKeys(user.Password);
            ConfirmPassword.SendKeys(user.Password);
            Register.Click();
            return new HomePage(_webDriver);
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
    }
}