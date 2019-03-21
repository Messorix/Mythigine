using System;
using System.Collections.Generic;
using Mythigine;
using System.ComponentModel;
using System.Diagnostics;
using static FlowersOutput.Enums;

namespace FlowersOutput
{
    class Program
    {
        private static List<Gene> dna;
        private static List<Flower> _flowers;
        private static DNAController dnacontroller = DNAController.GetSingleton();

        static void Main(string[] args)
        {
            _flowers = new List<Flower>();
            Gene _g;
            Flower _f;
            
            dna = new List<Gene>();
            _g = new Gene(typeof(FlowerColor), FlowerColor.Purple, FlowerColor.Purple);
            dna.Add(_g);
            _g = new Gene(typeof(FlowerPosition), FlowerPosition.Axil, FlowerPosition.Axil);
            dna.Add(_g);
            _g = new Gene(typeof(StemLength), StemLength.Long, StemLength.Long);
            dna.Add(_g);
            _g = new Gene(typeof(SeedShape), SeedShape.Round, SeedShape.Round);
            dna.Add(_g);
            _g = new Gene(typeof(PodShape), PodShape.Inflated, PodShape.Inflated);
            dna.Add(_g);
            _g = new Gene(typeof(SeedColor), SeedColor.Green, SeedColor.Green);
            dna.Add(_g);
            _g = new Gene(typeof(PodColor), PodColor.Green, PodColor.Green);
            dna.Add(_g);
            _f = new Flower(1, dna);
            _flowers.Add(_f);

            dna = new List<Gene>();
            _g = new Gene(typeof(FlowerColor), FlowerColor.White, FlowerColor.White);
            dna.Add(_g);
            _g = new Gene(typeof(FlowerPosition), FlowerPosition.Terminal, FlowerPosition.Terminal);
            dna.Add(_g);
            _g = new Gene(typeof(StemLength), StemLength.Short, StemLength.Short);
            dna.Add(_g);
            _g = new Gene(typeof(SeedShape), SeedShape.Wrinkled, SeedShape.Wrinkled);
            dna.Add(_g);
            _g = new Gene(typeof(PodShape), PodShape.Constricted, PodShape.Constricted);
            dna.Add(_g);
            _g = new Gene(typeof(SeedColor), SeedColor.Yellow, SeedColor.Yellow);
            dna.Add(_g);
            _g = new Gene(typeof(PodColor), PodColor.Yellow, PodColor.Yellow);
            dna.Add(_g);
            _f = new Flower(2, dna);
            _flowers.Add(_f);

            _flowers.Add(new Flower(3, dnacontroller.CreateChild(_flowers[0], _flowers[1])));
            _flowers[2].SetParents(_flowers[0], _flowers[1]);

            #region Straight info
            /*
            foreach (Flower f in _flowers)
            {
                Console.WriteLine("Flower {0}\n", f.ID);

                foreach (Gene g in f.DNA.Genes)
                {
                    switch((Trait)Enum.Parse(typeof(Trait), g.Trait))
                    {
                        case Trait.FlowerColor:
                            Console.WriteLine("Trait: {0}\n\tDominant: {1}\n\tRecessive: {2}\n",
                            ((Trait)Enum.Parse(typeof(Trait), g.Trait)).GetAttribute<DescriptionAttribute>().Description,
                            ((FlowerColor)Enum.Parse(typeof(FlowerColor), g.Dominant)).GetAttribute<DescriptionAttribute>().Description,
                            ((FlowerColor)Enum.Parse(typeof(FlowerColor), g.Recessive)).GetAttribute<DescriptionAttribute>().Description
                            );
                            break;
                        case Trait.SeedColor:
                        case Trait.PodColor:
                            Console.WriteLine("Trait: {0}\n\tDominant: {1}\n\tRecessive: {2}\n",
                            ((Trait)Enum.Parse(typeof(Trait), g.Trait)).GetAttribute<DescriptionAttribute>().Description,
                            ((PodAndSeedColor)Enum.Parse(typeof(PodAndSeedColor), g.Dominant)).GetAttribute<DescriptionAttribute>().Description,
                            ((PodAndSeedColor)Enum.Parse(typeof(PodAndSeedColor), g.Recessive)).GetAttribute<DescriptionAttribute>().Description
                            );
                            break;
                        case Trait.SeedShape:
                            Console.WriteLine("Trait: {0}\n\tDominant: {1}\n\tRecessive: {2}\n",
                            ((Trait)Enum.Parse(typeof(Trait), g.Trait)).GetAttribute<DescriptionAttribute>().Description,
                            ((SeedShape)Enum.Parse(typeof(SeedShape), g.Dominant)).GetAttribute<DescriptionAttribute>().Description,
                            ((SeedShape)Enum.Parse(typeof(SeedShape), g.Recessive)).GetAttribute<DescriptionAttribute>().Description
                            );
                            break;
                        case Trait.PodShape:
                            Console.WriteLine("Trait: {0}\n\tDominant: {1}\n\tRecessive: {2}\n",
                            ((Trait)Enum.Parse(typeof(Trait), g.Trait)).GetAttribute<DescriptionAttribute>().Description,
                            ((PodShape)Enum.Parse(typeof(PodShape), g.Dominant)).GetAttribute<DescriptionAttribute>().Description,
                            ((PodShape)Enum.Parse(typeof(PodShape), g.Recessive)).GetAttribute<DescriptionAttribute>().Description
                            );
                            break;
                        case Trait.StemLength:
                            Console.WriteLine("Trait: {0}\n\tDominant: {1}\n\tRecessive: {2}\n",
                            ((Trait)Enum.Parse(typeof(Trait), g.Trait)).GetAttribute<DescriptionAttribute>().Description,
                            ((Length)Enum.Parse(typeof(Length), g.Dominant)).GetAttribute<DescriptionAttribute>().Description,
                            ((Length)Enum.Parse(typeof(Length), g.Recessive)).GetAttribute<DescriptionAttribute>().Description
                            );
                            break;
                        case Trait.FlowerPosition:
                            Console.WriteLine("Trait: {0}\n\tDominant: {1}\n\tRecessive: {2}\n",
                            ((Trait)Enum.Parse(typeof(Trait), g.Trait)).GetAttribute<DescriptionAttribute>().Description,
                            ((Position)Enum.Parse(typeof(Position), g.Dominant)).GetAttribute<DescriptionAttribute>().Description,
                            ((Position)Enum.Parse(typeof(Position), g.Recessive)).GetAttribute<DescriptionAttribute>().Description
                            );
                            break;
                    }
                }
            }*/
            #endregion
            #region Table info
            Console.WriteLine(String.Format("\n|{0,5}\t\t|{1,5}\t|{2,5}\t|{3,5}\n", "Trait", "Flower 1", "Flower 2", "Flower Child"));

            List<Gene> father = _flowers[0].Genes;
            List<Gene> mother = _flowers[1].Genes;
            List<Gene> child = _flowers[2].Genes;

            for (int x = 0; x < Enum.GetValues(typeof(Trait)).Length; x++)
            {
                Trait t = ((Trait)Enum.GetValues(typeof(Trait)).GetValue(x));

                if (t != Trait.FlowerPosition)
                {
                    if (father[x].Dominant.ToString().Length <= 6)
                        Console.WriteLine(String.Format("|{0,5}\t|{1,5}\t\t|{2,5}\t\t|{3,5}", Enums.GetAttribute<DescriptionAttribute>(t).Description, _flowers[0].Genes[x].Dominant, _flowers[1].Genes[x].Dominant, _flowers[2].Genes[x].Dominant));
                    else
                        Console.WriteLine(String.Format("|{0,5}\t|{1,5}\t|{2,5}\t\t|{3,5}", Enums.GetAttribute<DescriptionAttribute>(t).Description, _flowers[0].Genes[x].Dominant, _flowers[1].Genes[x].Dominant, _flowers[2].Genes[x].Dominant));

                    if (father[x].Dominant.ToString().Length <= 6)
                        Console.WriteLine(String.Format("|{0,5}\t|{1,5}\t\t|{2,5}\t\t|{3,5}", Enums.GetAttribute<DescriptionAttribute>(t).Description, _flowers[0].Genes[x].Recessive, _flowers[1].Genes[x].Recessive, _flowers[2].Genes[x].Recessive));
                    else
                        Console.WriteLine(String.Format("|{0,5}\t|{1,5}\t|{2,5}\t\t|{3,5}", Enums.GetAttribute<DescriptionAttribute>(t).Description, _flowers[0].Genes[x].Recessive, _flowers[1].Genes[x].Recessive, _flowers[2].Genes[x].Recessive));
                }
                else
                {
                    if (father[x].Dominant.ToString().Length <= 6)
                        Console.WriteLine(String.Format("|{0,5}|{1,5}\t\t|{2,5}\t\t|{3,5}", Enums.GetAttribute<DescriptionAttribute>(t).Description, _flowers[0].Genes[x].Dominant, _flowers[1].Genes[x].Dominant, _flowers[2].Genes[x].Dominant));
                    else
                        Console.WriteLine(String.Format("|{0,5}|{1,5}\t|{2,5}\t\t|{3,5}", Enums.GetAttribute<DescriptionAttribute>(t).Description, _flowers[0].Genes[x].Dominant, _flowers[1].Genes[x].Dominant, _flowers[2].Genes[x].Dominant));

                    if (father[x].Dominant.ToString().Length <= 6)
                        Console.WriteLine(String.Format("|{0,5}|{1,5}\t\t|{2,5}\t\t|{3,5}", Enums.GetAttribute<DescriptionAttribute>(t).Description, _flowers[0].Genes[x].Recessive, _flowers[1].Genes[x].Recessive, _flowers[2].Genes[x].Recessive));
                    else
                        Console.WriteLine(String.Format("|{0,5}|{1,5}\t|{2,5}\t\t|{3,5}", Enums.GetAttribute<DescriptionAttribute>(t).Description, _flowers[0].Genes[x].Recessive, _flowers[1].Genes[x].Recessive, _flowers[2].Genes[x].Recessive));
                }
            }
            #endregion
            
            Console.WriteLine("Press enter key to continue . . .");
            Console.ReadLine();
        }
    }
}
