using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IClub
    {
        Club Create(Club club);

        Club Update(Club club,int clid);

        Club Delete(int clId);  

        List<Club> Get(string filtername=null);


    }
}
