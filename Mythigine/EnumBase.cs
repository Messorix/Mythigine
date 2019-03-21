using System;
using System.Collections;
using System.Collections.Generic;

namespace Mythigine
{
    public abstract class EnumBase : IEnumerable
    {
        protected static List<EnumBase> enumValues = new List<EnumBase>();

        public readonly int Key;
        public readonly string ValueAsString;
        public readonly Type ValueAsType;

        public readonly decimal Probability;
        public readonly int Dominancy;
        
        protected EnumBase(int key, Type value)
        {
            Key = key;
            ValueAsType = value;

            enumValues.Add(this);
        }

        protected EnumBase(int key, string value, decimal prob, int dom)
        {
            Key = key;
            ValueAsString = value;
            Probability = prob;
            Dominancy = dom;

            enumValues.Add(this);
        }

        protected EnumBase GetBaseByKey(int key)
        {
            foreach (EnumBase t in enumValues)
            {
                if (t.Key == key) return t;
            }
            return null;
        }

        protected EnumBase GetBaseByValue(string value)
        {
            foreach (EnumBase t in enumValues)
            {
                if (t.ValueAsString.Equals(value)) return t;
            }
            return null;
        }

        protected EnumBase GetBaseByValue(Type value)
        {
            foreach (EnumBase t in enumValues)
            {
                if (t.ValueAsType.Equals(value)) return t;
            }
            return null;
        }

        public override string ToString()
        {
            return ValueAsString;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)enumValues).GetEnumerator();
        }
    }
}