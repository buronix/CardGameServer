using CG.Models;
using ServiceStack;
using System.Net;

namespace CG.ServiceModels.Player
{
    [Route("/players", WebRequestMethods.Http.Get)]
    public class GetPlayers : IGet, IReturn<GetPlayersResponse> { }

    [Route("/players/{Id}", WebRequestMethods.Http.Get)]
    public class GetPlayer : IGet, IReturn<GetPlayerResponse>
    {
        public int Id { get; set; }
    }
}
