using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestAssessment.UI
{
    class SignUpForm
    {

        private ChromeDriver driver;

        public SignUpForm(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public string UserNameError => driver.FindElement(By.Id("username-err")).Text;
        public string PasswordError => driver.FindElement(By.Id("password-err")).Text;
        public string ConfirmPasswordError => driver.FindElement(By.Id("confirm-err")).Text; 
    }
}
