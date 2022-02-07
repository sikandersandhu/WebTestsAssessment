using OpenQA.Selenium;
using System;

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

        public double DoublePrice
        {
            get
            {
                string unformatted = pizza.FindElement(By.ClassName("price")).Text;
                string formatted = unformatted.Replace("$", "");
                return Convert.ToDouble(formatted);
            }
        }
    }
}