using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    static class StringExtensions
    {
        public static object Cast(this string @string, Type type, bool throwIfInvalidCast = false)
        {
            try
            {
                if (type == typeof(string))
                    return @string;

                if (string.IsNullOrWhiteSpace(@string))
                    return null;

                type = Nullable.GetUnderlyingType(type) ?? type;

                if (type.IsEnum)
                    return Enum.Parse(type, @string);

                var value = System.Convert.ChangeType(@string, type);
                return value;
            }
            catch (Exception ex)
            {
                if (throwIfInvalidCast)
                    throw new InvalidCastException($"Error with convert string \"{@string}\" to type \"{type.Name}\"", ex);

                return null;
            }
        }

        public static T Cast<T>(this string @string, bool throwIfInvalidCast = false)
        {
            return (T)Cast(@string, typeof(T), throwIfInvalidCast);
        }
    }
}
