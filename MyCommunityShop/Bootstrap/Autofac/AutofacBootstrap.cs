namespace MyCommunityShop.Api.Bootstrap.Autofac
{
    using global::Autofac;
    using MyCommunityShop.Api.Bootstrap.Autofac.Modules;

    public class AutofacBootstrap
    {
        public static void Run(ContainerBuilder builder)
        {
            builder.RegisterModule<ApiModule>();
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<DomainModule>();
        }
    }
}
