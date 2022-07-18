using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAutomatedTests.Tests.Pl_bab_laTests
{
    public class Pl_bab_laAboutUsPageTests:BaseTest
    {
        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();

            GetPl_bab_laAboutUsPageHandler()
                .LoadPage();
        }

        [Test]
        public void EmptyTest()
        {

        }
    }
}
