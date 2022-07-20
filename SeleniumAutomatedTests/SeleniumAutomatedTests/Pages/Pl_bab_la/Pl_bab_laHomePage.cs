using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
//a[@class='dropdown-toggle'
namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class Pl_bab_laHomePage : BasePage<Pl_bab_laHomePage>
    {
        #region Locators

        private By LoadingMarkerLocator => By.XPath("//h1[contains(text(), 'Słownik online w ')]");
        private By AcceptPrivacyButtonLocator => By.Id("onetrust-accept-btn-handler");
        private By LanguageWarningTextLocator => By.XPath("//*[@style='opacity: 1; visibility: visible;']");
        private By LanguageFilterTextBoxLocator => By.Id("langFilter");
        private By DictionariesLinkLocator => By.XPath("//li[contains(@class, 'languages')]");
        private By AboutUsLinkLocator => By.XPath("//li[contains(@class, 'corporate')]");
        private By LivingAbroadLinkLocator => By.XPath("//li[contains(@class, 'magazine')]");
        private By GamesLinkLocator => By.XPath("//ul[@class='dropdown-menu']//a[contains(@onclick, 'games')]");
        private By QuizzesLinkLocator => By.XPath("//ul[@class='dropdown-menu']//a[contains(@onclick, 'quiz')]");
        private By GrammarLinkLocator => By.XPath("//ul[@class='dropdown-menu']//a[contains(@onclick, 'grammar')]");

        #endregion
        #region WebElements

        private IWebElement MenuButton => Driver.FindElement(By.XPath("//a[@class='navbar-brand' and @role='button']"));
        private IWebElement MoreButton => Driver.FindElements(By.XPath("//a[@data-toggle='dropdown']"))[0];
        private IWebElement DictionaryLanguageFromDropdown => Driver.FindElement(By.XPath("//*[@class='material-icons expandIcon']"));
        private IWebElement DictionaryLanguageToDropdown => Driver.FindElement(By.XPath("//*[@class='material-icons expandIcon right']"));
        private IWebElement DictionaryTextBox => Driver.FindElement(By.XPath("//*[@class='action-search typeahead tt-input']"));
        private IWebElement SuggestionsList => Driver.FindElement(By.XPath("//*[@class='tt-dataset tt-dataset-babSuggestions']"));
        private IWebElement ConjugationPageLinkButton => Driver.FindElements(By.XPath("//ul[@class='nav navbar-nav']//a[@href='/koniugacja/']"))[0];
        
        #endregion

        public Pl_bab_laHomePage(IWebDriver driver) : base(driver)
        {
            pageHandler = this;
        }

        public bool IsLoaded => VerifyIfElementIsVisible(LoadingMarkerLocator);

        internal Pl_bab_laHomePage LoadPage()
        {
            Driver.Navigate().GoToUrl("https://pl.bab.la/");
            Driver.Manage().Window.Maximize();
            AcceptPrivacyPolicy();
            Assert.IsTrue(IsLoaded, "Page was not loaded properly");

            return pageHandler;
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

            return pageHandler;
        }

        internal Pl_bab_laHomePage ChangeDictionaryLanguageFromByTyping(string languageFromInPolish)
        {
            DictionaryLanguageFromDropdown.Click();

            var languageFilter = Wait.Until(ExpectedConditions.ElementIsVisible(LanguageFilterTextBoxLocator));
            languageFilter.SendKeys(languageFromInPolish);

            var languageFrom = ReturnKeyFromDictionaryWhenValueIsGiven(Constants.LanguageInPolish, languageFromInPolish);

            var newLanguage = Wait.Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(
                By.XPath($"//ul[@id='langUL']//*[@data-lang='{Constants.LanguageCode[languageFrom]}']"))));
            newLanguage.Click();

            var actualLanguage =
                DictionaryLanguageFromDropdown.FindElement(By.XPath($"//*[@data-lang='{Constants.LanguageCode[languageFrom]}']"));
            Assert.IsTrue(actualLanguage.Displayed, "Language from was not changed properly");

            return pageHandler;
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

            return pageHandler;
        }

        internal Pl_bab_laHomePage ChangeDictionaryLanguageToByTyping(string languageToInPolish)
        {
            DictionaryLanguageToDropdown.Click();

            var languageFilter = Wait.Until(ExpectedConditions.ElementIsVisible(LanguageFilterTextBoxLocator));
            languageFilter.SendKeys(languageToInPolish);

            var languageTo = ReturnKeyFromDictionaryWhenValueIsGiven(Constants.LanguageInPolish, languageToInPolish);

            var newLanguage = Wait.Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(
                By.XPath($"//ul[@id='langUL']//*[@data-lang='{Constants.LanguageCode[languageTo]}']"))));
            newLanguage.Click();

            var actualLanguage =
                DictionaryLanguageToDropdown.FindElement(By.XPath($"//*[@data-lang='{Constants.LanguageCode[languageTo]}']"));
            Assert.IsTrue(actualLanguage.Displayed, "Language to was not changed properly");

            return pageHandler;
        }

        internal Pl_bab_laHomePage OpenMenuByClick()
        {
            MenuButton.Click();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.FindElement(DictionariesLinkLocator).Displayed, "Dictionaries button is not visible");
                Assert.IsTrue(Driver.FindElement(LivingAbroadLinkLocator).Displayed, "Living abroad button is not visible");
                Assert.IsTrue(Driver.FindElement(AboutUsLinkLocator).Displayed, "About us button is not visible");
            });

            return pageHandler;
        }

        internal Pl_bab_laHomePage OpenMoreMenuButtonByClick()
        {
            MoreButton.Click();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(Driver.FindElement(GamesLinkLocator).Displayed, "Games button is not visible");
                Assert.IsTrue(Driver.FindElement(QuizzesLinkLocator).Displayed, "Quizzes button is not visible");
                Assert.IsTrue(Driver.FindElement(GrammarLinkLocator).Displayed, "Grammar button is not visible");
            });

            return pageHandler;
        }

        internal Pl_bab_laLifeAbroadPage GoToLivingAbroadPageFromMenu()
        {
            var livingAbroadLink = Wait.Until(ExpectedConditions.ElementIsVisible(LivingAbroadLinkLocator));
            livingAbroadLink.Click();

            return new Pl_bab_laLifeAbroadPage(Driver);
        }

        internal Pl_bab_laAboutUsPage GoToAboutUsPageFromMenu()
        {
            var aboutUsLink = Wait.Until(ExpectedConditions.ElementIsVisible(AboutUsLinkLocator));
            aboutUsLink.Click();

            return new Pl_bab_laAboutUsPage(Driver);
        }

        internal Pl_bab_laGamesPage GotoGamesPageFromMoreMenu()
        {
            var gamesLink = Wait.Until(ExpectedConditions.ElementToBeClickable(GamesLinkLocator));
            gamesLink.Click();

            return new Pl_bab_laGamesPage(Driver);
        }

        ///<summary>
        ///Only for veryfying language warning visibility with same language from and to, and with empty word box
        /// </summary>
        internal Pl_bab_laHomePage PressEnterInDictionaryTextBox()
        {
            DictionaryTextBox.SendKeys(Keys.Enter);

            return pageHandler;
        }

        internal Pl_bab_laHomePage VerifyIfLanguageWarningIsVisible()
        {
            var languageWarning = Driver.FindElements(LanguageWarningTextLocator);
            Assert.IsTrue(languageWarning.Count == 1, "Language warning was not visible");

            return pageHandler;
        }

        internal Pl_bab_laHomePage WriteWord(string word)
        {
            DictionaryTextBox.SendKeys(word);

            return pageHandler;
        }

        internal Pl_bab_laHomePage VerifyIfSuggestionIsOnList(string suggestion)
        {
            Thread.Sleep(500);
            var searchedSuggestions = SuggestionsList.FindElements(By.XPath($"div[text()='{suggestion}']"));
            Assert.IsTrue(searchedSuggestions.Count > 0, "Suggestion is not on the list");

            return pageHandler;
        }

        internal Pl_bab_laHomePage VerifyTranslateBoxText(string languageFrom, string languageTo)
        {
            Assert.IsTrue(VerifyIfElementIsVisible(By.XPath(
                $"//input[@class='action-search typeahead tt-input' and @placeholder='" +
                $"{Constants.LanguageInPolish[languageFrom]} lub {Constants.LanguageInPolish[languageTo]}']"))
                , "Translation Text Box did not show proper languages");

            return pageHandler;
        }

        private Pl_bab_laHomePage AcceptPrivacyPolicy()
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AcceptPrivacyButtonLocator)).Click();
            }
            catch (NoSuchElementException) { }

            return pageHandler;
        }

        internal Pl_bab_laConjugationPage GoToConjugationPageByLinkInTopMenuBar()
        {
            ConjugationPageLinkButton.Click();

            return new Pl_bab_laConjugationPage(Driver);
        }
    }
}
