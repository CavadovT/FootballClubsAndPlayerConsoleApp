using Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Club : IEntity
    {
        private List<FootballPlayer> _footballPlayers;
        public int ID { get; set; }
        public string ClubName { get; set; }
        public int MaxPSize { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatTeam { get; set; }
        public List<FootballPlayer> FootballPlayers
        {
            get
            {
                return _footballPlayers;
            }
            set
            {   
                _footballPlayers = value;
            }
        }

    }
}
