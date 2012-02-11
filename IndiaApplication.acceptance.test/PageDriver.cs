using System;
using OpenQA.Selenium;

namespace IndiaApplication.acceptance.test
{
    public class PageDriver
    {
        private readonly IWebDriver _webDriver;

        public PageDriver(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public T NavigateTo<T>(string target)
        {
            INavigation navigation = _webDriver.Navigate();
            navigation.GoToUrl(target);
            var instance = (T) Activator.CreateInstance(typeof (T), _webDriver);
            return instance;
        }
    }
}