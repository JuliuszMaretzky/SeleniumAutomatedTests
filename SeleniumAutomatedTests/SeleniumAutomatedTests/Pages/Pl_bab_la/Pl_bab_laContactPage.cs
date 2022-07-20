using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumAutomatedTests.Pages.Pl_bab_la
{
    public class Pl_bab_laContactPage : BasePage<Pl_bab_laContactPage>
    {
        #region Locators

        private By LoadingMarkerLocator => By.XPath("//p[text()='We do not translate long texts. bab.la is an online dictionary.']");
        private By AcceptPrivacyButtonLocator => By.Id("onetrust-accept-btn-handler");

        #endregion
        #region WebElements

        private IWebElement TopicDropdownList => Driver.FindElement(By.Name("topic"));
        private IWebElement PleaseSelectDropdownOption => TopicDropdownList.FindElement(By.XPath("//option[text()='Wybierz']"));
        private IWebElement ReportQuizDropdownOption => TopicDropdownList.FindElement(By.XPath("//option[text()='Zgłoś quiz']"));
        private IWebElement AppSupportDropdownOption => TopicDropdownList.FindElement(By.XPath("//option[text()='Aplikacje mobilne']"));
        private IWebElement SendWordListDropdownOption => TopicDropdownList.FindElement(By.XPath("//option[text()='Wyślij listę słów']"));
        private IWebElement ReportBugDropdownOption => TopicDropdownList.FindElement(By.XPath("//option[text()='Zgłoś błąd']"));
        private IWebElement SuggestImprovementDropdownOption => TopicDropdownList.FindElement(By.XPath("//option[text()='Zaproponuj ulepszenia']"));
        private IWebElement CopyrightDropdownOption => TopicDropdownList.FindElement(By.XPath("//option[text()='Prawo autorskie']"));
        private IWebElement OtherTopicDropdownOption => TopicDropdownList.FindElement(By.XPath("//option[text()='Inny temat']"));
        private IWebElement YourMessageTextArea => Driver.FindElement(By.Id("yourMessage"));
        private IWebElement QuizTitleTextBox => Driver.FindElement(By.Id("quizTitle"));
        private IWebElement AppTypeDropdownList => Driver.FindElement(By.Id("appType"));
        private IWebElement DeviceDropdownList => Driver.FindElement(By.Id("device"));
        private IWebElement GenerationDropdownList => Driver.FindElement(By.Id("generation"));
        private IWebElement IOSVersionDropdownList => Driver.FindElement(By.Id("iosVersion"));
        private IWebElement LanguageCombinationDropdownList => Driver.FindElement(By.Id("languageCombination"));

        #endregion

        public Pl_bab_laContactPage(IWebDriver driver) : base(driver)
        {
            pageHandler = this;
        }

        public bool IsLoaded => VerifyIfElementIsVisible(LoadingMarkerLocator);

        internal Pl_bab_laContactPage LoadPage()
        {
            Driver.Navigate().GoToUrl("https://pl.bab.la/o-nas/kontakt");
            Driver.Manage().Window.Maximize();
            AcceptPrivacyPolicy();
            Assert.IsTrue(IsLoaded, "Page was not loaded properly");

            return pageHandler;
        }

        internal Pl_bab_laContactPage VeryfiIfPageIsLoaded()
        {
            Assert.IsTrue(IsLoaded, "About Us page did not load properly");

            return pageHandler;
        }

        private Pl_bab_laContactPage AcceptPrivacyPolicy()
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AcceptPrivacyButtonLocator)).Click();
            }
            catch (NoSuchElementException) { }

            return pageHandler;
        }

        internal Pl_bab_laContactPage ChangeTopicToPleaseSelect()
        {
            TopicDropdownList.Click();
            PleaseSelectDropdownOption.Click();

            Assert.IsTrue(YourMessageTextArea.Displayed, "Your message text area is not displayed");

            return pageHandler;
        }

        internal Pl_bab_laContactPage ChangeTopicToReportQuiz()
        {
            TopicDropdownList.Click();
            ReportQuizDropdownOption.Click();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(QuizTitleTextBox.Displayed, "Quiz title text box is not displayed");
                Assert.IsTrue(YourMessageTextArea.Displayed, "Your message text area is not displayed");
            });

            return pageHandler;
        }

        internal Pl_bab_laContactPage ChangeTopicToAppSupport()
        {
            TopicDropdownList.Click();
            AppSupportDropdownOption.Click();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(AppTypeDropdownList.Displayed, "App type dropdown list is not displayed");
                Assert.IsTrue(DeviceDropdownList.Displayed, "Device dropdown list is not displayed");
                Assert.IsTrue(GenerationDropdownList.Displayed, "Generation dropdown list is not displayed");
                Assert.IsTrue(IOSVersionDropdownList.Displayed, "iOS version dropdown list is not displayed");
                Assert.IsTrue(LanguageCombinationDropdownList.Displayed, "Language combination dropdown list is not displayed");
                Assert.IsTrue(YourMessageTextArea.Displayed, "Your message text area is not displayed");
            });

            return pageHandler;
        }

        internal Pl_bab_laContactPage ChangeTopicToSendWordList()
        {
            TopicDropdownList.Click();
            SendWordListDropdownOption.Click();

            Assert.IsTrue(YourMessageTextArea.Displayed, "Your message text area is not displayed");

            return pageHandler;
        }

        internal Pl_bab_laContactPage ChangeTopicToReportBug()
        {
            TopicDropdownList.Click();
            ReportBugDropdownOption.Click();

            Assert.IsTrue(YourMessageTextArea.Displayed, "Your message text area is not displayed");

            return pageHandler;
        }

        internal Pl_bab_laContactPage ChangeTopicToSuggestImprovement()
        {
            TopicDropdownList.Click();
            SuggestImprovementDropdownOption.Click();

            Assert.IsTrue(YourMessageTextArea.Displayed, "Your message text area is not displayed");

            return pageHandler;
        }

        internal Pl_bab_laContactPage ChangeTopicToCopyright()
        {
            TopicDropdownList.Click();
            CopyrightDropdownOption.Click();

            Assert.IsTrue(YourMessageTextArea.Displayed, "Your message text area is not displayed");

            return pageHandler;
        }

        internal Pl_bab_laContactPage ChangeTopicToOtherTopic()
        {
            TopicDropdownList.Click();
            OtherTopicDropdownOption.Click();

            Assert.IsTrue(YourMessageTextArea.Displayed, "Your message text area is not displayed");

            return pageHandler;
        }
    }
}