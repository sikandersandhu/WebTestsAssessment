using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;


/*    Changes to commit
*    
*    Pizza page
*    
*    - Add wrapper method to get several pizzas matching a predicate | GetPizza()
*    - Delete                                                        | GetAllVeganPizzas()
*    - Delete                                                        | GetVeganPizza
*    - Delete private variable veganPizzas
*   
*    
*/

namespace WebTestsAssessment
{
    public class PizzaPage
    {
        private ChromeDriver driver;

        public PizzaPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        // return a PizzaTile object that satisfies the predicate evaluation to true
        public PizzaTile GetPizza(Predicate<PizzaTile> predicate)
        {
            foreach (IWebElement pizza in driver.FindElements(By.ClassName("pizza"))) {

                // initialize pizza tile object to access "Vegan" property
                PizzaTile pizzaTile = new PizzaTile(pizza);

                if (predicate.Invoke(pizzaTile)) return pizzaTile;
            }
            throw new NotFoundException("Pizza not found");
        }

        // return a list of PizzaTile objects that satisfy the predicate evaluation to true
        public List<PizzaTile> GetPizzas(Predicate<PizzaTile> predicate)
        {
            List<PizzaTile> pizzas = new List<PizzaTile>();

            foreach (IWebElement pizza in driver.FindElements(By.ClassName("pizza")))
            {

                // initialize pizza tile object to access "Vegan" property
                PizzaTile pizzaTile = new PizzaTile(pizza);

                if (predicate.Invoke(pizzaTile)) pizzas.Add(pizzaTile);
            }
            if ( pizzas != null) return pizzas;
            else throw new NotFoundException("Pizza not found");
        }
    }
}