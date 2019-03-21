using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsOutput
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RaceAttribute : Attribute, IEnumerable
    {
        // Private fields.
        private Races race;

        // This constructor defines two required parameters: name and level.

        public RaceAttribute(Races race)
        {
            this.race = race;
        }

        // Define Name property.
        // This is a read-only attribute.

        public virtual Races Race
        {
            get { return race; }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
