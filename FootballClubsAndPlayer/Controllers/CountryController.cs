using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace FootballClubsAndPlayer.Controllers
{
    public class CountryController
    {

        /*
          public int ID { get; set; }
        public string  CountryName { get; set; }
        public string CountryLanguage { get; set; }
        public List<Club>Clubs { get; set; }
         */
        CountryService countryService = new CountryService();

        #region Methods

        public void CreatCountry()
        {
            Notifications.Print(ConsoleColor.Yellow, "Please enter the country name:");
            string countryName = Chek.StrNull();
            Notifications.Print(ConsoleColor.Yellow, "Please enter the country language");
            string countryLanguage = Chek.StrNull();
            Country country = new Country()
            {
                CountryName = countryName,
                CountryLanguage = countryLanguage,
                Clubs = new List<Club>()

            };

            countryService.Create(country);
            Notifications.Print(ConsoleColor.Yellow, $"{country.CountryName} created");


        }

        public void GetCountry()
        {
            foreach (var item in countryService.Get())
            {
                Notifications.Print(ConsoleColor.Blue, $"{item.ID}--{item.CountryName}");
                foreach (var i in item.Clubs)
                {
                    Notifications.Print(ConsoleColor.Green, $"{i.ID}--{i.ClubName}--{i.CreatTeam}");
                }
            }
        }

        public void AddClubToCountry()
        {
            GetCountry();
            Notifications.Print(ConsoleColor.Yellow, "Please enter the Club name:");
            string clubName = Chek.StrNull();
            Notifications.Print(ConsoleColor.Yellow, "Please enter the Club Maximum player size:");
            int Msize = Chek.NumTryPars();
            Notifications.Print(ConsoleColor.Yellow, "Please enter the Country Id :");
            int Countid = Chek.NumTryPars();
            Club club = new Club()
            {
                ClubName = clubName,
                MaxPSize = Msize,
                CountryId = Countid,
                CreatTeam = DateTime.Today,
            };

            countryService.AddClub(club);
            Notifications.Print(ConsoleColor.Yellow, $"{club.ClubName} added to");
        }
        #endregion

    }
}
