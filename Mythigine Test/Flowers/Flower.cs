using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mythigine;
using System.Reflection;
using System.ComponentModel;

namespace FlowersOutput
{
    public class Flower : DNAPool
    {
        public Flower(int id) : base(id)
        {
        }

        public Flower(int id, GenePool genes) : base(id, genes)
        {
        }

        public Flower(int id, Flower f, Flower m) : base(id, f, m)
        {
        }
    }
}