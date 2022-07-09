using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomatedTests.Pages.pl_bab_la;

namespace SeleniumAutomatedTests.Tests.pl_bab_laTests
{
    public class Pl_bab_laHomePageTests
    {
        private IWebDriver Driver { get; set; }
        private Pl_bab_laHomePage pl_bab_laHomePage;

        [SetUp]
        public void Setup()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            pl_bab_laHomePage = new Pl_bab_laHomePage(Driver);
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
    }
}
