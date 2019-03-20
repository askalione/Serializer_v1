using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Serializer.Objects;

namespace Serializer
{
    class AutofacSerializerFactory : ISerializerFactory
    {
        private readonly ILifetimeScope _container;

        public AutofacSerializerFactory(ILifetimeScope container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        public ISerializer<TObject, TFormat> CreateSerializer<TObject, TFormat>() where TObject : IObject
        {
            var serializerType = typeof(ISerializer<,>).MakeGenericType(typeof(TObject), typeof(TFormat));
            if (_container.TryResolve(serializerType, out object serializerInstance))
            {
                if (serializerInstance is ISerializer<TObject, TFormat> serializer)
                    return serializer;
            }

            throw new InvalidOperationException($"Serializer for object {typeof(TObject).Name} and format {typeof(TFormat).Name} not found.");
        }
    }
}
