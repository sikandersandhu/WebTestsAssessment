using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebTestAssessment;
using WebTestAssessment.UI;

namespace WebTestsAssessment
{
    [TestClass]
    public class PizzaHQWebTests : PizzaHQBaseTests
    {
        /* Requirements
             1. find login icon                  | by class | nav-login-signup
             2. click on it 
             3. verify popup using header        | class="v-toolbar__title" - there are two elements. iterate and chose one based on text "PizzaHQ Members Login"
             4. find signup element              | by tag <a>               - list of 14 element  find based on text "Sign Up"
             5. click on signup element
             6. find sign up button              | bycss  | aria-label="signup"
             7. click on sign up button

             8a. find username input box          | id="input-96"
             8b. find username error text         | id="username-err"

             9a. find password input box          | id="input-99"
             9b. find password error text         | id="password-err"

             10a. find confirm password input box | id="input-102"
             10b. find confirm password error text| id="confirm-err"
             */


        [TestMethod]
        public void SignUpFieldValidationFieldBlankError()
        {

            // setup
            // click on login-signup icon
            driver.FindElement(By.ClassName("nav-login-signup")).Click();


            // act 

            // confirm the pop up opened
            var headers = driver.FindElements(By.ClassName("v-toolbar__title"));
            foreach (IWebElement header in headers)
            {
                if (header.Text.ToLower() == "pizzahq members login")
                {
                    // find signup element and click on it
                    var buttons = driver.FindElements(By.TagName("a"));
                    foreach (IWebElement button in buttons)
                    {
                        if (button.Text.ToLower() == "sign up")
                        {
                            // click on it
                            button.Click();

                            // find the sign up button and click
                            // could not finish and modelling
                        }
                        else throw new NotFoundException("Sign up button not found");
                    }

                }
                else throw new NotFoundException("Pop up not found");
            }

            // click on signup button
            driver.FindElement(By.CssSelector("[aria-label='signup']")).Click();

            //  assert error text for username, password, confirm password

            SignUpForm signUpForm = new SignUpForm(driver);

            // assert user name required error
            Assert.AreEqual("username is required", signUpForm.UserNameError.ToLower());
            // assert password required error
            Assert.AreEqual("password is required", signUpForm.PasswordError.ToLower());
            // assert confirm password required error
            Assert.AreEqual("Please confirm your password", signUpForm.ConfirmPasswordError.ToLower());

        }

        [TestMethod]
        public void SignUpFieldValidationIncorrectInputErrors()
        {

            // setup
            // click on login-signup icon
            driver.FindElement(By.ClassName("nav-login-signup")).Click();


            // act 

            SignUpForm signUpForm = new SignUpForm(driver);

            // confirm the pop up opened
            var headers = driver.FindElements(By.ClassName("v-toolbar__title"));
            foreach (IWebElement header in headers)
            {
                if (header.Text.ToLower() == "pizzahq members login")
                {
                    // find signup element and click on it
                    var buttons = driver.FindElements(By.TagName("a"));
                    foreach (IWebElement button in buttons)
                    {
                        if (button.Text.ToLower() == "sign up")
                        {
                            // click on it
                            button.Click();

                            //find sign up button and click on it
                            // could not finish code and modelling

                        }
                        else throw new NotFoundException("Sign up button not found");
                    }

                }
                else throw new NotFoundException("Pop up not found");
            }

            // click on signup button
            driver.FindElement(By.CssSelector("[aria-label='signup']")).Click();

            //  assert error text for username, password, confirm password

            

            // assert user name required error
            Assert.AreEqual("username is required", signUpForm.UserNameError.ToLower());
            // assert password required error
            Assert.AreEqual("password is required", signUpForm.PasswordError.ToLower());
            // assert confirm password required error
            Assert.AreEqual("Please confirm your password", signUpForm.ConfirmPasswordError.ToLower());
        }

        [TestMethod]
        public void SignUpFieldValidationUserNameExistsError()
        {

            // setup

            // set web driver
            driver = new ChromeDriver();
            // set the url for the driver
            driver.Url = ("https://d3udduv23dv8b4.cloudfront.net/#/");
            // maximize window
            driver.Manage().Window.FullScreen();

            
            // act 
            // could not finish



            //  assert error text for username, password, confirm password


        }
    }
}
