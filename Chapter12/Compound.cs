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
            Console.WriteLine("Squeak");
        }
    }
}
