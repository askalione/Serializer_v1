using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serializer.Xml
{
    static class XAttributeExtensions
    {
        public static bool TryGetValue<T>(this XAttribute attribute, out T value)
        {
            if (attribute == null || string.IsNullOrEmpty(attribute.Value))
            {
                value = default(T);
                return false;
            }

            value = attribute.Value.Cast<T>(throwIfInvalidCast: false);
            return true;
        }
    }
}
