using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    internal class Pl_bab_laGamesPage : BasePage
    {
        private By LoadingMarkerLocator => By.XPath("//span[text()='Polecana gra']");

        public Pl_bab_laGamesPage(IWebDriver driver) : base(driver) { }

        public bool IsLoaded => VerifyIfElementIsVisible(LoadingMarkerLocator);

        internal Pl_bab_laGamesPage VeryfiIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "Games page did not load properly");

            return new Pl_bab_laGamesPage(Driver);
        }
    }
}