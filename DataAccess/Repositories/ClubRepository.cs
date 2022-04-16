using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using Utilities.Helper;

namespace DataAccess.Repositories
{
    public class ClubRepository : IRepository<Club>
    {
        public bool Create(Club entity)
        {
            try
            {
                DataContext.Clubs.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Club entity)
        {
            try
            {
                DataContext.Clubs.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Club> Get(Club entity)
        {
            throw new NotImplementedException();
        }


        public bool Update(Club entity)
        {
            try
            {
                Club isExist = DataContext.Clubs.Find(s => s.ID == entity.ID);
                isExist = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Club> Get(Predicate<Club> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Clubs : DataContext.Clubs.FindAll(filter);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public void AddPlayers(FootballPlayer player)
        {
            try
            {
                Club club = DataContext.Clubs.Find(cl => cl.ID == player.ClubId);
                club.FootballPlayers.Add(player);
                Notifications.Print(ConsoleColor.Cyan, $"{player.PlayerName}added to {club.ClubName}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Club Find(Predicate<Club> filter = null)
        {
            try
            {
                return filter == null ? null : DataContext.Clubs.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void TransferPlayer(int playerid, int oldClubid,int newClubid)
        {
            try
            {
               
                Club clubold = DataContext.Clubs.Find(cl => cl.ID == oldClubid);
                
                Club clubnew = DataContext.Clubs.Find(ncl => ncl.ID == newClubid);

                clubnew.FootballPlayers.Add(clubold.FootballPlayers[playerid-1]);
                clubold.FootballPlayers.Remove(clubold.FootballPlayers[playerid-1]);
                
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
