using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serializer.Xml
{
    static class XElementExtentions
    {
        public static bool TryGetValue<T>(this XElement element, out T value)
        {
            if (element == null || string.IsNullOrEmpty(element.Value))
            {
                value = default(T);
                return false;
            }

            value = element.Value.Cast<T>(throwIfInvalidCast: false);
            return true;
        }

    }
}
