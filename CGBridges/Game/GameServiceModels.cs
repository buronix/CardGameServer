using CGModels;
using ServiceStack;
using System.Net;

namespace CGServiceModels.Game
{
    [Route("/games", WebRequestMethods.Http.Get)]
    public class GetGames : IGet, IReturn<GamesResponse> { }

    [Route("/games/{Id}", WebRequestMethods.Http.Get)]
    public class GetGame : IGet, IReturn<GameResponse>
    {
        public int Id { get; set; }
    }
}
