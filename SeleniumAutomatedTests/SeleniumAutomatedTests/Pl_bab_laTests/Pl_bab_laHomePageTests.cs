using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomatedTests.Pages.pl_bab_la;
using SeleniumAutomatedTests.Pages.Pl_bab_la;

namespace SeleniumAutomatedTests.Tests.pl_bab_laTests
{
    public class Pl_bab_laHomePageTests : Pl_bab_laBasePage
    {
        public Pl_bab_laHomePageTests(IWebDriver driver) : base(driver) { }

        [Test]
        public void LoadHomePage()
        {
            GetPl_bab_laHomePageObject().LoadPage();
        }

        [TestCase("English", "Polish")]
        [TestCase("German", "Esperanto")]
        [TestCase("Finnish", "Greek")]
        public void ChangeLanguagesToTranslateFromAndToByClicking(string languageFrom, string languageTo)
        {
            GetPl_bab_laHomePageObject()
                .LoadPage()
                .ChangeDictionaryLanguageFromByClicking(languageFrom)
                .ChangeDictionaryLanguageToByClicking(languageTo)
                .VerifyTranslateBoxText(languageFrom, languageTo);
        }

        [TestCase("Polish")]
        [TestCase("Finnish")]
        public void VerifyIfLanguageWarningAppearsWhenFromLanguageIsSameAsTo(string language)
        {
            GetPl_bab_laHomePageObject()
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
            GetPl_bab_laHomePageObject()
                .LoadPage()
                .ChangeDictionaryLanguageFromByClicking(languageFrom)
                .ChangeDictionaryLanguageToByClicking(languageTo)
                .WriteWord(word)
                .VerifyIfSuggestionIsOnList(suggestion.Replace(word, ""));
        }

        [Test]
        public void GoToAboutUsPageByLink()
        {
            GetPl_bab_laHomePageObject()
                .LoadPage()
                .GoToAboutUsPage()
                .VerifyIfPageIsLoaded();
        }

        [Test]
        public void GoToLifeAbroadPageByLink()
        {
            pl_bab_laHomePage.LoadPage();
            var lifeAbroadPage = pl_bab_laHomePage.GoToLifeAbroadPage();
            Assert.IsTrue(lifeAbroadPage.IsLoaded, "Life Abroad page did not load properly");
        }
    }
}
