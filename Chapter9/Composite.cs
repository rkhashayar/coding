using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter9
{
    public abstract class  MenuComponent
    {
        public virtual void Add(MenuComponent item)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(MenuComponent item)
        {
            throw new NotImplementedException();
        }
        public virtual MenuComponent GetChild(int i)
        {
            throw new NotImplementedException();
        }
        public virtual void Print()
        {
            throw new NotImplementedException();
        }
        public virtual string GetDescription()
        {
            throw new NotImplementedException();
        }
        public virtual string GetName()
        {
            throw new NotImplementedException();
        }
        public virtual decimal GetPrice()
        {
            throw new NotImplementedException();
        }
        public virtual bool IsVegetarian()
        {
            throw new NotImplementedException();
        }
    }
    public class CompositeMenuItem : MenuComponent
    {
        private string _name;
        private decimal _price;
        private string _description;
        private bool _isVegetarian;
        public CompositeMenuItem(string name, decimal price, string description, bool isVegetarian)
        {
            _name = name;
            _price = price;
            _description = description;
            _isVegetarian = isVegetarian;
        }

        public override string GetName()
        {
            return _name;
        }
        public override string GetDescription()
        {
            return _description;
        }
        public override decimal GetPrice()
        {
            return _price;
        }
        public override bool IsVegetarian()
        {
            return _isVegetarian;
        }
        public override void Print()
        {
            Console.WriteLine($"this is an item name = \"{GetName() + ((IsVegetarian())?"(V)":"")}\"");
        }
    }
    public class CompositeMenu : MenuComponent
    {
        private string _name;
        private string _description;
        private List<MenuComponent> _menuComponents;
        public CompositeMenu(string name, string description)
        {
            _name = name;
            _description = description;
            _menuComponents = new List<MenuComponent>();
        }

        public override void Add(MenuComponent item)
        {
            _menuComponents.Add(item);
        }

        public override void Remove(MenuComponent item)
        {
            _menuComponents.Remove(item);
        }
        public override MenuComponent GetChild(int i)
        {
            return _menuComponents[i];
        }
        public override string GetName()
        {
            return _name;
        }
        public override string GetDescription()
        {
            return _description;
        }
        public override void Print()
        {
            Console.WriteLine($"this is the menu with name = {GetName()}");
            Console.WriteLine($"** menu description = {GetDescription()}");
            var menuIterator = _menuComponents.GetEnumerator();
            while (menuIterator.MoveNext())
            {
                menuIterator.Current.Print();
            }
        }
    }
    public class Waitress
    {
        private MenuComponent _allMenus;
        public Waitress(MenuComponent allMenus)
        {
            _allMenus = allMenus;
        }
        public void PrintMenu()
        {
            _allMenus.Print();
        }
    }

    public class TestComposite
    {

    }
}
