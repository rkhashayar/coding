using System;

namespace Chapter4
{
    public enum PizzaType
    {
        Cheese,
        Pepperoni,
        Vegi
    }

    public interface IPizza
    {
        void Prepare();
        void Bake();
        void Cut();
        void Box();
    }

    public class CheesePizza : IPizza
    {
        // use of abstract factory
        IPizzaIngredientFactory _pizzaIngredientFactory;
        public CheesePizza(IPizzaIngredientFactory pizzaIngredientFactory)
        {
            _pizzaIngredientFactory = pizzaIngredientFactory;
        }
        public void Bake()
        {
            Console.WriteLine("baking cheese pizza");
        }

        public void Box()
        {
            Console.WriteLine("boxing cheese pizza");
        }

        public void Cut()
        {
            Console.WriteLine("cutting cheese pizza");
        }

        public void Prepare()
        {
            _pizzaIngredientFactory.GetCheese();
            Console.WriteLine("preparing cheese pizza");
        }
    }

    public class PeperroniPizza : IPizza
    {
        IPizzaIngredientFactory _pizzaIngredientFactory;
        public PeperroniPizza(IPizzaIngredientFactory pizzaIngredientFactory)
        {
            _pizzaIngredientFactory = pizzaIngredientFactory;
        }
        public void Bake()
        {
            Console.WriteLine("baking Peperroni pizza");
        }

        public void Box()
        {
            Console.WriteLine("boxing Peperroni pizza");
        }

        public void Cut()
        {
            Console.WriteLine("cutting Peperroni pizza");
        }

        public void Prepare()
        {
            _pizzaIngredientFactory.GetPepperoni();
            _pizzaIngredientFactory.GetCheese();
            Console.WriteLine("preparing Peperroni pizza");
        }
    }

    public class VegiPizza : IPizza
    {
        public void Bake()
        {
            Console.WriteLine("baking Vegi pizza");
        }

        public void Box()
        {
            Console.WriteLine("boxing Vegi pizza");
        }

        public void Cut()
        {
            Console.WriteLine("cutting Vegi pizza");
        }

        public void Prepare()
        {
            Console.WriteLine("preparing Vegi pizza");
        }
    }

    public abstract class PizzaStore
    {
        public abstract IPizza GetPizza(PizzaType pizzaType);

        public IPizza Order(PizzaType pizzaType)
        {
            IPizza pizza = GetPizza(pizzaType);
            pizza?.Prepare();
            pizza?.Bake();
            pizza?.Cut();
            pizza?.Box();
            return pizza;
        }
    }

    public class NYPizzaStore : PizzaStore
    {
        public override IPizza GetPizza(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.Cheese:
                    return new CheesePizza(new NYPizzaIngredient());
                case PizzaType.Pepperoni:
                    return new PeperroniPizza(new NYPizzaIngredient());
                case PizzaType.Vegi:
                    return new VegiPizza();
                default:
                    return null;
            }
        }
    }

    public class TestFactory
    {
        public static void Test()
        {
            PizzaStore pizzaStore = new NYPizzaStore();
            pizzaStore.Order(PizzaType.Pepperoni);
        }
    }
}
