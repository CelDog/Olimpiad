using System;
using System.Collections.Generic;

namespace Olympiad
{
    internal class OlimpInfo
    {
        public int Id { get; set; }
        public string OlimpName { get; set; }
        public int CityCountryId { get; set; }
        public string OlympType { get; set; }
        public DateTime Date { get; set; }

        public ICollection<PartiList> partiLists { get; set; }


        public OlimpInfo()
        {
            partiLists = new List<PartiList>();
        }
    }
}
