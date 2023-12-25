using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLand.Classes
{
    public class Room : ThingHolder
    {
        private Rm _n;
        private Rm _s;
        private Rm _w;
        private Rm _e;

        public Room(string aName, string aDescription, Rm n, Rm s, Rm w, Rm e) : base (aName, aDescription)
        {
            _n = n;
            _s = s;
            _w = w;
            _e = e;
        }

       public Rm N
        {
            get => _n;
            set => _n = value;
        }

        public Rm S
        {
            get => _s;
            set => _s = value;
        }

        public Rm W
        {
            get => _w;
            set => _w = value;
        }

        public Rm E
        {
            get => _e; 
            set => _e = value;
        }

        public string Describe()
        {
            return $"[{Name}] This is {Description}";
        }
    }
}
