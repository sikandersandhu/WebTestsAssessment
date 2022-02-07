using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
            
            // open login or signup popup
            menuBar.OpenLoginOrSignupPage();

            // act 
            
            // initialize sign up form object
            SignUpForm signUpForm = new SignUpForm(driver);


            // wait

            // wait till pop up form appears
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => signUpForm.IsSignUpFormOpen());


            // check if the form is open, 
            if (signUpForm.IsSignUpFormOpen())
            {
                // click on "not a member? signup" button
                signUpForm.ClickNotMemberSignUp();

                // click on the "sign up" button
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

            // open login or signup popup
            menuBar.OpenLoginOrSignupPage();


            // act 

            // initialize sign up form object
            SignUpForm signUpForm = new SignUpForm(driver);


            // wait

            // wait till pop up form appears
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => signUpForm.IsSignUpFormOpen());


            // check if the form is open, 
            if (signUpForm.IsSignUpFormOpen())
            {
                // click on "not a member? signup" button
                signUpForm.ClickNotMemberSignUp();

                // check if the form is open
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
                // if form not open
                else throw new NotFoundException("Form not open");
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

            // open login or signup popup
            menuBar.OpenLoginOrSignupPage();


            // act 

            // initialize sign up form object
            SignUpForm signUpForm = new SignUpForm(driver);


            // wait

            // wait till pop up form appears
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => signUpForm.IsSignUpFormOpen());

            // check if the form is open, 
            if (signUpForm.IsSignUpFormOpen())
            {
                // click on "not a member? signup" button
                signUpForm.ClickNotMemberSignUp();

                // check if the form is open, 
                if (signUpForm.IsSignUpFormOpen())
                {
                    // enter username
                    signUpForm.EnterUserName = "donaldtrump";  
                    
                    // click signup button
                    signUpForm.ClickSignUp();                   
                }
                else throw new NotFoundException("Form not open");
            }
            else throw new NotFoundException("Form not open");


            //  assert 

            // assert user name required error
            Assert.AreEqual("username already exists", signUpForm.UserNameError.ToLower());       
        }
        [TestMethod]
        public void VerifyVeganPizzaPrice()
        {
            // setup

            // open menu page
            menuBar.OpenMenuPage();

            // initialize pizza page object
            PizzaPage pizzaPage = new PizzaPage(driver);


            // act
           
            // get a list of vegan pizza
            var veganPizzas = pizzaPage.GetAllVeganPizza();


            // assert
            
            // assert that all vegan pizzas are $14.99
            foreach (var veganPizza in veganPizzas)
            {
                pizzaPage.GetVeganPizza(veganPizza, p => p.DoublePrice == 14.99);
            }
        }
    }
}
