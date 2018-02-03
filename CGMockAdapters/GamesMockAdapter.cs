using System.Collections.Generic;
using System.Linq;
using CGInterfaces.Adapters;
using CGInterfaces.Models;
using CGMockAdapters.Mock;
using CGModels;
using ServiceStack;
using CGServiceModels.Game;

namespace CGMockAdapters
{
    public class GamesMockAdapter : IGamesAdapter
    {
        public IGame GetCardGame(IGet getGame)
        {
            var reqGame = getGame as GetGame;
            GameMocks.Games.TryGetValue(reqGame.Id, out CardGame game);
            return game as IGame;
        }

        public IEnumerable<IGame> GetCardGames()
        {
            return GameMocks.Games.Values.Cast<IGame>();
        }
    }
}
