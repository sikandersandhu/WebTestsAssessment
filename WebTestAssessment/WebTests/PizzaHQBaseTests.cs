﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestAssessment
{
    public class PizzaHQBaseTests
    {
        protected ChromeDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            // set web driver
            driver = new ChromeDriver();
            // set the url for the driver
            driver.Url = ("https://d3udduv23dv8b4.cloudfront.net/#/");
            // maximize window
            driver.Manage().Window.FullScreen();
        }
        [TestCleanup]
        public void CleanUp()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
