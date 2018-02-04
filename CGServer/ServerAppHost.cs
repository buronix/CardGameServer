using CG.Interfaces.Adapters;
using CG.MockAdapters;
using CG.Server.Common.Exceptions;
using Funq;
using ServiceStack;
using ServiceStack.Host;
using ServiceStack.ProtoBuf;
using System.Linq;
using System.Reflection;

namespace CG.Server
{
    public class ServerAppHost : AppHostBase
    {
        public ServerAppHost(Assembly[] services)
                : base("ServiceStack Example", services) { }

        public override void Configure(Container container)
        {
            container.RegisterAutoWiredAs<GamesMockAdapter, IGamesAdapter>();
            container.Register<IPlayersAdapter>(new PlayersMockAdapter());
            SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), true),
                MapExceptionToStatusCode = ExceptionStatus.MapExceptionToStatusCode
            });
            Plugins.Add(new ProtoBufFormat());
            Plugins.Add(new RequestLogsFeature());
        }

        protected override ServiceController CreateServiceController(params Assembly[] assembliesWithServices)
        {
            return new ServiceController(this, () => 
                assembliesWithServices.ToList()
                .SelectMany(x => x.GetTypes())
            );
        }
    }
}
