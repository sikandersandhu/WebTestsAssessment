using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebTestAssessment;
using WebTestAssessment.UI;

namespace WebTestsAssessment
{
    [TestClass]
    public class PizzaHQWebTests : PizzaHQBaseTests
    {        
        [TestMethod]
        public void SignUpValidationFieldsBlankError()
        {

            // setup
            // click on login-signup icon
            driver.FindElement(By.ClassName("nav-login-signup")).Click();


            // act 
            
            // initialize sign up form object
            SignUpForm signUpForm = new SignUpForm(driver);

            // WAIT

            // wait till pop up form appears
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => signUpForm.IsSignUpFormOpen());

            // if the form is open, 
            if (signUpForm.IsSignUpFormOpen())
            {
                // click on "not a member? signup" button
                signUpForm.ClickNotMemberSignUp();

                // find the sign up button and click
                signUpForm.ClickSignUp();
            }
            // if form not open
            else throw new NotFoundException("Form not open");


            //  assert 

            // wait till error messages appear
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => "username is required" == signUpForm.UserNameError.ToLower());

            // assert user name required error
            Assert.AreEqual("username is required", signUpForm.UserNameError.ToLower());
            // assert password required error
            Assert.AreEqual("password is required", signUpForm.PasswordError.ToLower());
            // assert confirm password required error
            Assert.AreEqual("please confirm your password", signUpForm.ConfirmPasswordError.ToLower());

        }
        [TestMethod]
        public void SignUpValidationIncorrectInputErrors()
        {

            // setup

            // click on login-signup icon
            driver.FindElement(By.ClassName("nav-login-signup")).Click();


            // act 

            // initialize sign up form object
            SignUpForm signUpForm = new SignUpForm(driver);

            // WAIT

            // wait till pop up form appears
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => signUpForm.IsSignUpFormOpen());

            // if the form is openopen, 
            if (signUpForm.IsSignUpFormOpen())
            {
                // click on "not a member? signup" button
                signUpForm.ClickNotMemberSignUp();

                // check if the form open
                if (signUpForm.IsSignUpFormOpen())
                {
                    string value = "abc";

                    // enter username
                    signUpForm.EnterUserName = value;
                    // enter password
                    signUpForm.EnterPassword = value;
                    // confirm password
                    signUpForm.ConfirmPassword = "def";

                    // find the sign up button and click
                    signUpForm.ClickSignUp();

                }                
            }
            // if form not open
            else throw new NotFoundException("Form not open");


            //  assert 

            // assert user name required error
            Assert.AreEqual("username must be minimum of 6 characters", signUpForm.UserNameError.ToLower());
            // assert password required error
            Assert.AreEqual("password must be minimum of 8 characters", signUpForm.PasswordError.ToLower());
            // assert confirm password required error
            Assert.AreEqual("your passwords do not match", signUpForm.ConfirmPasswordError.ToLower());
        }
        [TestMethod]
        public void SignUpValidationUserNameExistsError()
        {

            // setup

            // click on login-signup icon
            driver.FindElement(By.ClassName("nav-login-signup")).Click();


            // act 

            // initialize sign up form object
            SignUpForm signUpForm = new SignUpForm(driver);

            // WAIT

            // wait till pop up form appears
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => signUpForm.IsSignUpFormOpen());

            // if the form is open, 
            if (signUpForm.IsSignUpFormOpen())
            {
                // click on "not a member? signup" button
                signUpForm.ClickNotMemberSignUp();

                // if the form is refreshed with new input, 
                if (signUpForm.IsSignUpFormOpen())
                {
                    // enter username
                    signUpForm.EnterUserName = "donaldtrump";  
                    
                    // click signup button
                    signUpForm.ClickSignUp();                   
                }
            }
            else throw new NotFoundException("Form not open");


            //  assert 

            // assert user name required error
            Assert.AreEqual("username already exists", signUpForm.UserNameError.ToLower());       
        }
    }
}
