using System;

namespace Chapter3
{
    public interface IBeverage
    {
        string GetDiscription();
        double Cost();
    }
    public abstract class Beverage : IBeverage
    {
        public Beverage()
        {
            _discription = "unknown beverage";
        }
        protected string _discription;

        public abstract double Cost();

        public string GetDiscription()
        {
            return _discription;
        }
    }
    public class DarkRoasted : Beverage
    {
        public DarkRoasted()
        {
            _discription = "Dark Roasted";
        }
        public override double Cost()
        {
            return 1.5;
        }
    }
    public class Espresso : Beverage
    {
        public Espresso()
        {
            _discription = "Espresso";
        }
        public override double Cost()
        {
            return 2.0;
        }
    }
    public abstract class CondimentDecorator : Beverage
    {
    }
    public class Mocha : CondimentDecorator
    {
        private Beverage _beverage;
        public Mocha(Beverage b)
        {
            _beverage = b;
            _discription = b.GetDiscription() + ", mocha";
        }
        public override double Cost()
        {
            return _beverage.Cost() + 1.0;
        }

    }
    public class Whip : CondimentDecorator
    {

        private Beverage _bevarage;
        public Whip(Beverage b)
        {
            _bevarage = b;
            _discription = _bevarage.GetDiscription() + ", whip";
        }
        public override double Cost()
        {
            return _bevarage.Cost() + 2.5;
        }

    }    
    public class TestDecorator
    {
        public static void Test()
        {
            Beverage beverage = new DarkRoasted();
            beverage = new Mocha(beverage);
            Console.WriteLine(beverage.GetDiscription());
            beverage = new Mocha(beverage);
            Console.WriteLine(beverage.GetDiscription());
            beverage = new Whip(beverage);
            Console.WriteLine(beverage.GetDiscription());

        }
    }

}