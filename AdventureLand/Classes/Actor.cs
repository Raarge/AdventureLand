using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLand.Classes
{
    public class Actor : ThingHolder
    {
        private Room _location;
        public Actor(string aName, string aDescription, Room aRoom, ThingList tl) :
            base(aName, aDescription, tl)
        {
            _location = aRoom;
        }

        public Room Location
        {
            get => _location;
            set => _location = value;
        }

        
    }
}
