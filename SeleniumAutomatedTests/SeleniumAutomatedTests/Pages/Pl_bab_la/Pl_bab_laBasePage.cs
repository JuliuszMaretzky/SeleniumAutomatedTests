using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomatedTests.Pages.Pl_bab_la;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumAutomatedTests.Pages.pl_bab_la
{
    public class Pl_bab_laBasePage
    {
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }

        #region Pages Fields

        private Pl_bab_laHomePage pl_bab_laHomePage;
        private Pl_bab_laAboutUsPage pl_bab_laAboutUsPage;

        #endregion

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

        #region Page Objects

        public Pl_bab_laHomePage GetPl_bab_laHomePageObject()
        {
            if (pl_bab_laHomePage == null)
            {
                pl_bab_laHomePage = new Pl_bab_laHomePage(Driver);
            }

            return pl_bab_laHomePage;
        }

        public Pl_bab_laAboutUsPage GetPl_bab_laAboutUsPageObject()
        {
            if (pl_bab_laAboutUsPage == null)
            {
                pl_bab_laAboutUsPage = new Pl_bab_laAboutUsPage(Driver);
            }

            return pl_bab_laAboutUsPage;
        }

        #endregion
    }
}
