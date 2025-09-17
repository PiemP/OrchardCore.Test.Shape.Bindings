using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace Test.OrchardCore.Shape.Bindings
{
    public static class PermessiConst
    {
        public const string Main = "Test.OrchardCore.Shape.Bindings";
        public const string Commons = "Test.OrchardCore.Shape.Bindings.Commons";
        public const string PermitParkDisabil = "Test.OrchardCore.Shape.Bindings.PermitParkDisabil";
        public const string AccessToAct = "Test.OrchardCore.Shape.Bindings.AccessToAct";
        public const string AccessCivic = "Test.OrchardCore.Shape.Bindings.AccessCivic";
        public const string AccessToActEdil = "Test.OrchardCore.Shape.Bindings.AccessToActEdil";
        public const string EdilOccPublicSoilTmp = "Test.OrchardCore.Shape.Bindings.EdilOccPublicSoilTmp";
    }

    public sealed class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }

    [Feature(PermessiConst.PermitParkDisabil)]
    public sealed class PermitParkDisabilStartup : StartupBase
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDataMigration<PermitParkDisabilMigrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }

    [Feature(PermessiConst.AccessToAct)]
    public sealed class AccessToActStartup : StartupBase
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDataMigration<AccessToActMigrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }

    [Feature(PermessiConst.AccessToActEdil)]
    public sealed class AccessToActEdilStartup : StartupBase
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDataMigration<AccessToActEdilMigrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }

    [Feature(PermessiConst.AccessCivic)]
    public sealed class AccessCivicStartup : StartupBase
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDataMigration<AccessCivicMigrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}
