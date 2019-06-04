using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    public interface IPizzaIngredientFactory
    {
        void GetDough();
        void GetSauce();
        void GetCheese();
        void GetVeggies();
        void GetPepperoni();
        void GetClam();
    }
    public class NYPizzaIngredient : IPizzaIngredientFactory
    {
        public void GetCheese()
        {
            Console.WriteLine("got NY cheese");
        }

        public void GetClam()
        {
            Console.WriteLine("got NY clam");

        }

        public void GetDough()
        {
            Console.WriteLine("got NY dough");

        }

        public void GetPepperoni()
        {
            Console.WriteLine("got NY pepperoni");

        }

        public void GetSauce()
        {
            Console.WriteLine("got NY sauce");

        }

        public void GetVeggies()
        {
            Console.WriteLine("got NY veggies");

        }
    }
}
