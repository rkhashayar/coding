using Chapter12;
using Chapter3;
using Chapter4;
using Chapter6;
using System;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Strategy Pattern
            //TestDucks.Test();
            //TestGame.Run();

            // Observer Pattern
            //TestObserver.Test();

            //decorator test
            //TestDecorator.Test();

            // test factory
            //TestFactory.Test();

            //test command
            //TestRemoteControl.Test();
            new DuckSimulator(new CountableDuckQuackFactory()).Simulate();

            Console.ReadLine();
        }
    }
}
