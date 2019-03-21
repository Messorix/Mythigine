using System;

namespace Mythigine
{
    public class Gene
    {
        public Gene(Type _t, EnumBase _d, EnumBase _r)
        {
            Trait = _t;
            Dominant = _d;
            Recessive = _r;
        }

        public Type Trait { get; }

        public EnumBase Dominant { get; }
        public EnumBase Recessive { get; }
    }
}