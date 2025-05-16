using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    public abstract class Persoon
    {
        private string voornaam;

        public string Voornaam
        {
            get { return voornaam; }
            set { voornaam = char.ToUpper(value[0]) + value.Substring(1); }
        }


        private string achternaam;

        public string Achternaam
        {
            get { return achternaam; }
            set { achternaam = char.ToUpper(value[0]) + value.Substring(1); }
        }


        public Persoon(string voornaam, string achternaam)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
        }

        public abstract string Beschrijf();
    }
}
