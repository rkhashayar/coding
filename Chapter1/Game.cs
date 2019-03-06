using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter1
{
    public interface IWeaponBehavior
    {
        void UseWeapon();
    }

    public class AxeBehavior : IWeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("this is an axe");
        }
    }

    public class M16Behaior : IWeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("I am M16");
        }
    }

    public abstract class Character
    {
        private IWeaponBehavior _weaponBehavior;

        public IWeaponBehavior WeaponBehavior
        {
            get { return _weaponBehavior; }
            set { _weaponBehavior = value; }
        }

        public virtual void UseWeapon()
        {
            _weaponBehavior.UseWeapon();
        }
    }

    public class GangKing : Character
    {
        public GangKing()
        {
            WeaponBehavior = new M16Behaior();
        }
    }

    public class Solder : Character
    {
        public Solder()
        {
            WeaponBehavior = new AxeBehavior();
        }
    }

    public class TestGame
    {
        public static void Run()
        {
            var king = new GangKing();
            king.UseWeapon();
            var solder = new Solder();
            solder.UseWeapon();
        }
    }
}
