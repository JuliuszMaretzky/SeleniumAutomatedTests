using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class Pl_bab_laAboutUsPage : BasePage<Pl_bab_laAboutUsPage>
    {
        #region Locators

        private By LoadingMarkerLocator => By.XPath("//h1[text()='O nas']");
        private By AcceptPrivacyButtonLocator => By.Id("onetrust-accept-btn-handler");

        #endregion

        public Pl_bab_laAboutUsPage(IWebDriver driver) : base(driver)
        {
            pageHandler = this;
        }

        internal Pl_bab_laAboutUsPage LoadPage()
        {
            Driver.Navigate().GoToUrl("https://pl.bab.la/o-nas/");
            Driver.Manage().Window.Maximize();
            AcceptPrivacyPolicy();
            Assert.IsTrue(IsLoaded, "Page was not loaded properly");

            return pageHandler;
        }

        public bool IsLoaded => VerifyIfElementIsVisible(LoadingMarkerLocator);

        internal Pl_bab_laAboutUsPage VerifyIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "About Us page did not load properly");

            return new Pl_bab_laAboutUsPage(Driver);
        }

        private Pl_bab_laAboutUsPage AcceptPrivacyPolicy()
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AcceptPrivacyButtonLocator)).Click();
            }
            catch (NoSuchElementException) { }

            return pageHandler;
        }
    }
}
