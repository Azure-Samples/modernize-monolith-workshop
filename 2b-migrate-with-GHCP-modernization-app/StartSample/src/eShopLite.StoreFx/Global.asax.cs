using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;

using eShopLite.StoreFx.Data;
using eShopLite.StoreFx.Services;

namespace eShopLite.StoreFx
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register other dependencies
            builder.RegisterType<StoreDbContext>().As<IStoreDbContext>();
            builder.RegisterType<StoreService>().As<IStoreService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
