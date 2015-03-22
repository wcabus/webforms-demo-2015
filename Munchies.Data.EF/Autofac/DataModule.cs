using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Munchies.Data.Queries;

using Autofac;

namespace Munchies.Data.EF.Autofac
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.
               RegisterType<MunchiesDbContext>().
               AsSelf().
               WithParameter("nameOrConnectionString", "MunchiesDb").
               InstancePerRequest();

            // Query classes
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("query", StringComparison.OrdinalIgnoreCase) && t.IsAssignableTo<IQuery>())
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}
