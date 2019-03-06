using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PlayGroundConsoleApp
{
    class Item
    {
        public int id { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            var itemAsItem = obj as Item;
            if (itemAsItem != null)
            {
                return itemAsItem.id == this.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int loopMax = 10000;
            int i = loopMax;
            List<Item> items = new List<Item>();
            Stopwatch s = new Stopwatch();
            s.Start();
            while (i > 0)
            {
                if (!items.Exists(_ => _.id == i))
                {
                    items.Add(new Item { id = i, Name = $"Item{i}" });
                }
                i--;
            }
            i = loopMax;
            while (i > 0)
            {
                if (!items.Exists(_ => _.id == i))
                {
                    items.Add(new Item { id = i, Name = $"Item{i}" });
                }
                i--;
            }
            s.Stop();
            Console.WriteLine($"it took {s.ElapsedMilliseconds} ms for list");

            i = loopMax;
            var hashSetItems = new HashSet<Item>();
            s.Reset();
            s.Start();
            while (i > 0)
            {
                hashSetItems.Add(new Item { id = i, Name = $"Item{i}" });
                i--;
            }
            i = loopMax;
            while (i > 0)
            {
                hashSetItems.Add(new Item { id = i, Name = $"Item{i}" });
                i--;
            }
            s.Stop();
            Console.WriteLine($"it took {s.ElapsedMilliseconds} ms for hashset");
            // ---
            var dictionaryItems = new Dictionary<int, Item>();
            s.Reset();
            s.Start();
            while (i > 0)
            {
                dictionaryItems.Add(i, new Item { id = i, Name = $"Item{i}" });
                i--;
            }
            i = loopMax;
            while (i > 0)
            {
                dictionaryItems.Add(i, new Item { id = i, Name = $"Item{i}" });
                i--;
            }
            s.Stop();
            Console.WriteLine($"it took {s.ElapsedMilliseconds} ms for Dictionary<int,Item>");
            Console.WriteLine($"list number of items in list = {items.Count}");
            Console.WriteLine($"list number of items in hashset = {hashSetItems.Count}");

            Console.Read();
        }
    }
}
