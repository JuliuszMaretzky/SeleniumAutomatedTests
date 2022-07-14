using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class BasePage<T>
    {
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }
        protected T pageHandler { get; set; }

        public BasePage(IWebDriver driver)
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

        protected string ReturnKeyFromDictionaryWhenValueIsGiven(Dictionary<string, string> dictionary, string value)
        {
            foreach (var keyValuePair in dictionary)
            {
                if (keyValuePair.Value == value)
                {
                    return keyValuePair.Key;
                }
            }

            return null;
        }
    }
}
