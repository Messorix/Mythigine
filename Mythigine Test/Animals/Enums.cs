using Mythigine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace AnimalsOutput
{
    public class Enums : EnumAttribute
    {
        [Description("Trait")]
        [Race(Races.Human)]
        [Race(Races.Dog)]
        public class Trait : EnumBase, IEnumerable
        {
            public static List<Type> AllTraits { get; } = new List<Type>();

            public static readonly Trait HairColor = new Trait(1, typeof(HairColor));
            public static readonly Trait SkinColor = new Trait(2, typeof(SkinColor));
            public static readonly Trait EyeColor = new Trait(3, typeof(EyeColor));

            public delegate void GetValue(Trait value);
            public event GetValue GetByValue;

            public Trait(int key, Type value) : base(key, value)
            {
                AllTraits.Add(value);
            }

            public Trait GetByKey(int key)
            {
                return (Trait)GetBaseByKey(key);
            }

            public void GetWithValue(Type value)
            {
                GetByValue?.Invoke((Trait)GetBaseByValue(value));
            }

            public override string ToString()
            {
                return GetAttribute<DescriptionAttribute>(this).Description;
            }
        }
        [Description("Hair Color")]
        [Race(Races.Human)]
        [Race(Races.Dog)]
        public class HairColor : EnumBase
        {
            public static readonly HairColor Blonde = new HairColor(1, "Blonde", 50, 2);
            public static readonly HairColor Brunette = new HairColor(2, "Brunette", 40, 1);
            public static readonly HairColor Black = new HairColor(3, "Black", 10, 0);

            public delegate void GetValue(HairColor value);
            public event GetValue GetByValue;

            public HairColor(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public  HairColor GetByKey(int key)
            {
                return (HairColor)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((HairColor)GetBaseByValue(value));
            }
        }
        [Description("Skin Color")]
        [Race(Races.Human)]
        [Race(Races.Dog)]
        public class SkinColor : EnumBase
        {
            public static readonly SkinColor Caucasian = new SkinColor(1, "Caucasian", 34, 2);
            public static readonly SkinColor Asian = new SkinColor(2, "Asian", 33, 1);
            public static readonly SkinColor African = new SkinColor(3, "African", 33, 0);

            public delegate void GetValue(SkinColor value);
            public event GetValue GetByValue;

            public SkinColor(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public  SkinColor GetByKey(int key)
            {
                return (SkinColor)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((SkinColor)GetBaseByValue(value));
            }
        }
        [Description("Eye Color")]
        [Race(Races.Dog)]
        public class EyeColor : EnumBase
        {
            public static readonly EyeColor Brown = new EyeColor(1, "Brown", 40, 0);
            public static readonly EyeColor Green = new EyeColor(2, "Green", 30, 1);
            public static readonly EyeColor Blue = new EyeColor(3, "Blue", 30, 2);

            public delegate void GetValue(EyeColor value);
            public event GetValue GetByValue;

            public EyeColor(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public  EyeColor GetByKey(int key)
            {
                return (EyeColor)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((EyeColor)GetBaseByValue(value));
            }
        }
    }

    public enum Races
    {
        [Description("Human")]
        Human,
        [Description("Dog")]
        Dog
    }
}