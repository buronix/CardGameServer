using CG.Interfaces.Models;
using ServiceStack;
using System.Collections.Generic;

namespace CG.Interfaces.Adapters
{
    public interface IPlayersAdapter
    {
        IEnumerable<IPlayer> GetPlayers();
        IPlayer GetPlayer(IGet getPlayer);
    }
}
