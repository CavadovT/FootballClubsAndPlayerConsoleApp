using Business.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class ClubService :IClub
    {
        public Club Create(Club club)
        {
            throw new NotImplementedException();
        }

        public Club Delete(int clId)
        {
            throw new NotImplementedException();
        }

        public List<Club> Get(string filtername = null)
        {
            throw new NotImplementedException();
        }

        public List<FootballPlayer> GetPlayers(string filtername = null)
        {
            throw new NotImplementedException();
        }

        public Club Update(int clId, Club club)
        {
            throw new NotImplementedException();
        }
    }
}
