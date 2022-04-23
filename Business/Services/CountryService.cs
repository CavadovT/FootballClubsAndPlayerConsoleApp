using Business.Interfaces;
using DataAccess;
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
     /// Siyahidan olkeni silmek gelen Idli
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

        /// <summary>
        /// eger filter gondermesek butun siyahini qaytarir, filter gondersek gonderilen adli olkeleri qaytarir, tapmazsa message qaaytarir
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public List<Country> Get(string countryName = null)
        {

            List<Country>isExist= countryName == null ? _countryRepository.Get() : _countryRepository.Get(c=>c.CountryName==countryName);
            if (isExist == null) 
            {
                Notifications.Print(ConsoleColor.Red, "Nothing Found");
            }
            return isExist; 
            
        }

        /// <summary>
        /// Olkenin infolarini modifiye edir!!!
        /// </summary>
        /// <param name="country"></param>
        /// <param name="countryId"></param>
        /// <returns></returns>
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
                isExist.CountryName = country.CountryName;
                isExist.CountryLanguage = country.CountryLanguage;
                _countryRepository.Update(isExist);
                Notifications.Print(ConsoleColor.Cyan, "Country updated");
                return country;
            }

        }

        /// <summary>
        /// bir olke daxilinde club ve klubral yaratmaq ucun
        /// </summary>
        /// <param name="club"></param>
        /// <param name="countryId"></param>
        /// <returns></returns>
        //public Country AddClubToCountry(Club club,int countryId)
        //{

        //    if (club.CountryId != countryId) 
        //    {
        //        Notifications.Print(ConsoleColor.Red, "countryid and clubs country id is different");
        //    }
        //    Country country= _countryRepository.Find(c => c.ID == countryId);
        //    if (country == null) 
        //    {
        //        Notifications.Print(ConsoleColor.Red, "With this id Country Not Found at List");
        //        return null;
        //    }
        //    else
        //    {

        //        club.ID = country.Clubs.Count + 1;
        //        _countryRepository.AddClub(club, countryId);
        //        return country;

        //    }

        //}
        public void AddClubToCountry(int cloubId, int countryId)
        {
            Club club = DataContext.Clubs.Find(c => c.ID == cloubId);
            Country country=DataContext.Countrys.Find(c => c.ID == countryId);

            //if (club.CountryId != countryId)
            //{
            //    Notifications.Print(ConsoleColor.Red, "countryid and clubs country id is different");
            //}
            if (country == null)
            {
                Notifications.Print(ConsoleColor.Red, "With this id Country Not Found at List");
            }
            else
            {
                _countryRepository.AddClub(club, country);

            }

        }
    }
}
