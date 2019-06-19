using System;

namespace Chapter12
{
    // compound patterns
    public interface IQuackable
    {
        void Quack();
    }
    public class RedHeadDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Red Head Quacked");
        }
    }
    public class MallardDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Mallard Duck Quacked");
        }
    }
    public class CallDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("this is not a real duck.");
        }
    }
    public class RubberDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("this is rubber duck said Squeak");
        }
    }

    public interface ISimulator
    {
        void Simulate();
    }

    public class DuckSimulator : ISimulator
    {
        public void Simulate()
        {
            IQuackable mallardDuck = new MallardDuck();
            IQuackable redHeadDuck = new RedHeadDuck();
            IQuackable rubberDuck = new RubberDuck();
            IQuackable duckCall = new CallDuck();
            // using quack adapter
            IQuackable goose = new DuckAdaptor(new Goose());
            Simulate(mallardDuck);
            Simulate(redHeadDuck);
            Simulate(rubberDuck);
            Simulate(duckCall);
            Simulate(goose);
            // using quack decorator
            IQuackable countableRedDuck = new QuackCounterDecorator(new RedHeadDuck());
            Simulate(countableRedDuck);
            IQuackable countableMallardDuck = new QuackCounterDecorator(new MallardDuck());
            Simulate(countableMallardDuck);
            Simulate(countableRedDuck);
            Console.WriteLine($"number of quacks = {QuackCounterDecorator.GetQuackCount()}");
        }
        public void Simulate(IQuackable quackable)
        {
            quackable.Quack();
        }
    }

    public interface IHonker
    {
        void Honk();
    }

    public class Goose : IHonker
    {
        public void Honk()
        {
            Console.WriteLine("this is goose Honking");
        }
    }
    // adaptor pattern to be able to make use of quackable for goose
    public class DuckAdaptor : IQuackable
    {
        IHonker _honker;
        public DuckAdaptor(IHonker honker)
        {
            _honker = honker;
        }
        public void Quack()
        {
            _honker.Honk();
        }
    }
    // counter pattern to add a behavior to duck
    public class QuackCounterDecorator : IQuackable
    {
        private IQuackable _quackable;
        private static int _quackCount = 0;
        public QuackCounterDecorator(IQuackable quackable)
        {
            _quackable = quackable;
        }
        public void Quack()
        {
            _quackable.Quack();
            _quackCount++;
        }
        public static int GetQuackCount()
        {
            return _quackCount;
        }
    }
}
