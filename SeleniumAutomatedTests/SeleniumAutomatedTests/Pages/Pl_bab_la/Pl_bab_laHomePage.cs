using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomatedTests.Pages.Pl_bab_la;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace SeleniumAutomatedTests.Pages.pl_bab_la
{
    public class Pl_bab_laHomePage : Pl_bab_laBasePage
    {
        private By loadingMarkerLocator => By.XPath("//h1[contains(text(), 'Słownik online w ')]");
        private By AcceptPrivacyButtonLocator => By.Id("onetrust-accept-btn-handler");
        private By LanguageWarningTextLocator => By.XPath("//*[@style='opacity: 1; visibility: visible;']");
        private By AboutUsLinkLocator => By.XPath("//li[contains(@class, 'corporate')]");

        private IWebElement MenuButton => Driver.FindElement(By.XPath("//a[@class='navbar-brand' and @role='button']"));
        private IWebElement DictionaryLanguageFromDropdown => Driver.FindElement(By.XPath("//*[@class='material-icons expandIcon']"));
        private IWebElement DictionaryLanguageToDropdown => Driver.FindElement(By.XPath("//*[@class='material-icons expandIcon right']"));
        private IWebElement DictionaryTextBox => Driver.FindElement(By.XPath("//*[@class='action-search typeahead tt-input']"));
        private IWebElement SuggestionsList => Driver.FindElement(By.XPath("//*[@class='tt-dataset tt-dataset-babSuggestions']"));
        private IWebElement TranslateButton => Driver.FindElement(By.ClassName("action-panel-form-submit"));

        public Pl_bab_laHomePage(IWebDriver driver) : base(driver) { }

        public bool IsLoaded => VerifyIfElementIsVisible(loadingMarkerLocator);

        internal Pl_bab_laHomePage LoadPage()
        {
            Driver.Navigate().GoToUrl("https://pl.bab.la/");
            Driver.Manage().Window.Maximize();
            AcceptPrivacyPolicy();
            Assert.IsTrue(IsLoaded, "Page was not loaded properly");

            return new Pl_bab_laHomePage(Driver);
        }

        internal Pl_bab_laHomePage ChangeDictionaryLanguageFromByClicking(string languageFrom)
        {
            DictionaryLanguageFromDropdown.Click();
            var newLanguage = Wait.Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(
                By.XPath($"//ul[@id='langUL']//*[@data-lang='{Constants.LanguageCode[languageFrom]}']"))));
            newLanguage.Click();
            var actualLanguage =
                DictionaryLanguageFromDropdown.FindElement(By.XPath($"//*[@data-lang='{Constants.LanguageCode[languageFrom]}']"));
            Assert.IsTrue(actualLanguage.Displayed, "Language from was not changed properly");

            return new Pl_bab_laHomePage(Driver);
        }

        internal Pl_bab_laHomePage ChangeDictionaryLanguageToByClicking(string languageTo)
        {
            DictionaryLanguageToDropdown.Click();
            var newLanguage = Wait.Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(
                By.XPath($"//ul[@id='langUL']//*[@data-lang='{Constants.LanguageCode[languageTo]}']"))));
            newLanguage.Click();
            var actualLanguage =
                DictionaryLanguageToDropdown.FindElement(By.XPath($"//*[@data-lang='{Constants.LanguageCode[languageTo]}']"));
            Assert.IsTrue(actualLanguage.Displayed, "Language to was not changed properly");

            return new Pl_bab_laHomePage(Driver);
        }

        internal Pl_bab_laAboutUsPage GoToAboutUsPage()
        {
            MenuButton.Click();
            var aboutUsLink = Wait.Until(ExpectedConditions.ElementIsVisible(AboutUsLinkLocator));
            //Driver.FindElement(AboutUsLinkLocator).Click();
            aboutUsLink.Click();
            return new Pl_bab_laAboutUsPage(Driver);
        }

        internal Pl_bab_laHomePage PressEnterInDictionaryTextBox()
        {
            DictionaryTextBox.SendKeys(Keys.Enter);

            return new Pl_bab_laHomePage(Driver);
        }

        internal Pl_bab_laHomePage VerifyIfLanguageWarningIsVisible()
        {
            var languageWarning = Driver.FindElements(LanguageWarningTextLocator);
            Assert.IsTrue(languageWarning.Count == 1, "Language warning was not visible");

            return new Pl_bab_laHomePage(Driver);
        }

        internal Pl_bab_laHomePage WriteWord(string word)
        {
            DictionaryTextBox.SendKeys(word);

            return new Pl_bab_laHomePage(Driver);
        }

        internal Pl_bab_laHomePage VerifyIfSuggestionIsOnList(string suggestion)
        {
            Thread.Sleep(500);
            var searchedSuggestions = SuggestionsList.FindElements(By.XPath($"div[text()='{suggestion}']"));
            Assert.IsTrue(searchedSuggestions.Count > 0, "Suggestion is not on the list");

            return new Pl_bab_laHomePage(Driver);
        }

        internal Pl_bab_laHomePage VerifyTranslateBoxText(string languageFrom, string languageTo)
        {
            Assert.IsTrue(VerifyIfElementIsVisible(By.XPath(
                $"//input[@class='action-search typeahead tt-input' and @placeholder='" +
                $"{Constants.LanguageInPolish[languageFrom]} lub {Constants.LanguageInPolish[languageTo]}']"))
                , "Translation Text Box did not show proper languages");

            return new Pl_bab_laHomePage(Driver);
        }

        private Pl_bab_laHomePage AcceptPrivacyPolicy()
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AcceptPrivacyButtonLocator)).Click();
            }
            catch (NoSuchElementException) { }

            return new Pl_bab_laHomePage(Driver);
        }
    }
}
