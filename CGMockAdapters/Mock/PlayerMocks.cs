using CG.Models;
using System;
using System.Collections.Generic;

namespace CG.MockAdapters.Mock
{
    public static class PlayerMocks
    {
        public static Dictionary<int, Player> Players = new Dictionary<int, Player>
        {
            {
                1,
                    new Player() {
                    Id = 1,
                    JoinDate = new DateTime(),
                    Name = "John Doe 1"
                }
            },
            {
                2,
                    new Player() {
                    Id = 2,
                    JoinDate = new DateTime(),
                    Name = "John Doe 2"
                }
            },
            {
                3,
                    new Player() {
                    Id = 3,
                    JoinDate = new DateTime(),
                    Name = "John Doe 3"
                }
            },
            {
                4,
                    new Player() {
                    Id = 4,
                    JoinDate = new DateTime(),
                    Name = "John Doe 4"
                }
            },
            {
                5,
                    new Player() {
                    Id = 5,
                    JoinDate = new DateTime(),
                    Name = "John Doe 5"
                }
            },
        };
    }
}
