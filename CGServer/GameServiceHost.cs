using CGInterfaces.Adapters;
using CGMockAdapters;
using CGServer.Services;
using Funq;
using ServiceStack;
using ServiceStack.ProtoBuf;

namespace CGServer
{
    public class GameServiceHost : AppHostBase
    {
        public GameServiceHost()
                : base("ServiceStack Example", typeof(GameService).Assembly) { }

        public override void Configure(Container container)
        {
            container.RegisterAutoWiredAs<GamesMockAdapter, IGamesAdapter>();
            //container.Register<IGamesAdapter>(new GamesMockAdapter());
            container.Register<IPlayersAdapter>(new PlayersMockAdapter());

            SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), true)
            });
            Plugins.Add(new ProtoBufFormat());
        }
    }
}
