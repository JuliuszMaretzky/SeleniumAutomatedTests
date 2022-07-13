﻿using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class Pl_bab_laAboutUsPage : BasePage
    {
        private By loadingMarkerLocator => By.XPath("//h1[text()='O nas']");

        public Pl_bab_laAboutUsPage(IWebDriver driver) : base(driver) { }

        public bool IsLoaded => VerifyIfElementIsVisible(loadingMarkerLocator);

        internal Pl_bab_laAboutUsPage VerifyIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "About Us page did not load properly");

            return new Pl_bab_laAboutUsPage(Driver);
        }
    }
}