using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVersionsFeatures
{
    public class RefUsages
    {
        public ref string GetPointerToArray(string[] array, int pos)
        {
            return ref array[pos];
        }

        public string GetArrayItem(string[] array, int pos)
        {
            return array[pos];
        }

        public void TestRefUsage()
        {
            string[] array = new[] { "one", "two", "three" };
            Array.ForEach(array, _ => Console.WriteLine(_));
            var item = GetArrayItem(array, 1);
            item = "new";
            Array.ForEach(array, _ => Console.WriteLine(_));
            ref var item2 = ref GetPointerToArray(array, 1);
            item2 = "new";
            Array.ForEach(array, _ => Console.WriteLine(_));
        }
    }
}
