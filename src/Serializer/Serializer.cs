using Autofac;
using Serializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    abstract class Serializer<TObject, TFormat> : ISerializer<TObject, TFormat> where TObject : IObject
    {
        protected readonly ISerializationProvider<TFormat> SerializationProvider;

        protected Serializer(ISerializationProvider<TFormat> serializationProvider)
        {
            if (serializationProvider == null)
                throw new ArgumentNullException(nameof(serializationProvider));

            SerializationProvider = serializationProvider;
        }

        TFormat ISerializer<TObject, TFormat>.Serialize(TObject @object)
        {
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));

            return Serialize(@object);
        }

        public abstract TFormat Serialize(TObject @object);

        TObject ISerializer<TObject, TFormat>.Deserialize(TFormat format)
        {
            if (format == null)
                throw new ArgumentNullException(nameof(format));

            return Deserialize(format);
        }

        public abstract TObject Deserialize(TFormat format);
    }

    public abstract class Serializer<TRootFormat>
    {
        private readonly IContainer _container;

        protected Serializer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            AutofacConfig.RegisterDependencies(builder);
            _container = builder.Build();
        }

        public virtual TRootFormat Serialize<TrootObject>(TrootObject rootObject) where TrootObject : IRootObject
        {
            return Serialize<TrootObject, TRootFormat>(rootObject);
        }

        protected TFormat Serialize<TrootObject, TFormat>(TrootObject rootObject) where TrootObject : IRootObject
        {
            if (rootObject == null)
                throw new ArgumentNullException(nameof(rootObject));

            using (var scope = _container.BeginLifetimeScope())
            {
                var serializationProvider = scope.Resolve<ISerializationProvider<TFormat>>();
                return serializationProvider.Serialize(rootObject);
            }
        }

        public virtual TrootObject Deserialize<TrootObject>(TRootFormat format) where TrootObject : IRootObject
        {
            return Deserialize<TrootObject, TRootFormat>(format);
        }

        protected TrootObject Deserialize<TrootObject, TFormat>(TFormat format) where TrootObject : IRootObject
        {
            if (format == null)
                throw new ArgumentNullException(nameof(format));

            using (var scope = _container.BeginLifetimeScope())
            {
                var serializationProvider = scope.Resolve<ISerializationProvider<TFormat>>();
                return serializationProvider.Deserialize<TrootObject>(format);
            }
        }
    }
}
