using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsEnForeachOefeningen
{
    class Program
    {
        static void Main(string[] args)
        {
            BookmarkManagar();

            Console.ReadLine();

            void Prijzen()
            {
                Random rnd = new Random();
                double[] prijzen = new double[20];
                double gem = 0;
                for (int i = 0; i < prijzen.Length; i++)
                {
                    Console.Write($"Prijs {i}: ");
                    Console.Write(prijzen[i] = Convert.ToDouble(rnd.Next(1,20)));
                    Console.ReadLine();
                }
                for (int i = 0; i < prijzen.Length; i++)
                {
                    if (prijzen[i] >= 5) Console.WriteLine(prijzen[i]);
                    gem += prijzen[i];
                }
                Console.WriteLine($"Gemiddelde: {gem/=prijzen.Length}");
            }

            void Speelkaarten()
            {
                BoekKaarten boekKaarten = new BoekKaarten();
                Console.WriteLine($"Aantal kaarten: {boekKaarten.AantalKaarten()}");
                Kaart getrokkenKaart = boekKaarten.TrekRandomKaart();
                Console.WriteLine($"Getrokken kaart: {getrokkenKaart.suite} - {getrokkenKaart.waarde}");
                Console.WriteLine($"Aantal kaarten over: {boekKaarten.AantalKaarten()}");
            }

            void StudentOrganizer()
            {
                List<Student> studenten = new List<Student>();
                for (int i = 0; i < 5; i++)
                    studenten.Add(new Student());
                bool exit = false;
                while (!exit)
                {
                    switch (SelectMenu("Student gegevens invoeren", "Student gegevens tonen", "Verwijder student", "exit"))
                    {
                        case 1:
                            {
                                int iAntw = 0;
                                bool overschrijven = false;
                                while (!overschrijven)
                                {
                                    if (iAntw !=0)
                                    {
                                        Console.WriteLine("Gelieve een andere nummer te kiezen");
                                        Console.ReadKey(false);
                                        iAntw = 0;
                                    }
                                    while (iAntw > 5 || iAntw < 1)
                                    {
                                        Console.Clear();
                                        int.TryParse(InputChr("Welke studentnummer wil je veranderen? (1 tot 5)").ToString(), out iAntw);
                                    }
                                    Console.WriteLine(iAntw);
                                    if ((studenten[iAntw - 1].Naam != "")&&(studenten[iAntw - 1].Naam != null))
                                        overschrijven = InputBool($"Student {studenten[iAntw - 1].Naam} overschrijven?");
                                    else overschrijven = true;
                                }
                                studenten[iAntw - 1].Naam = InputStr("Naam: ");
                                studenten[iAntw - 1].Leeftijd = Convert.ToInt32(InputStr("Leeftijd: "));
                                studenten[iAntw - 1].Klas = (Klassen)SelectMenu("Klas: EA1", "Klas: EA2", "Klas: EA3", "Klas: EA4") - 1;
                                studenten[iAntw - 1].PuntenCommunicatie = Convert.ToInt32(InputStr("Punten communicatie: "));
                                studenten[iAntw - 1].PuntenProgrammingPrinciples = Convert.ToInt32(InputStr("Punten programming pinciples: "));
                                studenten[iAntw - 1].PuntenWebTech = Convert.ToInt32(InputStr("Punten web technology: "));
                                Console.WriteLine($"Student {studenten[iAntw - 1].Naam} bewaard");
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("Overzicht alle studenten: ");
                                foreach (Student student in studenten)
                                    if ((student.Naam != "") && (student.Naam != null))
                                    {
                                        Console.WriteLine();
                                        student.GeefOverzicht();
                                    }
                                Console.ReadLine();
                            }
                            break;
                        case 3:
                            {
                                List<string> studentNamen = new List<string>(); 
                                foreach (Student student in studenten)
                                    if (student.Naam != "") studentNamen.Add(student.Naam);
                                string teVerwijderen = studentNamen[SelectMenu(studentNamen.ToArray()) - 1];
                                bool verwijderd = false;
                                foreach (Student student in studenten)
                                    if (student.Naam == teVerwijderen)
                                    {
                                        student.VerwijderGegevens();
                                        verwijderd = true;
                                        break;
                                    }
                                Console.WriteLine(verwijderd?$"Student {teVerwijderen} is verwijderd.":$"Niet gelukt om {teVerwijderen} te verwijderen.");
                                Console.ReadLine();
                            }
                            break;
                        default: exit = true; break;
                    }
                }
            }

            void BookmarkManagar()
            {
                List<Bookmark> bookmarks = new List<Bookmark>();
                bool exit = false;

                for (int i = 0; i < 5; i++)
                    bookmarks.Add(new Bookmark());

                while (!exit)
                    switch (SelectMenu("Bookmark aanmaken/aanpassen", "Bookmark verwijderen","Bookmark openen", "exit"))
                    {
                        case 1:
                            {
                                int iAntw = 0;
                                bool overschrijven = false;
                                while (!overschrijven)
                                {
                                    if (iAntw != 0)
                                    {
                                        Console.WriteLine("Gelieve een andere bookmark te kiezen");
                                        Console.ReadKey(false);
                                        iAntw = 0;
                                    }
                                    while (iAntw > 5 || iAntw < 1)
                                    {
                                        Console.Clear();
                                        int.TryParse(InputChr("Welke bookmark wil je veranderen? (1 tot 5)").ToString(), out iAntw);
                                    }
                                    Console.WriteLine(iAntw);
                                    if ((bookmarks[iAntw - 1].Naam != "") && (bookmarks[iAntw - 1].Naam != null))
                                        overschrijven = InputBool($"Bookmark {bookmarks[iAntw - 1].Naam} overschrijven?");
                                    else overschrijven = true;
                                }
                                bookmarks[iAntw - 1].Naam = InputStr("Naam: ");
                                bookmarks[iAntw - 1].URL = InputStr("URL: ");
                                Console.WriteLine($"Bookmark {bookmarks[iAntw - 1].Naam} bewaard");
                            }
                            break;
                        case 2:
                            {
                                List<string> bookmarkName = new List<string>();
                                foreach(Bookmark bookmark in bookmarks)
                                    if ((bookmark.Naam != "") && (bookmark.Naam != null)) bookmarkName.Add(bookmark.Naam);
                                bookmarkName.Add("Exit");
                                string teVerwijderen = bookmarkName[SelectMenu(bookmarkName.ToArray()) - 1];
                                bool verwijderd = false;
                                foreach (Bookmark bookmark in bookmarks)
                                    if (bookmark.Naam == teVerwijderen)
                                    {
                                        bookmark.VerwijderGegevens();
                                        verwijderd = true;
                                        break;
                                    }
                                Console.WriteLine(verwijderd ? $"Bookmark {teVerwijderen} is verwijderd." : $"Niet gelukt om {teVerwijderen} te verwijderen.");
                                Console.ReadLine();
                            }
                            break;
                        case 3:
                            {
                                List<string> bookmarkName = new List<string>();
                                foreach (Bookmark bookmark in bookmarks)
                                    if ((bookmark.Naam != "") && (bookmark.Naam != null)) bookmarkName.Add(bookmark.Naam);
                                bookmarkName.Add("Exit");
                                string bookmarkOpenen = bookmarkName[SelectMenu(bookmarkName.ToArray()) - 1];
                                foreach (Bookmark bookmark in bookmarks)
                                    if (bookmark.Naam == bookmarkOpenen)
                                    {
                                        bookmark.OpenSite();
                                        break;
                                    }
                            }break;
                        default: exit = true; break;
                    }
            }

            int SelectMenu(params string[] menu)
            {
                int selection = 1;
                bool selected = false;               
                ConsoleColor selectionForeground = Console.BackgroundColor;
                ConsoleColor selectionBackground = Console.ForegroundColor;
                
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                Console.Clear();
                while (!selected)
                {
                    for (int i = 0; i < menu.Length; i++)
                    {
                        if (selection == i + 1)
                        {
                            Console.ForegroundColor = selectionForeground;
                            Console.BackgroundColor = selectionBackground;
                        }
                        Console.WriteLine((i + 1) + ": " + menu[i]);
                        Console.ResetColor();
                    }
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            selection--;
                            break;
                        case ConsoleKey.DownArrow:
                            selection++;
                            break;
                        case ConsoleKey.Enter:
                            selected = true;
                            break;
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1: selection = 1; break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2: selection = 2; break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3: selection =  3 <= menu.Length ? 3:menu.Length; break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4: selection =  4 <= menu.Length ? 4 : menu.Length; break;
                    }
                    selection = Math.Min(Math.Max(selection, 1), menu.Length);
                    Console.SetCursorPosition(0, 0);
                }
                Console.Clear();
                Console.CursorVisible = true;
                return selection;
            }
            char InputChr(params string[] tekst)
            {
                for (int i = 0; i < tekst.GetLength(0); i++)
                    Console.WriteLine(tekst[i]);
                return Console.ReadKey(true).KeyChar;
            }
            string InputStr(params string[] tekst)
            {
                for (int i = 0; i < tekst.GetLength(0); i++)
                    if (tekst.GetLength(0)==1) Console.Write(tekst[i]);
                    else Console.WriteLine(tekst[i]);
                return Console.ReadLine();
            }
            bool InputBool(string tekst = "j/n", bool Cyes = true, bool Cno = false)
            {
                Console.WriteLine(tekst);
                switch (Char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case 'y':
                    case 'j': return Cyes;
                    case 'n': return Cno;
                }
                return false;
            }
        }
    }
}
