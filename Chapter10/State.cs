using System;

namespace Chapter10
{
    #region States
    public interface IGumballState
    {
        void InsertQuarters();
        void EjectQuarters();
        void TurnCrank();
        void Dispense();
    }
    public class NoQuartersState : IGumballState
    {
        private IGumballMachine _gumballMachine;
        public NoQuartersState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            Console.WriteLine("Please insert a quarter!!!");
        }

        public void EjectQuarters()
        {
            Console.WriteLine("There is no quarters in!!!");
        }

        public void InsertQuarters()
        {
            Console.WriteLine("you inserted a quarter.");
            _gumballMachine.SetState(_gumballMachine.GetHasQuarterState());
        }

        public void TurnCrank()
        {
            Console.WriteLine("You need to insert a quarter to be able to get a yummy one :-)");
        }
    }

    public class SoldOutState : IGumballState
    {
        private IGumballMachine _gumballMachine;
        public SoldOutState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            Console.WriteLine("There is no gumballs left to be sold!!!");
        }

        public void EjectQuarters()
        {
            Console.WriteLine("No quarters inserted!!");
        }

        public void InsertQuarters()
        {
            Console.WriteLine("Please come back later when gumballs available.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("No gumball available.");
        }
    }

    public class SoldState : IGumballState
    {
        private IGumballMachine _gumballMachine;
        public SoldState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            if (_gumballMachine.ReleaseGumball() == 0)
            {
                Console.WriteLine("Oops out of gumbulls.");
                _gumballMachine.SetState(_gumballMachine.GetSoldOutState());
                return;
            }
            _gumballMachine.SetState(_gumballMachine.GetNoQuarterState());
        }

        public void EjectQuarters()
        {
            Console.WriteLine("No quarters inserted!!");
        }

        public void InsertQuarters()
        {
            Console.WriteLine("Please come back later when gumballs available.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("No gumball available.");
        }
    }

    public class HasQuartersState : IGumballState
    {
        private IGumballMachine _gumballMachine;
        public HasQuartersState(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            Console.WriteLine("this doesn't fit in.");
        }

        public void EjectQuarters()
        {
            Console.WriteLine("No quarters inserted!!");
        }

        public void InsertQuarters()
        {
            Console.WriteLine("Please come back later when gumballs available.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("No gumball available.");
        }
    }
    #endregion


    public interface IGumballMachine
    {
        void SetState(IGumballState gumballState);
        IGumballState GetHasQuarterState();
        IGumballState GetSoldOutState();
        IGumballState GetSoldState();
        IGumballState GetNoQuarterState();
        int GetCount();
        int ReleaseGumball();
    }
    public class GumballMachine : IGumballMachine
    {
        private IGumballState _noQuartersState,
            _soldOutState,
            _hasQuarterState,
            _soldState;
        private int _gumballsCount = 0;
        private IGumballState _state;
        public GumballMachine(int gumballsCount)
        {
            _gumballsCount = gumballsCount;
            _hasQuarterState = new HasQuartersState(this);
            _noQuartersState = new NoQuartersState(this);
            _soldOutState = new SoldOutState(this);
            _soldState = new SoldState(this);
            if (_gumballsCount > 0)
                _state = _noQuartersState;
        }

        public int GetCount()
        {
            return _gumballsCount;
        }

        public void InsertQuarter()
        {
            _state.InsertQuarters();
        }
        public void EjectQuarter()
        {
            _state.EjectQuarters();
        }
        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }
        public IGumballState GetHasQuarterState()
        {
            throw new NotImplementedException();
        }

        public IGumballState GetNoQuarterState()
        {
            throw new NotImplementedException();
        }

        public IGumballState GetSoldOutState()
        {
            throw new NotImplementedException();
        }

        public IGumballState GetSoldState()
        {
            throw new NotImplementedException();
        }

        public int ReleaseGumball()
        {
            if (_gumballsCount > 0)
            {
                --_gumballsCount;
                Console.WriteLine("A gumball released.");
            }
            return _gumballsCount;
        }

        public void SetState(IGumballState gumballState)
        {
            _state = gumballState;
        }
    }
}
