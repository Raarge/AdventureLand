using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLand.Classes
{
    public class BasicThing
    {
        private string _name;
        private string _description;

        public BasicThing(string aName, string aDescription)
        {
            _name = aName;
            _description = aDescription;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }
    }
}
