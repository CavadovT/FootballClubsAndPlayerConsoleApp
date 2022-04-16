using Business.Services;
using DataAccess;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities.Helper;

namespace FootballClubsAndPlayer.Controllers
{
    public class ClubController
    {
        
        ClubService clubService = new ClubService();

        #region METHODS
        public void CreatClub()
        {
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
                FootballPlayers = new List<FootballPlayer>()

            };

            clubService.Create(club);
            Notifications.Print(ConsoleColor.Yellow, $"{club.ClubName} created");

        }

        public void GetClubs()
        {
            foreach (var item in clubService.Get())
            {
                Notifications.Print(ConsoleColor.Blue, $"ID: {item.ID}--CLUB NAME: {item.ClubName}--TEAM CREATED: {item.CreatTeam.Year}\n");
                foreach (var i in item.FootballPlayers)
                {

                    Notifications.Print(ConsoleColor.Green, $"PlayerID: {i.ID}--NAME:{i.PlayerName}--SURNAME: {i.PlayerSurname}--AGE: {i.Age}");

                }
            }
        }

        public void UpdateClub()
        {
            Notifications.Print(ConsoleColor.Red, "All Clubs");
            GetClubs();

            Notifications.Print(ConsoleColor.Yellow, "Change the Clup ID for Update");
            int idchek = Chek.NumTryPars();

            Club clubnew = new Club()
            {
                ClubName = Chek.StrNull(),
                MaxPSize = Chek.NumTryPars(),

            };
            clubService.Update(clubnew, idchek);

        }

        public void DeleteClub()
        {
            Notifications.Print(ConsoleColor.Red, "All Clubs");
            GetClubs();

            Notifications.Print(ConsoleColor.Yellow, "Change the Clup ID for Delete");
            int idchek = Chek.NumTryPars();
            clubService.Delete(idchek);

        }

        public void AddPlayerToClub()
        {
            if (DataContext.Clubs.Count == 0)
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly You have to creat a club");
            }
            else
            {
                GetClubs();

                Notifications.Print(ConsoleColor.Yellow, "Please enter the Player name:");
                string playerName = Chek.StrNull();

                Notifications.Print(ConsoleColor.Yellow, "Please enter the Player surname:");
                string playerSurname = Chek.StrNull();

                Notifications.Print(ConsoleColor.Yellow, "Please enter the Player Age:");
                int age = Chek.NumTryPars();


                Notifications.Print(ConsoleColor.Yellow, "Please enter the Player Number:");
                int playNum = Chek.NumTryPars();


                Notifications.Print(ConsoleColor.Yellow, "Please enter the Player Club Id:");
                int clubId = Chek.NumTryPars();


                FootballPlayer player = new FootballPlayer()
                {
                    PlayerName = playerName,
                    PlayerSurname = playerSurname,
                    ClubId = clubId,
                    Age = age,
                    PlayerNum = playNum

                };

                clubService.AddPlayerToClub(player);
            }
        }

        public void TransferPlayerToAnyClub()
        {
            if (DataContext.Clubs.Count == 0)
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly You have to creat a club");
            }
            else
            {
                Notifications.Print(ConsoleColor.Green, "All Clubs and Players");
                GetClubs();

                Notifications.Print(ConsoleColor.Red, "Change Id player for the transfer");
                int playerid = Chek.NumTryPars();

                Notifications.Print(ConsoleColor.Red, "Change Old Clubd id for the transfer");
                int oldclubid = Chek.NumTryPars();

                Notifications.Print(ConsoleColor.Red, "Change New Club Id for the transfer");
                int newclubid = Chek.NumTryPars();

                clubService.TransferPlayer(playerid, oldclubid, newclubid);
            }

        }
        #endregion
    }
}
