using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class FootballPlayerRepository : IRepository<FootballPlayer>
    {
        public bool Create(FootballPlayer entity)
        {
            try
            {
                DataContext.FootballPlayers.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(FootballPlayer entity)
        {
            try
            {
                DataContext.FootballPlayers.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FootballPlayer Find(Predicate<FootballPlayer> filter = null)
        {
            try
            {
            return  filter==null ? null :DataContext.FootballPlayers.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<FootballPlayer> Get(Predicate<FootballPlayer> filter = null)
        {
            try
            {
                return filter == null ? DataContext.FootballPlayers : DataContext.FootballPlayers.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool Update(FootballPlayer entity)
        {
            try
            {
                FootballPlayer isExist = DataContext.FootballPlayers.Find(s => s.ID == entity.ID);
                isExist = entity;
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
