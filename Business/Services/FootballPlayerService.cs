using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities.Helper;

namespace Business.Services
{
    public class FootballPlayerService : IFootballPlayer
    {
        public static int Count { get; set; }
        private FootballPlayerRepository _footballPlayerRepository;
        public FootballPlayerRepository FootballPlayerRepository
        {
            get
            {
                return _footballPlayerRepository;
            }
            set
            {
                _footballPlayerRepository = value;
            }
        }
        public FootballPlayerService()
        {
            _footballPlayerRepository = new FootballPlayerRepository();
        }
        public FootballPlayer Create(FootballPlayer player)
        {
            Count++;
            player.ID = Count;
            _footballPlayerRepository.Create(player);
            return player;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer isExist = _footballPlayerRepository.Find(g => g.ID == id);
            if (isExist == null)
            {
                Notifications.Print(ConsoleColor.Red, "Player Not Fount for delet");
            }
            _footballPlayerRepository.Delete(isExist);
            return isExist;
        }

        public List<FootballPlayer> Get(string fitlrname = null)
        {
            throw new NotImplementedException();
        }

        public FootballPlayer Update(int playerId, FootballPlayer player)
        {
            FootballPlayer isExist = _footballPlayerRepository.Find(g => g.ID == playerId);
            if (isExist == null)
            {
                Notifications.Print(ConsoleColor.Red, "This Plaer Not Found");
            }
            isExist.PlayerSurname = player.PlayerSurname;
            isExist.PlayerName = player.PlayerName;
            isExist.Age = player.Age;
            isExist.ClubId = player.ClubId;
            _footballPlayerRepository.Update(player);
            return player;
        }
    }
}
