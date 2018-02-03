using CGModels;
using System;
using System.Collections.Generic;

namespace CGMockAdapters.Mock
{
    public static class GameMocks
    {
        public static Dictionary<int, CardGame> Games = new Dictionary<int, CardGame>
        {
            {
                1,
                    new CardGame() {
                    Id = 1,
                    Players = new List<Player>(),
                    CreatedDate = new DateTime(),
                    Title = "Default Game 1"
                }
            },
            {
                2,
                new CardGame() {
                    Id = 2,
                    Players = new List<Player>(),
                    CreatedDate = new DateTime(),
                    Title = "Default Game 2"
                }
            },
            {
                3,
                new CardGame() {
                    Id = 3,
                    Players = new List<Player>(),
                    CreatedDate = new DateTime(),
                    Title = "Default Game 3"
                }
            },
            {
                4,
                new CardGame() {
                    Id = 4,
                    Players = new List<Player>(),
                    CreatedDate = new DateTime(),
                    Title = "Default Game 4"
                }
            },
            {
                5,
                new CardGame() {
                    Id = 5,
                    Players = new List<Player>(),
                    CreatedDate = new DateTime(),
                    Title = "Default Game 5"
                }
            }
        };
    }
}
