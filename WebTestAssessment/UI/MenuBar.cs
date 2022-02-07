using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebTestsAssessment
{
    public class MenuBar
    {
        private ChromeDriver driver;

        public MenuBar(ChromeDriver driver)
        {
            this.driver = driver;
        }
        public void OpenLoginOrSignupPage()
        {
            driver.FindElement(By.CssSelector("[aria-label='login or signup']")).Click();
        }
        public void OpenMenuPage()
        {
            driver.FindElement(By.CssSelector("[aria-label='menu']")).Click();
        }
    }
}