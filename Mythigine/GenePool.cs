using System;
using System.Collections;
using System.Collections.Generic;

namespace Mythigine
{
    public class GenePool : IEnumerable
    {
        private List<Gene> Genes { get; set; }

        internal int Count { get { return Genes.Count; } }
        internal bool Exists { get { return (Genes != null); } }
        internal bool IsEmpty { get { return (Genes.Count == 0); } }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Genes).GetEnumerator();
        }

        internal void Init()
        {
            Genes = new List<Gene>();
        }
        public void Add(Gene gene)
        {
            if (!Exists)
                Genes = new List<Gene>();

            Genes.Add(gene);
        }
        public Gene FindByTrait(Type trait)
        {
            foreach (Gene g in Genes)
            {
                if (g.Trait.Equals(trait))
                    return g;
            }
            return null;
        }
    }
}