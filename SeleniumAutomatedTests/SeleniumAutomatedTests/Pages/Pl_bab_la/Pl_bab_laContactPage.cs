using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class Pl_bab_laContactPage : BasePage<Pl_bab_laContactPage>
    {
        private By LoadingMarkerLocator => By.XPath("//p[text()='We do not translate long texts. bab.la is an online dictionary.']");

        public Pl_bab_laContactPage(IWebDriver driver) : base(driver)
        {
            pageHandler = this;
        }

        public bool IsLoaded => VerifyIfElementIsVisible(LoadingMarkerLocator);

        internal Pl_bab_laContactPage VeryfiIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "About Us page did not load properly");

            return pageHandler;
        }
    }
}