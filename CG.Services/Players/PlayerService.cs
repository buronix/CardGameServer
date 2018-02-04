using CG.Interfaces.Adapters;
using CG.Models;
using CG.ServiceModels.Player;
using ServiceStack;
using System.Linq;

namespace CG.Services.Players
{
    public class PlayerService : Service
    {
        public IPlayersAdapter PlayersAdapter;// = new PlayersMockAdapter();

        public PlayerService() : base()
        {
            PlayersAdapter = ResolveService<IPlayersAdapter>();
        }

        public object Get(GetPlayers getPlayers)
        {
            return new GetPlayersResponse {
                GamePlayers = PlayersAdapter.GetPlayers().Cast<Player>().ToList()
            };
        }

        public object Get(GetPlayer getPlayer)
        {
            return new GetPlayerResponse
            {
                GamePlayer = PlayersAdapter.GetPlayer(getPlayer as IGet) as Player
            };
        }
    }
}
