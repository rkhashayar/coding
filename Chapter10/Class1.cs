using System;

namespace Chapter10
{
    public interface IGumballState
    {
        void InsertQuarters();
        void EjectQuarters();
        void TurnCrank();
        void Dispense();
    }
    public class NoQuarters : IGumballState
    {
        private IGumballMachine _gumballMachine;
        public NoQuarters(IGumballMachine gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            Console.WriteLine("Dear customer there is nothing left.");
            _gumballMachine.SetState(_gumballMachine.)
        }

        public void EjectQuarters()
        {
            throw new NotImplementedException();
        }

        public void InsertQuarters()
        {
            Console.WriteLine("you inserted a quarter.");
            
        }

        public void TurnCrank()
        {
            throw new NotImplementedException();
        }
    }

    public interface IGumballMachine
    {
        void SetState();
        void GetHasQuarterState();
    }
    public class GumballMachine
    {

    }
}
