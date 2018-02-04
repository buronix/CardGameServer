using ServiceStack;
using CG.Models;
using CG.Interfaces.Adapters;
using System.Linq;
using CG.ServiceModels.Game;

namespace CG.Services.Games
{

    public class GameService : Service
    {
        public IGamesAdapter GamesAdapter;// = new GamesMockAdapter();

        public GameService() : base()
        {
            GamesAdapter = ResolveService<IGamesAdapter>();
        }

        public object Get(GetGames getGames)
        {

            // normally you would return a movie from the db
            return new GetGamesResponse { Games = GamesAdapter.GetCardGames().Cast<CardGame>().ToList() };
        }

        public object Get(GetGame getGame)
        {
            return new GetGameResponse
            {
                Game = GamesAdapter.GetCardGame(getGame as IGet) as CardGame
            };
        }
        /*
        /// POST /movies
        /// 
        /// returns HTTP Response => 
        ///     201 Created
        ///     Location: http://localhost/ServiceStack.MovieRest/movies/{newMovieId}
        ///     
        ///     {newMovie DTO in [xml|json|jsv|etc]}
        public object Post(CardGame game)
        {
            // insert a movie into your database... returns the new Id = 999
            int newId = 999;
            GameResponse newGame = new GameResponse { Game = new CardGame() { Id = newId } };

            return new HttpResult(newGame)
            {
                StatusCode = HttpStatusCode.Created,
                Headers = { { HttpHeaders.Location, this.Request.AbsoluteUri.WithTrailingSlash() + newId } }
            };
        }

        /// PUT /movies/{id}
        public object Put(CardGame game)
        {
            // save to db
            return null;
        }

        /// DELETE /movies/{Id}
        public object Delete(CardGame game)
        {
            // delete from db
            return null;
        }*/
    }
}