using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeLearning
{
    class Program
    {
        static IList<int> listOfInt = new List<int>() { 1, 2, 3, 4, 5, 6 };

        static void Main(string[] args)
        {
            foreach (var item in CustomIteration())
            {
                Console.WriteLine(item.ToString());
            }
            foreach (var item in StatefulIteration())
            {
                Console.WriteLine(item.ToString());
            }
            Console.Read();
        }

        #region Yield Key Word
        /*
         * used for 1. custom interation
         *          2. stateful iteration
         */

        //  1.
        static IEnumerable<int> CustomIteration()
        {
            foreach (var item in listOfInt)
            {
                if (item > 3)
                {
                    yield return item;
                }
            }
        }

        // 2. stateful
        static IEnumerable<int> StatefulIteration()
        {
            var total = 0;
            foreach (var item in listOfInt)
            {
                total += item;
                yield return total;
            }
        }
        #endregion



    }
}
