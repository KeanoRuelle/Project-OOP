using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    public abstract class Persoon
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        public Persoon(string voornaam, string achternaam)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
        }

        public abstract string Beschrijf();
    }
}
