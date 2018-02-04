/* Options:
Date: 2018-02-04 21:26:40
Version: 5,02
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://localhost:8085

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//ExportValueTypes: False
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using CG.Models;
using CG.Interfaces.Models;
using CG.ServiceModels.Player;
using CG.ServiceModels.Game;


namespace CG.Interfaces.Models
{

    public partial interface IGame
    {
        int Id { get; set; }
    }

    public partial interface IPlayer
    {
        int Id { get; set; }
    }
}

namespace CG.Models
{

    ///<summary>
    ///Game Definition
    ///</summary>
    [DataContract]
    public partial class CardGame
    {
        public CardGame()
        {
            Players = new List<Player>{};
        }

        [DataMember(Order=1)]
        public virtual int Id { get; set; }

        [DataMember(Order=2)]
        public virtual string Title { get; set; }

        [DataMember(Order=3)]
        public virtual List<Player> Players { get; set; }

        [DataMember(Order=4)]
        public virtual DateTime CreatedDate { get; set; }
    }

    ///<summary>
    ///Single Game Definition
    ///</summary>
    [DataContract]
    public partial class GetGameResponse
    {
        [DataMember(Order=1)]
        public virtual CardGame Game { get; set; }
    }

    ///<summary>
    ///Multiple Game Definition
    ///</summary>
    [DataContract]
    public partial class GetGamesResponse
    {
        public GetGamesResponse()
        {
            Games = new List<CardGame>{};
        }

        [DataMember(Order=1)]
        public virtual List<CardGame> Games { get; set; }
    }

    ///<summary>
    ///Single Player Definition
    ///</summary>
    [DataContract]
    public partial class GetPlayerResponse
    {
        [DataMember(Order=1)]
        public virtual Player GamePlayer { get; set; }
    }

    ///<summary>
    ///Multiple Player Definition
    ///</summary>
    [DataContract]
    public partial class GetPlayersResponse
    {
        public GetPlayersResponse()
        {
            GamePlayers = new List<Player>{};
        }

        [DataMember(Order=1)]
        public virtual List<Player> GamePlayers { get; set; }
    }

    ///<summary>
    ///Player Definition
    ///</summary>
    [DataContract]
    public partial class Player
    {
        [DataMember(Order=1)]
        public virtual int Id { get; set; }

        [DataMember(Order=2)]
        public virtual string Name { get; set; }

        [DataMember(Order=3)]
        public virtual DateTime JoinDate { get; set; }
    }
}

namespace CG.ServiceModels.Game
{

    [Route("/games/{Id}", "GET")]
    public partial class GetGame
        : IReturn<GetGameResponse>, IGet
    {
        public virtual int Id { get; set; }
    }

    [Route("/games", "GET")]
    public partial class GetGames
        : IReturn<GetGamesResponse>, IGet
    {
    }
}

namespace CG.ServiceModels.Player
{

    [Route("/players/{Id}", "GET")]
    public partial class GetPlayer
        : IReturn<GetPlayerResponse>, IGet
    {
        public virtual int Id { get; set; }
    }

    [Route("/players", "GET")]
    public partial class GetPlayers
        : IReturn<GetPlayersResponse>, IGet
    {
    }
}

