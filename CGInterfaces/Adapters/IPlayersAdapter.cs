using CGInterfaces.Models;
using ServiceStack;
using System.Collections.Generic;

namespace CGInterfaces.Adapters
{
    public interface IPlayersAdapter
    {
        IEnumerable<IPlayer> GetPlayers();
        IPlayer GetPlayer(IGet getPlayer);
    }
}
