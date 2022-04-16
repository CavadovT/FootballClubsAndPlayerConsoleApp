using Business.Services;
using DataAccess;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace FootballClubsAndPlayer.Controllers
{
    public class FootballPlayerController
    {
        FootballPlayerService playerService=new FootballPlayerService();

        #region METHODS
        public void CreatPlayer()
        {

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

            playerService.Create(player);
            Notifications.Print(ConsoleColor.Yellow, $"{player.PlayerName} created");

        }

        public void GetPlayer()
        {
            if (DataContext.FootballPlayers.Count == 0) 
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly you have to creat a player");
            }
            else
            {
                foreach (var item in playerService.Get())
                {
                    Notifications.Print(ConsoleColor.Magenta, $"ID: {item.ID}---NAME: {item.PlayerName}---SURNAME: {item.PlayerSurname}----PLAYER AGE{item.Age}---PLAYER'S NUMBER: {item.PlayerName}");
                }
            }
        }

        public void UpdatePlayer()
        {
            if (DataContext.FootballPlayers.Count == 0)
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly you have to creat a player");
            }
            else
            {
                Notifications.Print(ConsoleColor.Blue, "All players");
                GetPlayer();

                Notifications.Print(ConsoleColor.Yellow, "Change the Player id for Update");
                int idchange = Chek.NumTryPars();

                FootballPlayer playernew = new FootballPlayer()
                {
                    PlayerName = Chek.StrNull(),
                    PlayerSurname = Chek.StrNull(),
                    Age = Chek.NumTryPars(),
                    PlayerNum = Chek.NumTryPars(),
                };
                playerService.Update(idchange, playernew);
            }
        }
        public void DeletePlayer()
        {
            if (DataContext.FootballPlayers.Count == 0)
            {
                Console.Beep();
                Notifications.Print(ConsoleColor.Red, "Firstly you have to creat a player");
            }
            else
            {
                Notifications.Print(ConsoleColor.Blue, "All players");
                GetPlayer();

                Notifications.Print(ConsoleColor.Yellow, "Change the Player id for Delete");
                int idchange = Chek.NumTryPars();
                playerService.Delete(idchange);
            }
        }
        #endregion
    }
}

