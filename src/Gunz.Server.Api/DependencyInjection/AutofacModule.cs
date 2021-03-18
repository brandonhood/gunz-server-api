using Autofac;
using Gunz.Server.Business.Characters;
using Gunz.Server.Common.Helpers;
using Gunz.Server.Repositories.Characters;
using System.Diagnostics.CodeAnalysis;

namespace Gunz.Server.Api.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    internal sealed class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var types = new[]
            {
                typeof(AutofacModule),
                typeof(ICharacterManager),
                typeof(ICharacterRepository),
                typeof(IJsonHelper)
            };

            foreach (var type in types)
            {
                builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetAssembly(type))
                    .AsImplementedInterfaces();
            }
        }
    }
}
