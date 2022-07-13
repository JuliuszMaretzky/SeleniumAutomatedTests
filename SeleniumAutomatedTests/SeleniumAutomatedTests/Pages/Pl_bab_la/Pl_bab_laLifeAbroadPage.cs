using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class Pl_bab_laLifeAbroadPage : BasePage
    {
        private By loadingMarkerLocator => By.ClassName("language-label");

        public Pl_bab_laLifeAbroadPage(IWebDriver driver) : base(driver) { }

        public bool IsLoaded => VerifyIfElementIsVisible(loadingMarkerLocator);

        internal Pl_bab_laAboutUsPage VerifyIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "Life Abroad page did not load properly");

            return new Pl_bab_laAboutUsPage(Driver);
        }
    }
}
