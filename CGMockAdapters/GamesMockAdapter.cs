using System.Collections.Generic;
using System.Linq;
using CG.Interfaces.Adapters;
using CG.Interfaces.Models;
using CG.MockAdapters.Mock;
using CG.Models;
using ServiceStack;
using CG.ServiceModels.Game;
using CG.Server.Common.Exceptions;

namespace CG.MockAdapters
{
    public class GamesMockAdapter : IGamesAdapter
    {
        public IGame GetCardGame(IGet getGame)
        {
            var reqGame = getGame as GetGame;
            if(reqGame.Id <= 0)
            {
                throw new FieldRequiredException("Invalid Request", "Id");
            }
            GameMocks.Games.TryGetValue(reqGame.Id, out CardGame game);
            return game as IGame;
        }

        public IEnumerable<IGame> GetCardGames()
        {
            return GameMocks.Games.Values.Cast<IGame>();
        }
    }
}
