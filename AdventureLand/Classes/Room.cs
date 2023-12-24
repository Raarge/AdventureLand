using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLand.Classes
{
    public class Room : Thing
    {
        private int _n;
        private int _s;
        private int _w;
        private int _e;

        public Room(string aName, string aDescription, int n, int s, int w, int e) : base (aName, aDescription)
        {
            _n = n;
            _s = s;
            _w = w;
            _e = e;
        }

       public int N
        {
            get => _n;
            set => _n = value;
        }

        public int S
        {
            get => _s;
            set => _s = value;
        }

        public int W
        {
            get => _w;
            set => _w = value;
        }

        public int E
        {
            get => _e; 
            set => _e = value;
        }
    }
}
