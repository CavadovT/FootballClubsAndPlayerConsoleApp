using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities.Helper;

namespace DataAccess.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        public bool Create(Country entity)
        {
            try
            {
                DataContext.Countrys.Add(entity);
                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Delete(Country entity)
        {
            try
            {
                DataContext.Countrys.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Country entity)
        {
            try
            {
                Country isExist = DataContext.Countrys.Find(s => s.ID == entity.ID);
                isExist = entity;
                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Country> Get(Predicate<Country> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Countrys : DataContext.Countrys.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        public bool  AddClub(Club club,int countryid)
        {
            try
            {
                Country country = DataContext.Countrys.Find(cl => cl.ID == countryid);
                country.Clubs.Add(club);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Country Find(Predicate<Country> filter = null)
        {
            return filter==null ? null : DataContext.Countrys.Find(filter);
        }
    }
}
