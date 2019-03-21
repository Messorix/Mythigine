using System.Collections.Generic;

namespace Mythigine
{
    public abstract class DNAPool
    {
        protected internal DNAPool Father { get; private set; }
        protected internal DNAPool Mother { get; private set; }

        protected internal int ID { get; private set; }
        private protected GenePool GenePool { get; private set; }

        protected DNAPool(int id)
        {
            ID = id;
        }

        protected DNAPool(int id, GenePool genes)
        {
            ID = id;
            GenePool = genes;
        }

        protected DNAPool(int id, DNAPool f, DNAPool m)
        {
            ID = id;
            SetParents(f, m);

            if (GenePool == null)
                GenePool = new GenePool();

            if (!GenePool.Exists)
                GenePool.Init();

            if (GenePool.IsEmpty)
                GenePool = DNAController.GetSingleton().CreateChild(Father, Mother);
        }

        protected void SetParents(DNAPool f, DNAPool m)
        {
            Father = f;
            Mother = m;
        }

        public GenePool GetGenes
        {
            get
            {
                return GenePool;
            }
        }
    }
}