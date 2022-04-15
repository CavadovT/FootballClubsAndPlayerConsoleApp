using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        public bool Create(Country entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Country entity)
        {
            throw new NotImplementedException();
        }

        public List<Country> Get(Country entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Country entity)
        {
            throw new NotImplementedException();
        }
        public List<Club> AddClub(Club club)
        {
            return new List<Club>() { club };
        }
    }
}
