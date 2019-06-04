using System;

namespace Chapter7
{
    public interface IDuck
    {
        void Fly();
        void quack();
    }

    public interface ITurkey
    {
        void Gobble();
        void fly();
    }

    public class WildTurkey : ITurkey
    {
        public void fly()
        {
            Console.WriteLine("I am flying wild turkey");
        }

        public void Gobble()
        {
            Console.WriteLine("I am gobbling wild turkey");
        }
    }

    public class TurkeyAdapter : IDuck
    {
        private ITurkey _Turkey;
        public TurkeyAdapter(ITurkey turkey)
        {
            _Turkey = turkey;
        }
        public void Fly()
        {
            _Turkey.fly();
        }

        public void quack()
        {
            _Turkey.Gobble();
        }
    }
}
