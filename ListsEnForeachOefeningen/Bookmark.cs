using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ListsEnForeachOefeningen
{
    class Bookmark
    {
        public string Naam { get; set; }
        public string URL { get; set; }
        public void OpenSite()
        {
            Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", URL);
        }
        public void VerwijderGegevens()
        {
            Naam = "";
            URL = "";
        }
    }
}
