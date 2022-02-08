using OpenQA.Selenium;
using System;

/*    Changes to commit
 *    
 *    PizzaTile
 *    
 *    - Add get "Rating" property
 *    - Add get "IntCalories" property
 *    
*/

namespace WebTestsAssessment
{
    public class PizzaTile
    {
        private IWebElement pizza;

        public PizzaTile(IWebElement pizza)
        {
            this.pizza = pizza;
        }

        public string Pizza => pizza.FindElement(By.ClassName("name")).Text;
        public int Rating
        {
            get
            {
                int rating = 0;

                foreach (IWebElement button in pizza.FindElements(By.TagName("button")))
                {
                    if (button.Text.ToLower() == "star")
                    {
                        rating++;
                    }
                }
                return rating;
            }
        }
        public double DoublePrice
        {
            get
            {
                string unformatted = pizza.FindElement(By.ClassName("price")).Text;
                string formatted = unformatted.Replace("$", "");
                return Convert.ToDouble(formatted);
            }
        }

        public double IntCalories
        {
            get
            {
                string unformatted = pizza.FindElement(By.ClassName("kilojoules")).Text;
                string formatted = unformatted.Replace(" ", "").Replace("kJ", "");
                Console.WriteLine(formatted);
                return Convert.ToDouble(formatted);
            }
        } 
    }
}