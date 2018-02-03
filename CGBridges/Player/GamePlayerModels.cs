using CGModels;
using ServiceStack;
using System.Net;

namespace CGServiceModels.Player
{
    [Route("/players", WebRequestMethods.Http.Get)]
    public class GetPlayers : IGet, IReturn<PlayersResponse> { }

    [Route("/players/{Id}", WebRequestMethods.Http.Get)]
    public class GetPlayer : IGet, IReturn<PlayerResponse>
    {
        public int Id { get; set; }
    }
}
