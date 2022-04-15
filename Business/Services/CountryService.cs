using Business.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class CountryService : ICountry
    {
        public Country Create(Country country)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public Country Delete(int countryId)
        {
            throw new NotImplementedException();
        }

        public List<Country> Get(string countryName = null)
        {
            throw new NotImplementedException();
        }

        public List<Club> GetClubs(string clubName = null)
        {
            throw new NotImplementedException();
        }

        public Country Update(int countryId, Country country)
        {
            throw new NotImplementedException();
        }
    }
}
