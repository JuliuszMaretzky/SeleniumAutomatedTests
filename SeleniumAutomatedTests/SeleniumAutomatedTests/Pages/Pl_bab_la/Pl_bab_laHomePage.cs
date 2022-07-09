using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumAutomatedTests.Pages.pl_bab_la
{
    public class Pl_bab_laHomePage : Pl_bab_laBasePage
    {
        private By loadingMarker => By.XPath("//h1[contains(text(), 'Słownik online w ')]");
        private By AcceptPrivacyButton => By.Id("onetrust-accept-btn-handler");

        public Pl_bab_laHomePage(IWebDriver driver) : base(driver) { }

        public bool IsLoaded => VerifyIfElementIsVisible(loadingMarker);

        internal void LoadPage()
        {
            Driver.Navigate().GoToUrl("https://pl.bab.la/");
            Driver.Manage().Window.Maximize();
            AcceptPrivacyPolicy();
        }

        private void AcceptPrivacyPolicy()
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AcceptPrivacyButton)).Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
        }
    }
}
