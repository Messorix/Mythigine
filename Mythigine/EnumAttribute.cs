using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mythigine
{
    public abstract class EnumAttribute
    {
        public static TAttribute GetAttribute<TAttribute>(EnumBase @this) where TAttribute : Attribute
        {
            var field = @this.GetType().GetField(
                @this.ToString(),
                // BindingFlags is yet another flags enum!
                BindingFlags.Public | BindingFlags.Static
            );
            return field.GetCustomAttribute<TAttribute>();
        }
        public static TAttribute GetAttribute<TAttribute>(Type @this) where TAttribute : Attribute
        {
            return @this.GetCustomAttribute<TAttribute>();
        }
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(Type @this) where TAttribute : Attribute
        {
            return @this.GetCustomAttributes<TAttribute>();
        }
    }
}