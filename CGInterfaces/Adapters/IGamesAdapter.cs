using CG.Interfaces.Models;
using ServiceStack;
using System.Collections.Generic;

namespace CG.Interfaces.Adapters
{
    public interface IGamesAdapter
    {
        IEnumerable<IGame> GetCardGames();
        IGame GetCardGame(IGet getGame);
    }
}
