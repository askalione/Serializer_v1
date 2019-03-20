using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    static class AutofacConfig
    {
        public static void RegisterDependencies(ContainerBuilder builder)
        {
            var assembly = typeof(AutofacConfig).Assembly;

            builder
                .RegisterType<AutofacSerializerFactory>()
                .As<ISerializerFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(SerializationProvider<>))
                .As(typeof(ISerializationProvider<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ISerializer<,>))
                .InstancePerLifetimeScope();
        }
    }
}
