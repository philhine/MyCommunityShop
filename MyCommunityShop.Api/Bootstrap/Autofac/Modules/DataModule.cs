namespace MyCommunityShop.Api.Bootstrap.Autofac.Modules
{
    using System.Reflection;
    using global::Autofac;
    using Module = global::Autofac.Module;

    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Data.Repository.AssemblyHook)))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Data.Entities.AssemblyHook)))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
