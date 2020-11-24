namespace MyCommunityShop.Api.Bootstrap.Autofac.Modules
{
    using System.Reflection;
    using global::Autofac;
    using Module = global::Autofac.Module;

    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Domain.AssemblyHook)))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
