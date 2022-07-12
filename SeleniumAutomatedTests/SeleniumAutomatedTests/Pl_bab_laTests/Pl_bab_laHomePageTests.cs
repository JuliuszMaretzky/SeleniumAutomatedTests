using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomatedTests.Pages.pl_bab_la;
using SeleniumAutomatedTests.Pages.Pl_bab_la;

namespace SeleniumAutomatedTests.Tests.pl_bab_laTests
{
    public class Pl_bab_laHomePageTests
    {
        private IWebDriver Driver;
        private Pl_bab_laBasePage pageHandler;

        [SetUp]
        public virtual void Setup()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            pageHandler = new Pl_bab_laBasePage(Driver);
        }

        [TearDown]
        public virtual void Teardown()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Test]
        public void LoadHomePage()
        {
            pageHandler.GetPl_bab_laHomePageObject()
                .LoadPage();
        }

        [TestCase("English", "Polish")]
        [TestCase("German", "Esperanto")]
        [TestCase("Finnish", "Greek")]
        public void ChangeLanguagesToTranslateFromAndToByClicking(string languageFrom, string languageTo)
        {
            pageHandler.GetPl_bab_laHomePageObject()
                .LoadPage()
                .ChangeDictionaryLanguageFromByClicking(languageFrom)
                .ChangeDictionaryLanguageToByClicking(languageTo)
                .VerifyTranslateBoxText(languageFrom, languageTo);
        }

        [TestCase("Polish")]
        [TestCase("Finnish")]
        public void VerifyIfLanguageWarningAppearsWhenFromLanguageIsSameAsTo(string language)
        {
            pageHandler.GetPl_bab_laHomePageObject()
                .LoadPage()
                .ChangeDictionaryLanguageFromByClicking(language)
                .ChangeDictionaryLanguageToByClicking(language)
                .PressEnterInDictionaryTextBox()
                .VerifyIfLanguageWarningIsVisible();
        }

        [TestCase("Polish", "German", "pies", "piesza")]
        [TestCase("English", "Esperanto", "urgent", "urgently")]
        public void VerifyIfSuggestionIsVisibleAfterWriteWord(string languageFrom, string languageTo, string word, string suggestion)
        {
            pageHandler.GetPl_bab_laHomePageObject()
                .LoadPage()
                .ChangeDictionaryLanguageFromByClicking(languageFrom)
                .ChangeDictionaryLanguageToByClicking(languageTo)
                .WriteWord(word)
                .VerifyIfSuggestionIsOnList(suggestion.Replace(word, ""));
        }

        [Test]
        public void GoToAboutUsPageByLink()
        {
            pageHandler.GetPl_bab_laHomePageObject()
                .LoadPage()
                .GoToAboutUsPage()
                .VerifyIfPageIsLoaded();
        }

        [Test]
        public void GoToLifeAbroadPageByLink()
        {
            pageHandler.GetPl_bab_laHomePageObject()
                .LoadPage()
                .GoToLifeAbroadPage()
                .VerifyIfPageIsLoaded();
        }
    }
}
