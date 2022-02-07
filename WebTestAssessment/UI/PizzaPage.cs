using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace WebTestsAssessment
{
    public class PizzaPage
    {
        private ChromeDriver driver;
        private List<PizzaTile> veganPizzas;

        public PizzaPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public List<PizzaTile> GetAllVeganPizza()
        {
            // initialize the list to insert vegan pizza tiles to and return
            veganPizzas = new List<PizzaTile>();

            // check within the list of all pizzas
            foreach (IWebElement pizza in driver.FindElements(By.ClassName("pizza")))
            {
                // initialize pizza tile object to access "Vegan" property
                PizzaTile pizzaTile = new PizzaTile(pizza);

                // if pizza is vegan, add it to the vegan pizzas list
                if (pizzaTile.Pizza.ToLower().Contains("vegan"))  veganPizzas.Add(pizzaTile);                 
            }
            // return the list of vegan pizzas
            return veganPizzas;
        }

        public PizzaTile GetVeganPizza( PizzaTile veganPizza , Predicate<PizzaTile> predicate)
        {
            if (predicate.Invoke(veganPizza)) return veganPizza;          
            throw new NotFoundException("Pizza not found");
        }
    }
}