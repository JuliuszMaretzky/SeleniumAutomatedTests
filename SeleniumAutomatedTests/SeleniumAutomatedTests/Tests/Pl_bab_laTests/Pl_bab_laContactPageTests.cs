using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAutomatedTests.Tests.Pl_bab_laTests
{
    public class Pl_bab_laContactPageTests:Pl_bab_laBaseTest
    {
        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();

            GetPl_bab_laContactPageHandler()
                .LoadPage();
        }

        [Test]
        public void VerifyIfElementsAppearAfterMessageTopicChange()
        {
            GetPl_bab_laContactPageHandler()
                .ChangeTopicToPleaseSelect()
                .ChangeTopicToReportQuiz()
                .ChangeTopicToAppSupport()
                .ChangeTopicToSendWordList()
                .ChangeTopicToReportBug()
                .ChangeTopicToSuggestImprovement()
                .ChangeTopicToCopyright()
                .ChangeTopicToOtherTopic();
        }
    }
}
