using Business.Services;
using DataAccess;
using Entities.Models;
using System;
using Utilities.Helper;

namespace FootballClubsAndPlayer.Controllers
{
    public class FootballPlayerController
    {
        FootballPlayerService playerService = new FootballPlayerService();

        #region METHODS

        /// <summary>
        /// Ayriliqda bir futbolcu yaratmaq
        /// </summary>
        public void CreatPlayer()
        {

            Notifications.Print(ConsoleColor.Yellow, "Please enter the Player name:");
            string playerName = Chek.StrNull();

            Notifications.Print(ConsoleColor.Yellow, "Please enter the Player surname:");
            string playerSurname = Chek.StrNull();
        A:
            Notifications.Print(ConsoleColor.Yellow, "Please enter the Player Age:");
            int age = Chek.NumTryPars();
            if (age == 0)
            {
                Notifications.Print(ConsoleColor.Red, "Age doesn't be zero or minus!! please enter the correctly");
                goto A;
            }

        Play:
            Notifications.Print(ConsoleColor.Yellow, "Please enter the Player Number:");
            int playNum = Chek.NumTryPars();

            foreach (var item in playerService.Get())
            {
                if (playNum == item.PlayerNum || playNum == 0)
                {
                    Notifications.Print(ConsoleColor.Red, "players of the same number will not or deosn't be zero!! please enter correctly");
                    Notifications.Print(ConsoleColor.Yellow, $"{item.PlayerNum}");
                    goto Play;
                }
            }
            FootballPlayer player = new FootballPlayer()
            {
                PlayerName = playerName,
                PlayerSurname = playerSurname,
                ClubId = 0,
                Age = age,
                PlayerNum = playNum
            };

            playerService.Create(player);
            Notifications.Print(ConsoleColor.Yellow, $"{player.PlayerName} created");

        }

        /// <summary>
        /// Siyahidaki futbolculari gormek
        /// </summary>
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
                    Notifications.Print(ConsoleColor.Magenta, $"ID: {item.ID}---NAME: {item.PlayerName}---SURNAME: {item.PlayerSurname}----PLAYER AGE: {item.Age}---PLAYER'S NUMBER: {item.PlayerNum}");
                }
            }
        }

        /// <summary>
        /// Burada Oyuncunun adi soyadi yasi ve oyuncu nomrelerini yeniden modifye ede bilerik
        /// </summary>
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

                Notifications.Print(ConsoleColor.Yellow, "Enter the new Name Player for Update");
                string newname = Chek.StrNull();

                Notifications.Print(ConsoleColor.Yellow, "Enter the new Surname Player for Update");
                string newsurname = Chek.StrNull();

                Notifications.Print(ConsoleColor.Yellow, "Enter the new Age Player for Update");
                int newage = Chek.NumTryPars();

                Notifications.Print(ConsoleColor.Yellow, "Enter the new Number Player for Update");
                int newnum = Chek.NumTryPars();


                FootballPlayer playernew = new FootballPlayer()
                {
                    PlayerName = newname,
                    PlayerSurname = newsurname,
                    Age = newage,
                    PlayerNum = newnum,
                };
                playerService.Update(idchange, playernew);
            }
        }

        /// <summary>
        /// secilmis idli futbolcunu siyahidan silmek
        /// </summary>
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

