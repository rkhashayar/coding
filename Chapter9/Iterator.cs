using System;
using System.Collections.Generic;

namespace Chapter9
{
    public interface IMenu
    {
        IIterator GetMenuIterator();
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Vegeterian { get; set; }
        public double Price { get; set; }

    }
    public class PancakeHouseMenu : IMenu
    {
        MenuItem[] _menuItems;
        public PancakeHouseMenu()
        {
            _menuItems = new MenuItem[2];
            _menuItems[0] = new MenuItem { Description = "PancakeDesc1", Name = "Pancake1", Price = 1.1d, Vegeterian = false };
            _menuItems[1] = new MenuItem { Description = "PancakeDesc2", Name = "Pancake2", Price = 2.1d, Vegeterian = true };
        }
        public MenuItem[] GetMenuItems()
        {
            return _menuItems;
        }

        public IIterator GetMenuIterator()
        {
            return new DinerMenuIterator(_menuItems);
        }
    }

    public class DinerMenu 
    {
        MenuItem[] _menuItems;
        public DinerMenu()
        {
            _menuItems = new MenuItem[10];
            for (int i = 0; i < _menuItems.Length; i++)
            {
                _menuItems[i] = new MenuItem
                {
                    Description = $"DinerMenuDesc{i}",
                    Name = $"DinerMenuName{i}",
                    Price = 1.1 + i,
                    Vegeterian = (i / 2 == 0) ? true : false
                };
            }
        }

        public MenuItem[] GetMenuItems()
        {
            return _menuItems;
        }
    }

    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    public class DinerMenuIterator : IIterator
    {
        private MenuItem[] _menuItems;
        private int _position = 0;
        public DinerMenuIterator(MenuItem[] menuItems)
        {
            _menuItems = menuItems;
        }

        public bool HasNext()
        {
            return _menuItems.Length > _position;
        }

        public object Next()
        {
            _position++;
            return _menuItems[_position];
        }
    }
   
}
