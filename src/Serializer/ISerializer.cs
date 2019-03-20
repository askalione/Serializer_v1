using Serializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    public interface ISerializer<TObject, TFormat> where TObject : IObject
    {
        TFormat Serialize(TObject @object);
        TObject Deserialize(TFormat format);
    }
}
