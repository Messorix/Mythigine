using System;
using System.Collections.Generic;

namespace Mythigine
{
    public class DNAController
    {
        private bool random;
        private bool changed = false;

        private DNAController()
        {
        }

        private static readonly DNAController _singleton = new DNAController();

        public static DNAController GetSingleton()
        {
            return _singleton;
        }

        internal GenePool CreateChild(DNAPool father, DNAPool mother)
        {
            GenePool child = new GenePool();
            EnumBase dominant;
            EnumBase recessive;
            Gene gc;

            foreach (Gene f in father.GetGenes)
            {
                Type trait = f.Trait;

                Gene m = mother.GetGenes.FindByTrait(trait);

                EnumBase allele1 = GetAllele(f.Dominant, m.Dominant);
                EnumBase allele2 = GetAllele(f.Recessive, m.Recessive);

                if (allele1.Dominancy >= allele2.Dominancy)
                {
                    dominant = allele2;
                    recessive = allele1;
                }
                else
                {
                    dominant = allele1;
                    recessive = allele2;
                }

                gc = new Gene(trait, dominant, recessive);
                child.Add(gc);
            }

            return child;
        }

        private EnumBase GetAllele(EnumBase father, EnumBase mother)
        {
            decimal cutOff =  father.Probability;
            decimal total = father.Probability + mother.Probability;

            NextCheck(cutOff, total);

            while (!changed)
            { }

            changed = false;

            if (random)
                return father;
            else
                return mother;
        }

        private void NextCheck(decimal cutOff = 50, decimal total = 100)
        {
            RandomTimer checker = new RandomTimer(cutOff, total);
            checker.StatusChecked += Checker_StatusChecked;
            checker.Start();
        }

        private void Checker_StatusChecked(bool result)
        {
            changed = true;
            random = result;
        }
    }
}
