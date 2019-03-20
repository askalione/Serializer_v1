using Serializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    interface ISerializationProvider<TFormat>
    {
        TFormat Serialize<TObject>(TObject @object) where TObject : IObject;
        TObject Deserialize<TObject>(TFormat format) where TObject : IObject;
    }
}
