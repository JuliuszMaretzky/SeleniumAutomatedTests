using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomatedTests.Pages.Pl_bab_la;

namespace SeleniumAutomatedTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        [OneTimeSetUp]
        public virtual void Setup()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }

        [OneTimeTearDown]
        public virtual void Teardown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
