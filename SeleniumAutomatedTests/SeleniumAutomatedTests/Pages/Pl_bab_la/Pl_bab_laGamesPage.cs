using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    internal class Pl_bab_laGamesPage : BasePage<Pl_bab_laGamesPage>
    {
        private By LoadingMarkerLocator => By.XPath("//span[text()='Polecana gra']");

        public Pl_bab_laGamesPage(IWebDriver driver) : base(driver)
        {
            pageHandler = this;
        }

        public bool IsLoaded => VerifyIfElementIsVisible(LoadingMarkerLocator);

        internal Pl_bab_laGamesPage VeryfiIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "Games page did not load properly");

            return pageHandler;
        }
    }
}