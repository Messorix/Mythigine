using Mythigine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static AnimalsOutput.Enums;

namespace AnimalsOutput
{
    class Program
    {
        private static GenePool dna;
        private static List<Animal> animals;
        private static DNAController dnacontroller = DNAController.GetSingleton();

        static void Main(string[] args)
        {
            animals = new List<Animal>();
            Gene _g;
            Animal _a;
            Races _r;

            _r = Races.Human;
            dna = new GenePool();

            switch (_r)
            {
                case Races.Human:
                    _g = new Gene(typeof(HairColor), HairColor.Blonde, HairColor.Blonde);
                    dna.Add(_g);
                    _g = new Gene(typeof(SkinColor), SkinColor.Caucasian, SkinColor.Caucasian);
                    dna.Add(_g);
                    _g = new Gene(typeof(EyeColor), EyeColor.Green, EyeColor.Green);
                    dna.Add(_g);
                    break;
                case Races.Dog:
                    /*_g = new Gene(typeof(Enums.Dog.HairColor), Enums.Dog.HairColor.Blonde.ToString(), Enums.Dog.HairColor.Blonde.ToString());
                    dna.Add(_g);
                    _g = new Gene(typeof(Enums.Dog.SkinColor), Enums.Dog.SkinColor.Axil.ToString(), Enums.Dog.SkinColor.Axil.ToString());
                    dna.Add(_g);
                    _g = new Gene(typeof(Enums.Dog.EyeColor), Enums.Dog.EyeColor.Axil.ToString(), Enums.Dog.EyeColor.Axil.ToString());
                    dna.Add(_g);*/
                    break;
            }

            _a = new Animal(1, _r, dna);
            animals.Add(_a);

            dna = new GenePool();

            switch (_r)
            {
                case Races.Human:
                    _g = new Gene(typeof(HairColor), HairColor.Black, HairColor.Black);
                    dna.Add(_g);
                    _g = new Gene(typeof(SkinColor), SkinColor.Asian, SkinColor.Asian);
                    dna.Add(_g);
                    _g = new Gene(typeof(EyeColor), EyeColor.Brown, EyeColor.Brown);
                    dna.Add(_g);
                    break;
                case Races.Dog:
                    /*_g = new Gene(typeof(Enums.Dog.HairColor), Enums.Dog.HairColor.Brunette, Enums.Dog.HairColor.Brunette);
                    dna.Add(_g);
                    _g = new Gene(typeof(Enums.Dog.SkinColor), Enums.Dog.SkinColor.Terminal.ToString(), Enums.Dog.SkinColor.Terminal.ToString());
                    dna.Add(_g);
                    _g = new Gene(typeof(Enums.Dog.EyeColor), Enums.Dog.EyeColor.Terminal.ToString(), Enums.Dog.EyeColor.Terminal.ToString());
                    dna.Add(_g);*/
                    break;
            }

            _a = new Animal(2, _r, dna);
            animals.Add(_a);

            animals.Add(new Animal(3, animals[0].Race, animals[0], animals[1]));


            #region Table info
            GenePool father = animals[0].GetGenes;
            GenePool mother = animals[1].GetGenes;
            GenePool child = animals[2].GetGenes;

            Console.WriteLine(String.Format("\n|{0,5}\t\t|{1,5}\t|{2,5}\t|{3,5}\n", "Trait", animals[0].Race.ToString() + " 1", animals[1].Race.ToString() + " 2", animals[2].Race.ToString() + " Child"));
            
            foreach (Type trait in Trait.AllTraits)
            {
                bool raceFound = false;
                foreach (RaceAttribute r in Enums.GetAttributes<RaceAttribute>(trait))
                {
                    if (r.Race.Equals(animals[0].Race))
                    {
                        raceFound = true;
                        break;
                    }
                }

                if (raceFound)
                {
                    Gene gf = father.FindByTrait(trait);
                    Gene gm = mother.FindByTrait(trait);
                    Gene gc = child.FindByTrait(trait);

                    string traitAsString = Enums.GetAttribute<DescriptionAttribute>(trait).Description;

                    if (gf.Dominant.ToString().Length <= 6)
                        Console.WriteLine(String.Format("|{0,5}\t|{1,5}\t\t|{2,5}\t\t|{3,5}", traitAsString, gf.Dominant.ToString(), gm.Dominant.ToString(), gc.Dominant.ToString()));
                    else
                        Console.WriteLine(String.Format("|{0,5}\t|{1,5}\t|{2,5}\t\t|{3,5}", traitAsString, gf.Dominant.ToString(), gm.Dominant.ToString(), gc.Dominant.ToString()));

                    if (gf.Dominant.ToString().Length <= 6)
                        Console.WriteLine(String.Format("|{0,5}\t|{1,5}\t\t|{2,5}\t\t|{3,5}", traitAsString, gf.Recessive.ToString(), gm.Recessive.ToString(), gc.Recessive.ToString()));
                    else
                        Console.WriteLine(String.Format("|{0,5}\t|{1,5}\t|{2,5}\t\t|{3,5}", traitAsString, gf.Recessive.ToString(), gm.Recessive.ToString(), gc.Recessive.ToString()));
                }
            }
            #endregion
            
            Console.WriteLine("Press enter key to continue . . .");
            Console.ReadLine();
        }
    }
}
