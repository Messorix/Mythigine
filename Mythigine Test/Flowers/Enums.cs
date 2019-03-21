using Mythigine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlowersOutput
{
    public class Enums : EnumAttribute
    {
        public enum Trait
        {
            [Description("Flower Color")]
            FlowerColor,
            [Description("Flower Position")]
            FlowerPosition,
            [Description("Stem Length")]
            StemLength,
            [Description("Seed Shape")]
            SeedShape,
            [Description("Pod Shape")]
            PodShape,
            [Description("Seed Color")]
            SeedColor,
            [Description("Pod Color")]
            PodColor
        }

        public class FlowerColor : EnumBase
        {
            public static readonly FlowerColor Purple = new FlowerColor(1, "Purple", 50, 0);
            public static readonly FlowerColor White = new FlowerColor(2, "White", 50, 0);

            public delegate void GetValue(FlowerColor value);
            public event GetValue GetByValue;

            public FlowerColor(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public static FlowerColor GetByKey(int key)
            {
                return (FlowerColor)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((FlowerColor)GetBaseByValue(value));
            }
        }
        public class FlowerPosition : EnumBase
        {
            public static readonly FlowerPosition Axil = new FlowerPosition(1, "Axil", 50, 0);
            public static readonly FlowerPosition Terminal = new FlowerPosition(2, "Terminal", 50, 0);

            public delegate void GetValue(FlowerPosition value);
            public event GetValue GetByValue;

            public FlowerPosition(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public static FlowerPosition GetByKey(int key)
            {
                return (FlowerPosition)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((FlowerPosition)GetBaseByValue(value));
            }
        }
        public class StemLength : EnumBase
        {
            public static readonly StemLength Long = new StemLength(1, "Long", 50, 0);
            public static readonly StemLength Short = new StemLength(2, "Short", 50, 0);

            public delegate void GetValue(StemLength value);
            public event GetValue GetByValue;

            public StemLength(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public static StemLength GetByKey(int key)
            {
                return (StemLength)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((StemLength)GetBaseByValue(value));
            }
        }
        public class SeedShape : EnumBase
        {
            public static readonly SeedShape Round = new SeedShape(1, "Round", 50, 0);
            public static readonly SeedShape Wrinkled = new SeedShape(2, "Wrinkled", 50, 0);

            public delegate void GetValue(SeedShape value);
            public event GetValue GetByValue;

            public SeedShape(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public static SeedShape GetByKey(int key)
            {
                return (SeedShape)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((SeedShape)GetBaseByValue(value));
            }
        }
        public class PodShape : EnumBase
        {
            public static readonly PodShape Inflated = new PodShape(1, "Inflated", 50, 0);
            public static readonly PodShape Constricted = new PodShape(2, "Constricted", 50, 0);

            public delegate void GetValue(PodShape value);
            public event GetValue GetByValue;

            public PodShape(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public static PodShape GetByKey(int key)
            {
                return (PodShape)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((PodShape)GetBaseByValue(value));
            }
        }
        public class SeedColor : EnumBase
        {
            public static readonly SeedColor Yellow = new SeedColor(1, "Yellow", 50, 0);
            public static readonly SeedColor Green = new SeedColor(2, "Green", 50, 0);

            public delegate void GetValue(SeedColor value);
            public event GetValue GetByValue;

            public SeedColor(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public static SeedColor GetByKey(int key)
            {
                return (SeedColor)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((SeedColor)GetBaseByValue(value));
            }
        }
        public class PodColor : EnumBase
        {
            public static readonly PodColor Yellow = new PodColor(1, "Yellow", 50, 0);
            public static readonly PodColor Green = new PodColor(2, "Green", 50, 0);

            public delegate void GetValue(PodColor value);
            public event GetValue GetByValue;

            public PodColor(int key, string value, int prob, int dom) : base(key, value, prob, dom)
            {
            }

            public static PodColor GetByKey(int key)
            {
                return (PodColor)GetBaseByKey(key);
            }

            public void GetWithValue(string value)
            {
                GetByValue?.Invoke((PodColor)GetBaseByValue(value));
            }
        }
    }
}