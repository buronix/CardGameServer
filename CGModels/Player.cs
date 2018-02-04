using CG.Interfaces.Models;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CG.Models
{
    [Description("Player Definition")]
    [DataContract]
    public class Player : IPlayer
    {
        public Player()
        {
        }
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public DateTime JoinDate { get; set; }
    }
    [Description("Single Player Definition")]
    [DataContract]
    public class GetPlayerResponse
    {
        [DataMember(Order = 1)]
        public Player GamePlayer { get; set; }
    }
    [Description("Multiple Player Definition")]
    [DataContract]
    public class GetPlayersResponse
    {
        [DataMember(Order = 1)]
        public List<Player> GamePlayers { get; set; }
    }
}
