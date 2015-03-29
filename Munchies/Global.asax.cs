using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Web;

namespace Munchies
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        private static IContainerProvider _containerProvider;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfig.Configure();
            _containerProvider = new ContainerProvider(AutofacConfig.Container);
        }

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
    }
}