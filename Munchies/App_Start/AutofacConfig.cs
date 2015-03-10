using Autofac;
using Munchies.Data;
using Munchies.Data.Repositories;
using Munchies.Data.EF;

namespace Munchies
{
    public sealed class AutofacConfig
    {
        private static IContainer _container;

        public static void Configure()
        {
            var builder = new ContainerBuilder();
            
            builder.
                RegisterType<MunchiesDbContext>().
                AsSelf().
                //As<IDbContext>().
                WithParameter("nameOrConnectionString", "MunchiesDb").
                InstancePerRequest();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IAsyncReaderRepository<>)).InstancePerRequest();

            _container = builder.Build();
        }

        public static IContainer Container
        {
            get { return _container; }
        }
    }
}