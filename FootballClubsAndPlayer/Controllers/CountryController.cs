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
        ClubController clubController = new ClubController();

        #region METHODS
        /// <summary>
        /// siyahida ve ya liste daxil edilmis infolar daxilinde yeni bir olke colleksiyasi yaradir
        /// </summary>
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
        /// <summary>
        /// eger parametr gonderilibse hemin parametrli olkeni yox eger gonderilmeyibsa susmaya gore butun olkeleri siyahidan gosterir
        /// </summary>
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
                        Notifications.Print(ConsoleColor.White, $"  \nClID: {i.ID}--ClName: {i.ClubName}--Club Created {i.CreatTeam.Month}/{i.CreatTeam.Day}/{i.CreatTeam.Year}");
                        foreach (var j in i.FootballPlayers) 
                        {
                            Notifications.Print(ConsoleColor.Magenta, $"ID: {j.ID}---NAME: {j.PlayerName}---SURNAME: {j.PlayerSurname}----PLAYER AGE: {j.Age}---PLAYER'S NUMBER: {j.PlayerNum}");
                        }
                    }
                }
            }

        }
        /// <summary>
        /// daxil edilmis id li olkenin infolarini yeni daxil edilen melumatlarla deyisir
        /// </summary>
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

                Notifications.Print(ConsoleColor.Green, "Enter the new name For Update Country");
                string newname = Chek.StrNull();

                Notifications.Print(ConsoleColor.Green, "Enter the new language For Update Country");
                string newlang = Chek.StrNull();

                Country countrynew = new Country()
                {
                    CountryName = newname,
                    CountryLanguage = newlang,

                };
                countryService.Update(countrynew, idchek);
            }

        }
        /// <summary>
        /// bazada olan ve daxil edilmis id li olkeni siyahidan silir
        /// </summary>
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
        /// <summary>
        /// Daxil edilmis id li klubu daxil edilmis id li olkeye add edir
        /// </summary>
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
                clubController.GetClubs();
                Notifications.Print(ConsoleColor.Yellow, "Please check and enter the Country Id for add :");
                int Countid = Chek.NumTryPars();

                //Notifications.Print(ConsoleColor.Yellow, "Please enter the Club name:");
                //string clubName = Chek.StrNull();

                //Notifications.Print(ConsoleColor.Yellow, "Please enter the Club Maximum player size:");
                //int Msize = Chek.NumTryPars();

                //Club club = new Club()
                //{
                //    ClubName = clubName,
                //    MaxPSize = Msize,
                //    CountryId = Countid,
                //    CreatTeam = DateTime.Today,
                //};
                Notifications.Print(ConsoleColor.Yellow, "Enter the cloubId");
                int cloubId= Chek.NumTryPars();
 
                countryService.AddClubToCountry(cloubId,Countid);
                Notifications.Print(ConsoleColor.Yellow, $" added to Country");
            }
        }
        #endregion

    }
}
