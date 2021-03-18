using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsEnForeachOefeningen
{
    enum Suite
    {
        Schoppen = 0,
        Harten,
        Klaveren,
        Ruiten
    }
    enum Waarde
    {
        Aas = 0,
        Twee,
        Drie,
        Vier,
        Vijf,
        Zes,
        Zeven,
        Acht,
        Negen,
        Tien,
        Boer,
        Koningin,
        Heer
    }
    class Kaart
    {
        public Suite suite { get; set; }
        public Waarde waarde { get; set; }

        public Kaart(Suite suite, Waarde waarde)
        {
            this.suite = suite;
            this.waarde = waarde;
        }
    }
    class BoekKaarten
    {
        public List<Kaart> boekKaarten;
        private int kaartenPerBoek = 13;
        private int aantalBoeken = 4;
        public BoekKaarten()
        {
            this.Opstarten();
        }

        void Opstarten()
        {
            boekKaarten = new List<Kaart>();
            for (int i = 0; i < kaartenPerBoek; i++)
            {
                for (int j = 0; j < aantalBoeken; j++)
                {
                    boekKaarten.Add(new Kaart((Suite)j,(Waarde)i));
                }
            }
        }

        public Kaart TrekRandomKaart()
        {
            Random rnd = new Random();
            int getal = rnd.Next(0, (kaartenPerBoek * aantalBoeken));
            if (boekKaarten.Count <= 0)
            {
                this.Opstarten();
                //this.Schudden();
            }
            Kaart kaartTerugTeGeven = boekKaarten[getal];
            boekKaarten.RemoveAt(getal);
            return kaartTerugTeGeven;
        }
        public int AantalKaarten()
        {
            return boekKaarten.Count;
        }
    }
}
