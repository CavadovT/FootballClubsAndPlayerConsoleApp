using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class FootballPlayer:IEntity
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public string PlayerSurname { get; set; }
        public int Age { get; set; }
        public int PlayerNum { get; set; }
        public int ClubId { get; set; }
    }
}
