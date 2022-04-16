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
        public static int Countadd { get; set; }
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

        public List<Club> Get(string filtername = null)
        {
            return _clubRepository.Get();
        }

        public Club Update(Club club, int id)
        {
            Club isExist = _clubRepository.Find(g => g.ID == id);
            if (isExist == null)
            {
                Notifications.Print(ConsoleColor.Red, "This Plaer Not Found");
                return null;
            }
            isExist.ClubName = club.ClubName;
            _clubRepository.Update(isExist);
            return club;
        }

        public FootballPlayer AddPlayerToClub(FootballPlayer player) 
        {
           
            Club club = _clubRepository.Find(c=>c.ID==player.ClubId);
            if (club == null)
            {
                Notifications.Print(ConsoleColor.Red, $"with {player.ClubId} Id Club Not Found");
                return null;

            }
            else
            {
                Countadd++;
                player.ID = Countadd;
                _clubRepository.AddPlayers(player);
                return player;

            }
        }

        public Club TransferPlayer(int playerid, int oldclid, int newclupId) 
        {
            
            Club clubold = _clubRepository.Find(cl => cl.ID == oldclid);
            Club newclub=_clubRepository.Find(cl => cl.ID == newclupId);
            if (clubold == null&&newclub==null) 
            {
                Notifications.Print(ConsoleColor.Red, "Plese change the currectly club old and new");
                return null;
            }
            else
            {
                _clubRepository.TransferPlayer(playerid,oldclid,newclupId);
                return newclub;
            }
        
        }
    }
}
