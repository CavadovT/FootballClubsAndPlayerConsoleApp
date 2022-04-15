using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Country : IEntity
    {
        public int ID { get; set; }
        public string  CountryName { get; set; }
        public string CountryLanguage { get; set; }
        public List<Club>Clubs { get; set; }
    }
}
