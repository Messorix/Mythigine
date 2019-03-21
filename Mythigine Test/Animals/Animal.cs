using Mythigine;
using System.Collections.Generic;

namespace AnimalsOutput
{
    public class Animal : DNAPool
    {
        public Races Race { get; private set; }

        public Animal(int id, Races race) : base(id)
        {
            Race = race;
        }

        public Animal(int id, Races race, GenePool genes) : base(id, genes)
        {
            Race = race;
        }

        public Animal(int id, Races race, Animal f, Animal m) : base(id, f, m)
        {
            Race = race;
        }
    }
}