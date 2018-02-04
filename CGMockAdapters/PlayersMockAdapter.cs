using CG.Interfaces.Adapters;
using CG.Interfaces.Models;
using CG.MockAdapters.Mock;
using CG.Models;
using CG.Server.Common.Exceptions;
using CG.ServiceModels.Player;
using ServiceStack;
using System.Collections.Generic;
using System.Linq;

namespace CG.MockAdapters
{
    public class PlayersMockAdapter : IPlayersAdapter
    {
        public IPlayer GetPlayer(IGet getPlayer)
        {
            var reqPlayer = getPlayer as GetPlayer;
            if (reqPlayer.Id <= 0)
            {
                throw new FieldRequiredException("Invalid Request", "Id");
            }
            PlayerMocks.Players.TryGetValue(reqPlayer.Id, out Player player);
            return player as IPlayer;
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            return PlayerMocks.Players.Values.Cast<IPlayer>();
        }
    }
}
