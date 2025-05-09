using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    public class Student : Persoon
    {
        public string Studentennummer { get; set; }

        public Student(string voornaam, string achternaam, string studentennummer)
            : base(voornaam, achternaam)
        {
            Studentennummer = studentennummer;
        }
        public override string Beschrijf()
        {
            return $"Student: {Voornaam} {Achternaam}, Nummer: {Studentennummer}";
        }
    }
}
