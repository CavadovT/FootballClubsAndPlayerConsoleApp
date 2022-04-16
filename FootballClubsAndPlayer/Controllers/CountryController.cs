using Business.Services;
using DataAccess;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace FootballClubsAndPlayer.Controllers
{
    public class CountryController
    {
        CountryService countryService = new CountryService();

        #region METHODS

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
            if (DataContext.Countrys.Count == 0)
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly You Have to Create a Country");
            }
            else
            {
                foreach (var item in countryService.Get())
                {
                    Notifications.Print(ConsoleColor.Blue, $"ID: {item.ID}--{item.CountryName}");
                    foreach (var i in item.Clubs)
                    {
                        Notifications.Print(ConsoleColor.Green, $"  \nClID: {i.ID}--ClName: {i.ClubName}--ClCratYear: {i.CreatTeam.Date}");
                    }
                }
            }

        }

        public void UpdateCountry() 
        {
            if (DataContext.Countrys.Count == 0)
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly You Have to Create a Country");
            }
            else
            {
                Notifications.Print(ConsoleColor.Red, "All Countries");
                GetCountry();

                Notifications.Print(ConsoleColor.Yellow, "Change the Country ID for Update");
                int idchek = Chek.NumTryPars();

                Country countrynew = new Country()
                {
                    CountryName = Chek.StrNull(),
                    CountryLanguage = Chek.StrNull(),

                };
                countryService.Update(countrynew, idchek);
            }

        }

        public void DeleteCountry() 
        {
            if (DataContext.Countrys.Count == 0)
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly You Have to Create a Country");
            }
            else
            {
                Notifications.Print(ConsoleColor.Red, "All Countries");
                GetCountry();

                Notifications.Print(ConsoleColor.Yellow, "Change the Country ID for Delete");
                int idchek = Chek.NumTryPars();

                countryService.Delete(idchek);
            }
        }

        public void AddClubToCountry()
        {
            if (DataContext.Countrys.Count == 0)
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly You Have to Create a Country");
            }
            else 
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
        }
        #endregion

    }
}
