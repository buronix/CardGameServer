using CGInterfaces.Models;
using ServiceStack;
using System.Collections.Generic;

namespace CGInterfaces.Adapters
{
    public interface IGamesAdapter
    {
        IEnumerable<IGame> GetCardGames();
        IGame GetCardGame(IGet getGame);
    }
}
