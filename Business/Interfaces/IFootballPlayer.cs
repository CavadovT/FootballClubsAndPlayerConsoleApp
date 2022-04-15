using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IFootballPlayer
    {
        FootballPlayer Create(FootballPlayer player);
        
        FootballPlayer Update(int playerId,FootballPlayer player);
        
        FootballPlayer Delete(int id);

        List<FootballPlayer> Get(string fitlrname=null);



    }
}
