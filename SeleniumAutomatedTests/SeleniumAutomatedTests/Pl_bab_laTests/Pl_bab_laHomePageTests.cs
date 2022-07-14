﻿using NUnit.Framework;
using SeleniumAutomatedTests.Pl_bab_laTests;

namespace SeleniumAutomatedTests.Tests.pl_bab_laTests
{
    public class Pl_bab_laHomePageTests : BaseTest
    {
        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();

            GetPl_bab_laHomePageHandler()
                .LoadPage();
        }

        [TestCase("English", "Polish")]
        [TestCase("German", "Esperanto")]
        [TestCase("Finnish", "Greek")]
        public void ChangeLanguagesToTranslateFromAndToByClicking(string languageFrom, string languageTo)
        {
            GetPl_bab_laHomePageHandler()
                .ChangeDictionaryLanguageFromByClicking(languageFrom)
                .ChangeDictionaryLanguageToByClicking(languageTo)
                .VerifyTranslateBoxText(languageFrom, languageTo);
        }

        [Test]
        public void ChangeLanguagesToTranslateFromAndToByTyping()
        {
            GetPl_bab_laHomePageHandler()
                .ChangeDictionaryLanguageFromByTyping("japoński")
                .ChangeDictionaryLanguageToByTyping("chiński")
                .VerifyTranslateBoxText("Japanese", "Chinese");
        }

        [TestCase("Polish")]
        [TestCase("Finnish")]
        public void VerifyIfLanguageWarningAppearsWhenFromLanguageIsSameAsTo(string language)
        {
            GetPl_bab_laHomePageHandler()
                .ChangeDictionaryLanguageFromByClicking(language)
                .ChangeDictionaryLanguageToByClicking(language)
                .PressEnterInDictionaryTextBox()
                .VerifyIfLanguageWarningIsVisible();
        }

        [TestCase("Polish", "German", "pies", "piesza")]
        [TestCase("English", "Esperanto", "urgent", "urgently")]
        public void VerifyIfSuggestionIsVisibleAfterWriteWord(string languageFrom, string languageTo, string word, string suggestion)
        {
            GetPl_bab_laHomePageHandler()
                .ChangeDictionaryLanguageFromByClicking(languageFrom)
                .ChangeDictionaryLanguageToByClicking(languageTo)
                .WriteWord(word)
                .VerifyIfSuggestionIsOnList(suggestion.Replace(word, ""));
        }

        [Test]
        public void GoToAboutUsPageByLink()
        {
            GetPl_bab_laHomePageHandler()
                .GoToAboutUsPage()
                .VerifyIfPageIsLoaded();
        }

        [Test]
        public void GoToLifeAbroadPageByLink()
        {
            GetPl_bab_laHomePageHandler()
                .GoToLifeAbroadPage()
                .VerifyIfPageIsLoaded();
        }

        [Test]
        public void GoToGamesPageByLink()
        {
            GetPl_bab_laHomePageHandler()
                .GotoGamesPage()
                .VeryfiIfPageIsLoaded();
        }
    }
}
