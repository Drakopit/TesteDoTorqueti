[assembly: WebActivator.PostApplicationStartMethod(typeof(TesteDoTorqueti2._0.WebAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace TesteDoTorqueti2._0.WebAPI.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using TesteDoTorqueti2._0.Repository;
    using TesteDoTorqueti2._0.Repository.Interfaces;
    using TesteDoTorqueti2._0.Service;
    using TesteDoTorqueti2._0.Service.Interfaces;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<RepositoryContext>(Lifestyle.Singleton);
            container.Register<IClientesRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
        }
    }
}