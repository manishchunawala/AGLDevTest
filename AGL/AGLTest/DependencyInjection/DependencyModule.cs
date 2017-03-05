using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Module = Autofac.Module;

namespace AGLTest.DependencyInjection
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}