using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class DataContext
    {
        public static List<Country> Countrys;
        public static List<Club> Clubs;
        public static List<FootballPlayer> FootballPlayers;
        static DataContext()
        {
            Countrys = new List<Country>(); 
            Clubs = new List<Club>();
            FootballPlayers = new List<FootballPlayer>();
        }
    }
}
