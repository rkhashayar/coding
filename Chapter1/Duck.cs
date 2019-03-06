using System;

namespace Chapter1
{
    public interface IFlyBehavior
    {
        void Fly();
    }
    public class FlyLikeJet : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I fly like JET!");
        }
    }

    public class FlyLikeDuck : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I Fly Like A Duck!");
        }
    }

    public interface IQuackBehavior
    {
        void MakeSound();
    }

    public class QuackLikeDucks : IQuackBehavior
    {
        public void MakeSound()
        {
            Console.WriteLine("I quack like ducks!");
        }
    }

    public abstract class Duck
    {
        protected IFlyBehavior _flyBehavior;
        protected IQuackBehavior _quackBehavior;

        public IFlyBehavior FlyBehavior { get { return _flyBehavior; } set { _flyBehavior = value; }  }

        public Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
        {
            _flyBehavior = flyBehavior;
            _quackBehavior = quackBehavior;
        }

        public void RunFly()
        {
            _flyBehavior.Fly();
        }

        public void RunQuack()
        {
            _quackBehavior.MakeSound();
        }
    }


    public class JetDuck : Duck
    {
        public JetDuck() : base(new FlyLikeJet(), new QuackLikeDucks())
        {
          
        }
    }

    public class TestDucks
    {
        public static void Test()
        {
            Console.WriteLine("testing jet duck");
            var d = new JetDuck();
            d.RunFly();
            d.FlyBehavior = new FlyLikeDuck();
            d.RunFly();
            d.RunQuack();            
        }
    }
}
