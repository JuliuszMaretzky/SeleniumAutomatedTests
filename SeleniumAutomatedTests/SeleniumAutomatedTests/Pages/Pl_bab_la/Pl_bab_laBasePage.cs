using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumAutomatedTests.Pages.pl_bab_la
{
    public class Pl_bab_laBasePage
    {
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }

        public Pl_bab_laBasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected bool VerifyIfElementIsVisible(By locator)
        {
            try
            {
                var loadingPageMarker = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return loadingPageMarker.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
