using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IClub
    {
        Club Create(Club club);

        Club Update(int clId,Club club);

        Club Delete(int clId);  

        List<Club> Get(string filtername=null);

        List<FootballPlayer> GetPlayers(string filtername=null);

    }
}
