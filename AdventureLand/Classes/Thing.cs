using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLand.Classes
{
    public class Thing : BasicThing
    {
        private bool _cantake;

        public Thing(string aName, string aDescription) : base(aName, aDescription) {
        // standard constructor:
            _cantake = true;  // default value
        }

        public Thing(string aName, string aDescription, bool aCantake) : base(aName, aDescription)
        {
            // alternate constructor:
            _cantake= aCantake;
        }

        public bool CanTake
        {
            get => _cantake;
            set => _cantake = value;
        }
    }
}
