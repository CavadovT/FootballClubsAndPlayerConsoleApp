using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface ICountry
    {
        Country Create(Country country);
        Country Update(Country country,int countryId);
        Country Delete(int countryId);
        List<Country> Get(string countryName=null);
      

    }
}
