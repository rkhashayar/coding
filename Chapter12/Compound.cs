using System;
using System.Collections.Generic;

namespace Chapter12
{
    // compound patterns
    public interface IQuackable : IQuackObservable
    {
        void Quack();
    }
    public class RedHeadDuck : IQuackable
    {
        private IQuackObservable _observable;
        public RedHeadDuck()
        {
            _observable = new QuackObservable(this);
        }
        public void NotifyObservers()
        {
            _observable.NotifyObservers();
        }

        public void Quack()
        {
            Console.WriteLine("Red Head Quacked");
            NotifyObservers();
        }

        public void RegisterObserver(IQuackObserver quackObserver)
        {
            _observable.RegisterObserver(quackObserver);
        }
    }
    public class MallardDuck : IQuackable
    {
        private QuackObservable _observerable;
        public MallardDuck()
        {
            _observerable = new QuackObservable(this);
        }
        public void NotifyObservers()
        {
            _observerable.NotifyObservers();
        }

        public void Quack()
        {
            Console.WriteLine("Mallard Duck Quacked");
            NotifyObservers();
        }

        public void RegisterObserver(IQuackObserver quackObserver)
        {
            _observerable.RegisterObserver(quackObserver);
        }
    }
    public class CallDuck : IQuackable
    {
        private QuackObservable _observerable;
        public CallDuck()
        {
            _observerable = new QuackObservable(this);
        }
        public void NotifyObservers()
        {
            _observerable.NotifyObservers();
        }

        public void Quack()
        {
            Console.WriteLine("this is not a real duck.");
            NotifyObservers();
        }

        public void RegisterObserver(IQuackObserver quackObserver)
        {
            _observerable.RegisterObserver(quackObserver);
        }
    }
    public class RubberDuck : IQuackable
    {
        private QuackObservable _observerable;
        public RubberDuck()
        {
            _observerable = new QuackObservable(this);
        }
        public void NotifyObservers()
        {
            _observerable.NotifyObservers();
        }

        public void Quack()
        {
            Console.WriteLine("rubber duck squeak");
            NotifyObservers();
        }

        public void RegisterObserver(IQuackObserver quackObserver)
        {
            _observerable.RegisterObserver(quackObserver);
        }

    }

    public interface ISimulator
    {
        void Simulate();
    }

    public class DuckSimulator : ISimulator
    {
        private AbstractDuckFacotry _abstarctDuckFactory;
        public DuckSimulator(AbstractDuckFacotry abstractDuckFacotry)
        {
            _abstarctDuckFactory = abstractDuckFacotry;
        }
        public void Simulate()
        {
            // use the abstract factory instead of having the instantiations
            IQuackable mallardDuck = _abstarctDuckFactory.CreateMallardDuck(); // new MallardDuck();
            IQuackable redHeadDuck = _abstarctDuckFactory.CreateRedHedDuck(); // new RedHeadDuck();
            IQuackable rubberDuck = _abstarctDuckFactory.CreateRubberDuck(); // new RubberDuck();
            IQuackable duckCall = _abstarctDuckFactory.CreateDuckCall(); // new CallDuck();
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

            DuckComposite flockOfDucks = new DuckComposite();
            flockOfDucks.AddDucks(mallardDuck);
            flockOfDucks.AddDucks(redHeadDuck);
            flockOfDucks.AddDucks(rubberDuck);
            flockOfDucks.AddDucks(duckCall);
            DuckComposite flockOfMallards = new DuckComposite();
            flockOfMallards.AddDucks(mallardDuck);
            flockOfMallards.AddDucks(mallardDuck);
            flockOfMallards.AddDucks(mallardDuck);
            flockOfMallards.AddDucks(mallardDuck);
            flockOfDucks.AddDucks(flockOfMallards);
            Simulate(flockOfDucks);
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
        private QuackObservable _observable;
        IHonker _honker;
        public DuckAdaptor(IHonker honker)
        {
            _honker = honker;
            _observable = new QuackObservable(this);
        }

        public void NotifyObservers()
        {
            _observable.NotifyObservers();
        }

        public void Quack()
        {
            _honker.Honk();
            NotifyObservers();
        }

        public void RegisterObserver(IQuackObserver quackObserver)
        {
            _observable.RegisterObserver(quackObserver);
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

        public void RegisterObserver(IQuackObserver quackObserver)
        {
            _quackable.RegisterObserver(quackObserver);
        }

        public void NotifyObservers()
        {
            _quackable.NotifyObservers();
        }
    }
    // use abstract factory to be able to remove instantiation 
    public abstract class AbstractDuckFacotry
    {
        public abstract IQuackable CreateMallardDuck();
        public abstract IQuackable CreateRedHedDuck();
        public abstract IQuackable CreateDuckCall();
        public abstract IQuackable CreateRubberDuck();
    }
    public class DuckFactory : AbstractDuckFacotry
    {
        public override IQuackable CreateDuckCall()
        {
            return new CallDuck();
        }

        public override IQuackable CreateMallardDuck()
        {
            return new MallardDuck();
        }

        public override IQuackable CreateRedHedDuck()
        {
            return new RedHeadDuck();
        }

        public override IQuackable CreateRubberDuck()
        {
            return new RubberDuck();
        }
    }

    public class CountableDuckQuackFactory : AbstractDuckFacotry
    {
        public override IQuackable CreateDuckCall()
        {
            return new QuackCounterDecorator(new CallDuck());
        }

        public override IQuackable CreateMallardDuck()
        {
            return new QuackCounterDecorator(new MallardDuck());
        }

        public override IQuackable CreateRedHedDuck()
        {
            return new QuackCounterDecorator(new RedHeadDuck());
        }

        public override IQuackable CreateRubberDuck()
        {
            return new QuackCounterDecorator(new RubberDuck());
        }
    }
    // composite pattern is going to make is easier for managing multiple ducks
    public class DuckComposite : IQuackable
    {
        List<IQuackable> _quackables;
        public DuckComposite()
        {
            _quackables = new List<IQuackable>();
        }
        public void AddDucks(IQuackable quackable)
        {
            _quackables.Add(quackable);
        }

        public void NotifyObservers()
        {            
        }

        public void Quack()
        {
            _quackables.ForEach(_ => { _.Quack();});
        }

        public void RegisterObserver(IQuackObserver quackObserver)
        {
            _quackables.ForEach(_=> { _.RegisterObserver(quackObserver); });
        }
    }

    #region OBSERVER
    // observer pattern to monitor individual ducks
    public interface IQuackObservable
    {
        void RegisterObserver(IQuackObserver quackObserver);
        void NotifyObservers();
    }

    public interface IQuackObserver
    {
        void Update();
    }

    public class QuackObservable : IQuackObservable
    {
        private List<IQuackObserver> _quackObservers;
        private IQuackable _duck;
        public QuackObservable(IQuackable duck)
        {
            _duck = duck;
            _quackObservers = new List<IQuackObserver>();
        }

        public void NotifyObservers()
        {
            _quackObservers.ForEach(_ => _.Update());
        }

        public void RegisterObserver(IQuackObserver quackObserver)
        {
            _quackObservers.Add(quackObserver);
        }
    }

    
    public class Quackologist : IQuackObserver
    {
        public void Update()
        {
            Console.WriteLine("we got a quack!");
        }
    }
    #endregion

}
