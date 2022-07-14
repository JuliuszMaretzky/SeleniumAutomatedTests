using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class Pl_bab_laLifeAbroadPage : BasePage<Pl_bab_laLifeAbroadPage>
    {
        private By LoadingMarkerLocator => By.ClassName("language-label");

        public Pl_bab_laLifeAbroadPage(IWebDriver driver) : base(driver)
        {
            pageHandler = this;
        }

        public bool IsLoaded => VerifyIfElementIsVisible(LoadingMarkerLocator);

        internal Pl_bab_laLifeAbroadPage VerifyIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "Life Abroad page did not load properly");

            return pageHandler;
        }
    }
}
