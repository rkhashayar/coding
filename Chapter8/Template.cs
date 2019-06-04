using System;

namespace Chapter8
{
    public abstract class CaffeineBeverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
            Hook();
        }
        public void BoilWater()
        {
            Console.WriteLine("Water is boiling.");
        }
        public void PourInCup()
        {
            Console.WriteLine("Pour in cup.");
        }
        public abstract void Brew();
        public abstract void AddCondiments();
        /// <summary>
        /// this function is to be able to let child classes have their own implemenation of same fucntion
        /// </summary>
        public virtual void Hook() { }
    }

    public class Tea : CaffeineBeverage
    {
        public override void AddCondiments()
        {
            Console.WriteLine("Tea condiments added");
        }
        public override void Brew()
        {
            Console.WriteLine("Steep the tea bag in the water;");
        }
    }
    public class Coffee : CaffeineBeverage
    {
        public override void AddCondiments()
        {
            Console.WriteLine("Coffee and condiments");
        }

        public override void Brew()
        {
            Console.WriteLine("Brew the coffee");
        }
        public override void Hook()
        {
            base.Hook();
            Console.WriteLine("this is coffee hook");
        }
    }
}
