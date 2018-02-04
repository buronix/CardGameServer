using CG.Interfaces.Models;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CG.Models
{
    [Description("Game Definition")]
    [DataContract]
    public class CardGame : IGame
    {
        public CardGame()
        {
            Players = new List<Player>();
        }
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Title { get; set; }
        [DataMember(Order = 3)]
        public List<Player> Players { get; set; }
        [DataMember(Order = 4)]
        public DateTime CreatedDate { get; set; }
    }
    [Description("Single Game Definition")]
    [DataContract]
    public class GetGameResponse
    {
        [DataMember(Order = 1)]
        public CardGame Game { get; set; }
    }
    [Description("Multiple Game Definition")]
    [DataContract]
    public class GetGamesResponse
    {
        [DataMember(Order = 1)]
        public List<CardGame> Games { get; set; }
    }
}
