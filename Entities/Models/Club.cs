using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Club : IEntity
    {
        public int ID { get; set; }
        public string ClubName { get; set; }    
        public int MaxPSize { get; set; }
        public int CountryId { get; set; }
        public List<FootballPlayer> FootballPlayers { get; set; }
    }
}
