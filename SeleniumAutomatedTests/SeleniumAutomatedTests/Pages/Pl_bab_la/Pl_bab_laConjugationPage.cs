using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class Pl_bab_laConjugationPage: BasePage<Pl_bab_laConjugationPage>
    {
        #region Locators

        private By LoadingMarkerLocator => By.XPath("//div[contains(text(), 'Najpopularniejsze czasowniki')]");

        #endregion

        public Pl_bab_laConjugationPage(IWebDriver driver) : base(driver)
        {
            pageHandler = this;
        }

        public bool IsLoaded => VerifyIfElementIsVisible(LoadingMarkerLocator);

        internal Pl_bab_laConjugationPage VerifyIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "Conjugation page did not load properly");

            return pageHandler;
        }
    }
}
