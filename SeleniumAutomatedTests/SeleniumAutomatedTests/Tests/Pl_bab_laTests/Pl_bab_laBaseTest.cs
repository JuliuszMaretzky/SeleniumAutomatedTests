﻿using SeleniumAutomatedTests.Pages.Pl_bab_la;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAutomatedTests.Tests.Pl_bab_laTests
{
    public class Pl_bab_laBaseTest:BaseTest
    {
        #region PageHandlers

        private Pl_bab_laHomePage pl_bab_laHomePage;
        private Pl_bab_laLifeAbroadPage pl_bab_laLifeAbroadPage;
        private Pl_bab_laAboutUsPage pl_bab_laAboutUsPage;
        private Pl_bab_laContactPage pl_bab_laContactPage;

        #endregion

        #region GetPageHandler Methods

        protected Pl_bab_laHomePage GetPl_bab_laHomePageHandler()
        {
            if (pl_bab_laHomePage == null)
            {
                pl_bab_laHomePage = new Pl_bab_laHomePage(Driver);
            }

            return pl_bab_laHomePage;
        }

        protected Pl_bab_laLifeAbroadPage GetPl_bab_laLifeAbroadPageHandler()
        {
            if (pl_bab_laLifeAbroadPage == null)
            {
                pl_bab_laLifeAbroadPage = new Pl_bab_laLifeAbroadPage(Driver);
            }

            return pl_bab_laLifeAbroadPage;
        }

        protected Pl_bab_laAboutUsPage GetPl_bab_laAboutUsPageHandler()
        {
            if (pl_bab_laAboutUsPage == null)
            {
                pl_bab_laAboutUsPage = new Pl_bab_laAboutUsPage(Driver);
            }

            return pl_bab_laAboutUsPage;
        }

        protected Pl_bab_laContactPage GetPl_bab_laContactPageHandler()
        {
            if (pl_bab_laContactPage == null)
            {
                pl_bab_laContactPage = new Pl_bab_laContactPage(Driver);
            }

            return pl_bab_laContactPage;
        }

        #endregion
    }
}
