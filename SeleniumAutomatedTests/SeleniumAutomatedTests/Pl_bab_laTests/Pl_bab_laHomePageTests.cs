using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomatedTests.Pages.pl_bab_la;
using SeleniumAutomatedTests.Pages.Pl_bab_la;

namespace SeleniumAutomatedTests.Tests.pl_bab_laTests
{
    public class Pl_bab_laHomePageTests
    {
        private IWebDriver Driver { get; set; }
        private Pl_bab_laHomePage pl_bab_laHomePage;
        private Pl_bab_laAboutUsPage pl_bab_laAboutUsPage;

        [SetUp]
        public void Setup()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            pl_bab_laHomePage = new Pl_bab_laHomePage(Driver);
            pl_bab_laAboutUsPage = new Pl_bab_laAboutUsPage(Driver);
        }

        [TearDown]
        public void Teardown()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Test]
        public void LoadHomePage()
        {
            pl_bab_laHomePage.LoadPage();
        }

        [TestCase("English", "Polish")]
        [TestCase("German", "Esperanto")]
        [TestCase("Finnish", "Greek")]
        public void ChangeLanguagesToTranslateFromAndToByClicking(string languageFrom, string languageTo)
        {
            pl_bab_laHomePage.LoadPage();
            pl_bab_laHomePage.ChangeDictionaryLanguageFromByClicking(languageFrom);
            pl_bab_laHomePage.ChangeDictionaryLanguageToByClicking(languageTo);
            pl_bab_laHomePage.VerifyTranslateBoxText(languageFrom, languageTo);
        }

        [TestCase("Polish")]
        [TestCase("Finnish")]
        public void VerifyIfLanguageWarningAppearsWhenFromLanguageIsSameAsTo(string language)
        {
            pl_bab_laHomePage.LoadPage();
            pl_bab_laHomePage.ChangeDictionaryLanguageFromByClicking(language);
            pl_bab_laHomePage.ChangeDictionaryLanguageToByClicking(language);
            pl_bab_laHomePage.PressEnterInDictionaryTextBox();
            pl_bab_laHomePage.VerifyIfLanguageWarningIsVisible();
        }

        [TestCase("Polish", "German", "pies", "piesza")]
        [TestCase("English", "Esperanto", "urgent", "urgently")]
        public void VerifyIfSuggestionIsVisibleAfterWriteWord(string languageFrom, string languageTo, string word, string suggestion)
        {
            pl_bab_laHomePage.LoadPage();
            pl_bab_laHomePage.ChangeDictionaryLanguageFromByClicking(languageFrom);
            pl_bab_laHomePage.ChangeDictionaryLanguageToByClicking(languageTo);
            pl_bab_laHomePage.WriteWord(word);
            pl_bab_laHomePage.VerifyIfSuggestionIsOnList(suggestion.Replace(word,""));
        }

        [Test]
        public void GoToAboutUsPageByLink()
        {
            pl_bab_laHomePage.LoadPage();
            var aboutUsPage = pl_bab_laHomePage.GoToAboutUsPage();
            Assert.IsTrue(aboutUsPage.IsLoaded, "About Us page did not load properly");
        }
    }
}
