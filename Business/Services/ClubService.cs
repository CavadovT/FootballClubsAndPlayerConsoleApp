using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace Business.Services
{
    public class ClubService :IClub
    {
        public static int Count { get; set; }
        private ClubRepository _clubRepository;
        public ClubRepository ClubRepository
        {
            get
            {
                return _clubRepository;
            }
            set
            {
                _clubRepository = value;
            }
        }
        public ClubService()
        {
            _clubRepository = new ClubRepository();
        }
        public Club Create(Club club)
        {
            Count++;
            club.ID = Count;
            _clubRepository.Create(club);
            return club;


        }

        public Club Delete(int clId)
        {
            Club isExist = _clubRepository.Find(g => g.ID == clId);
            if (isExist == null)
            {
                Notifications.Print(ConsoleColor.Red, "Player Not Fount for delet");
            }
            _clubRepository.Delete(isExist);
            return isExist;
        }
        /// <summary>
        /// eger filter gonderlimiybse listedik butun clublari gonderecek, eger filtere uygun adda bir nece club varsa onlari,
        /// eger filtere uygun hec ne tapilmazsa message gonderecek
        /// 
        /// </summary>
        /// <param name="filtername"></param>
        /// <returns></returns>
        public List<Club> Get(string filtername = null)
        {
            List<Club> isExist = filtername == null ? _clubRepository.Get() : _clubRepository.Get(s => s.ClubName == filtername);
            if (isExist == null) 
            {
                Notifications.Print(ConsoleColor.Red, "Nothing Found");
            }
            return isExist;
            
        }
        /// <summary>
        /// gonderilen id li clubun melumatlarini yeni gelen club melumatlari ile deyisecek
        /// </summary>
        /// <param name="club"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        public Club Update(Club club, int id)
        {
           
            Club isExist = _clubRepository.Find(g => g.ID == id);
            if (isExist == null)
            {
                Notifications.Print(ConsoleColor.Red, "This Club Not Found");
                return null;
            }
            isExist.ClubName = club.ClubName;
            isExist.MaxPSize = club.MaxPSize;
            _clubRepository.Update(isExist);
            return isExist;
        }

        /// <summary>
        /// gelen playeri onun idsindeki kluba add eliyir
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        /// 

        public FootballPlayer AddPlayerToClub(FootballPlayer player) 
        {
           
            Club club = _clubRepository.Find(c=>c.ID==player.ClubId);

            if (club == null)
            {
                Notifications.Print(ConsoleColor.Red, $"with {player.ClubId} Id Club Not Found");
                return null;
            }
            else if (club.MaxPSize <= club.FootballPlayers.Count) 
            {
                Notifications.Print(ConsoleColor.Red, "Club capasity is max, you don't add player to here!!!");
                return null;
            }
            else
            {
                player.ID = club.FootballPlayers.Count + 1;
                _clubRepository.AddPlayer(player, player.ClubId);
                return player;
            }
        }

        /// <summary>
        /// gelen idli futbolcunun kohne klubdan silir yeni kluba elave edir
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="oldclid"></param>
        /// <param name="newclupId"></param>
        /// <returns></returns>
        
        public Club TransferPlayer(int playerid, int oldclid, int newclupId) 
        {
            if (newclupId == oldclid) 
            {
                Notifications.Print(ConsoleColor.Red, "This transfer was not selected correctly.");
                return null;
            }
            
            Club clubold = _clubRepository.Find(cl => cl.ID == oldclid);
            Club newclub=_clubRepository.Find(cl => cl.ID == newclupId);
            if (clubold == null || newclub == null || playerid > clubold.FootballPlayers.Count)
            {
                Notifications.Print(ConsoleColor.Red, "Plese change the currectly ");
                return null;
            }
            else if (newclub.FootballPlayers.Count >= newclub.MaxPSize) 
            {
                Notifications.Print(ConsoleColor.Red, "This club is max player. You don't add player to here!!!");
                return null;
            }

            else
            {
                _clubRepository.TransferPlayer(playerid, oldclid, newclupId);
                for (int i = 0; i < clubold.FootballPlayers.Count; i++)
                {
                    clubold.FootballPlayers[i].ID = i+1;
                }
                return newclub;
            }
        
        }
    }
}
