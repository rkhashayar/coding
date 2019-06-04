using System;

namespace Chapter5
{
    public class ChocolateBoiler
    {
        public bool IsBoiled { get; private set; }
        public bool IsEmpty { get; private set; }
        private static ChocolateBoiler _instance;
        private static readonly object _locker = new object();
        private ChocolateBoiler()
        {
            IsBoiled = false;
            IsEmpty = true;
        }

        public static ChocolateBoiler GetIstance()
        {
            lock (_locker)
            {
                if (_instance == null)
                {
                    _instance = new ChocolateBoiler();
                }
                return _instance;
            }
        }

        public void Drain()
        {
            if (!IsEmpty && IsBoiled)
            {
                IsEmpty = true;
                IsBoiled = false;
                Console.WriteLine("it is being drained");
                return;
            }
            Console.WriteLine("Boiler is empty or chocolate is not boiled");
        }
        public void Boil()
        {
            if (!IsEmpty && !IsBoiled)
            {
                IsBoiled = true;
                Console.WriteLine("it is boiled");
                return;
            }
            Console.WriteLine("either boiler is empty or already boiled");
        }
        public void Fill()
        {
            if (IsEmpty)
            {
                IsEmpty = false;
                Console.WriteLine("boiler is filled");
            }
            Console.WriteLine("boiler is full");
        }
    }
}
