using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        // form input elements
        public string EnterUserName
        {
            //get => driver.FindElement(By.Id("input-91")).Text;
            set 
            {
                driver.FindElement(By.Id("input-91")).SendKeys(value);
            }
        }
        public string EnterPassword
        {
            //get => driver.FindElement(By.Id("input-94")).Text;
            set
            {
                driver.FindElement(By.Id("input-94")).SendKeys(value);
            }
        }
        public string ConfirmPassword
        {
            //get => driver.FindElement(By.Id("input-97")).Text;
            set
            {
                driver.FindElement(By.Id("input-97")).SendKeys(value);
            }
        }
        // form errors
        public string UserNameError => driver.FindElement(By.Id("username-err")).GetAttribute("innerText");
        public string PasswordError => driver.FindElement(By.Id("password-err")).GetAttribute("innerText");
        public string ConfirmPasswordError => driver.FindElement(By.Id("confirm-err")).GetAttribute("innerText");
      
        public bool IsSignUpFormOpen()
        {
            // confirm the pop up opened
            var headers = driver.FindElements(By.ClassName("v-toolbar__title"));
            foreach (IWebElement header in headers)
            {
                if (header.Text.ToLower() == "pizzahq members login")
                {
                    return true;
                }
            }
            return false;
        }
        public void ClickNotMemberSignUp()
        {
            // confirm the pop up opened
            var buttons = driver.FindElements(By.TagName("a"));
            foreach (IWebElement button in buttons)
            {
                if (button.Text.ToLower() == "sign up")
                {
                    button.Click();
                    return;
                }
            }
            throw new NotFoundException("'Not a member? Sign up' button could not be found");

            // xpath option 
            //driver.FindElement(By.XPath("//a[text()='Sign Up']")).Click();
        }
        public void ClickSignUp()
        {
            driver.FindElement(By.CssSelector("button[aria-label='signup']")).Click();
        }
    }  

    /* Requirements
             1. find login icon                       | by class | nav-login-signup
             2. click on it
             3. verify popup using header             | class="v-toolbar__title" - there are two elements. iterate and chose one based on text "PizzaHQ Members Login"
             4. find "Not a member? signup" element   | by tag <a>               - list of 14 element  find based on text "Sign Up"
             5. click on "Not a member? signup" element
             6. find sign up button                   | bycss  | aria-label="signup"
             7. click on sign up button

             8a. find username input box              | id="input-96"
             8b. find username error text             | id="username-err"

             9a. find password input box              | id="input-99"
             9b. find password error text             | id="password-err"

             10a. find confirm password input box     | id="input-102"
             10b. find confirm password error text    | id="confirm-err"
             */
}
