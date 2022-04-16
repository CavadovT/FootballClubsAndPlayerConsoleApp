using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities.Helper;

namespace Business.Services
{
    public class CountryService : ICountry
    {
        public static int Count { get; set; }
        public static int Countadd { get; set; }
        private CountryRepository _countryRepository;
        public CountryRepository CountryRepository
        {
            get
            {
                return _countryRepository;
            }
            set
            {
                _countryRepository = value;
            }
        }
        public CountryService()
        {
            _countryRepository = new CountryRepository();
        }

        public Country Create(Country country)
        {
            Count++;
            country.ID = Count;
            _countryRepository.Create(country);
            return country;
        }
        /// <summary>
        /// Olkeni silmek hecde mentiqi deyil sadece silirem ki listden silmeyi gorum....
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public Country Delete(int countryId)
        {
            Country country = _countryRepository.Find(cr => cr.ID == countryId);
            if (country == null)
            {
                Notifications.Print(ConsoleColor.Red, "BU idli seher yoxdur liste");
                return null;
            }
            _countryRepository.Delete(country);
            return country;
        }

        public List<Country> Get(string countryName = null)
        {
            return _countryRepository.Get();
        }

        public Country Update(Country country, int countryId)
        {

            Country isExist = _countryRepository.Find(c => c.ID == countryId);
            if (isExist == null)
            {
                Notifications.Print(ConsoleColor.Red, $"With {countryId} Id Country Not Found at database");
                return null;
            }
            else
            {
                _countryRepository.Update(isExist);
                Notifications.Print(ConsoleColor.Cyan, "Country updated");
                return country;
            }

        }

        public Country AddClub(Club club)
        {
            Country country= _countryRepository.Find(c => c.ID == club.CountryId);
            if (country == null) 
            {
                Notifications.Print(ConsoleColor.Red, "Bele olke yoxdur siyahida");
                return null;
            }
            else
            {
                Countadd++;
                club.ID = Countadd;
                _countryRepository.AddClub(club);
                return country;

            }

        }
    }
}
