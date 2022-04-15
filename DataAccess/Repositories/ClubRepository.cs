using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class ClubRepository : IRepository<Club>
    {
        public bool Create(Club entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Club entity)
        {
            throw new NotImplementedException();
        }

        public List<Club> Get(Club entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Club entity)
        {
            throw new NotImplementedException();
        }
        public List<FootballPlayer> AddPlayers(FootballPlayer player)
        {
        return new List<FootballPlayer> { player };
        }
    }
}
