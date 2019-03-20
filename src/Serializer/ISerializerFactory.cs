using Serializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    interface ISerializerFactory
    {
        ISerializer<TObject, TFormat> CreateSerializer<TObject, TFormat>() where TObject : IObject;
    }
}
