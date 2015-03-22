using Autofac;
using Munchies.Data.EF.Autofac;

namespace Munchies
{
    public sealed class AutofacConfig
    {
        private static IContainer _container;

        public static void Configure()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterModule<DataModule>();

            _container = builder.Build();
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}