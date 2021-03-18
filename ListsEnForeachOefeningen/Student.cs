using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsEnForeachOefeningen
{
    enum Klassen
    {
        EA1,
        EA2,
        EA3,
        EA4,
        geen
    }
    class Student
    {
        private static int Aantal;
        private int aantal;
        public Student(string voornaam, string achternaam, string adres)
        {
            Naam = voornaam;
        }
        public Student()
        {

        }
        public string Naam { get; set; }
        public int Leeftijd { get; set; }
        public Klassen Klas { get; set; }
        public int PuntenCommunicatie { get; set; }
        public int PuntenProgrammingPrinciples { get; set; }
        public int PuntenWebTech { get; set; }

        public double BerekenTotaalCijfer()
        {
            return (double)(PuntenCommunicatie + PuntenProgrammingPrinciples + PuntenWebTech) / 3;
        }

        public void GeefOverzicht()
        {
            Console.WriteLine($"{Naam}, {Leeftijd} jaar");
            Console.WriteLine($"Klas: {Klas}\n");
            Console.WriteLine($"Cijferrapport:");
            Console.WriteLine("**************");
            Console.WriteLine($"Communicatie:\t\t{PuntenCommunicatie}");
            Console.WriteLine($"Programming Principles:\t{PuntenProgrammingPrinciples}");
            Console.WriteLine($"Web Technologie:\t{PuntenWebTech}");
            Console.WriteLine($"Gemiddelde:\t\t{BerekenTotaalCijfer()}");
        }
        public void VerwijderGegevens()
        {
            Naam = "";
            Leeftijd = -1;
            Klas = Klassen.geen;
            PuntenCommunicatie = -1;
            PuntenProgrammingPrinciples = -1;
            PuntenWebTech = -1;
        }
    }
}
