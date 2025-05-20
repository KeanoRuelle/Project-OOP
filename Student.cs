using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_OOP
{
    public class Student : Persoon
    {
        private int studentennummer;

        public int Studentennummer
        {
            get { return studentennummer; }
            set { studentennummer = Math.Abs(value); }
        }


        private int score;

        public int Score
        {
            get { return score; }
            set {
                if (value < 0)
                    score = 0;
                else if (value > 100)
                    score = 100;
                else
                    score = value;
                }
        }


        public Student(string voornaam, string achternaam, int studentennummer, int score)
            : base(voornaam, achternaam)
        {
            Studentennummer = studentennummer;
            Score = score;
        }
        public override string Beschrijf()
        {
            return $"Student: {Achternaam} {Voornaam}, Nummer: {Studentennummer}, Score: {Score}";
        }
    }
}
