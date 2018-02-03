using CGInterfaces.Adapters;
using CGInterfaces.Models;
using CGMockAdapters.Mock;
using CGModels;
using CGServiceModels;
using CGServiceModels.Player;
using ServiceStack;
using System.Collections.Generic;
using System.Linq;

namespace CGMockAdapters
{
    public class PlayersMockAdapter : IPlayersAdapter
    {
        public IPlayer GetPlayer(IGet getPlayer)
        {
            var reqPlayer = getPlayer as GetPlayer;
            PlayerMocks.Players.TryGetValue(reqPlayer.Id, out Player player);
            return player as IPlayer;
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            return PlayerMocks.Players.Values.Cast<IPlayer>();
        }
    }
}
