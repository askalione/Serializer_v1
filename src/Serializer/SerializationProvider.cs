using Serializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    class SerializationProvider<TFormat> : ISerializationProvider<TFormat>
    {
        private readonly ISerializerFactory _serializerFactory;

        public SerializationProvider(ISerializerFactory serializerFactory)
        {
            if (serializerFactory == null)
                throw new ArgumentNullException(nameof(serializerFactory));

            _serializerFactory = serializerFactory;
        }

        public TFormat Serialize<TObject>(TObject @object) where TObject : IObject
        {
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));

            var serializer = GetSerializer<TObject>();
            return serializer.Serialize(@object);
        }

        public TObject Deserialize<TObject>(TFormat format) where TObject : IObject
        {
            if (format == null)
                throw new ArgumentNullException(nameof(format));

            var serializer = GetSerializer<TObject>();
            return serializer.Deserialize(format);
        }

        private ISerializer<TObject, TFormat> GetSerializer<TObject>() where TObject : IObject
        {
            return _serializerFactory.CreateSerializer<TObject, TFormat>();
        }
    }
}
