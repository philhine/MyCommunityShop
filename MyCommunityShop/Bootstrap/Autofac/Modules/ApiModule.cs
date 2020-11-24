namespace MyCommunityShop.Api.Bootstrap.Autofac.Modules
{
    using System.Reflection;
    using global::Autofac;
    using Module = global::Autofac.Module;

    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Startup)))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
