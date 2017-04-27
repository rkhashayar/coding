using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Contact
{
    interface IContact
    {
        string Name { get; }
        string LastName { get;}
        string GetContact();
    }
    public abstract class ContactBase : IContact
    {
        private readonly string _name;
        private readonly string _lastName;
        public ContactBase(string name, string lastname)
        {
            _name = name;
            _lastName = lastname;
        }
        public string Name => _name;
        public string LastName => _lastName;

        public string GetContact()
        {
            return $@"my contact is {Name} , {LastName}";
        }
    }
}
