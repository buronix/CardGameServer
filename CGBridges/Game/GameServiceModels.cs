using CG.Models;
using ServiceStack;
using System.Net;

namespace CG.ServiceModels.Game
{
    [Route("/games", WebRequestMethods.Http.Get)]
    public class GetGames : IGet, IReturn<GetGamesResponse> { }

    [Route("/games/{Id}", WebRequestMethods.Http.Get)]
    public class GetGame : IGet, IReturn<GetGameResponse>
    {
        public int Id { get; set; }
    }
}
