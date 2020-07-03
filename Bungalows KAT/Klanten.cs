using System;
using System.Collections.Generic;
using System.Text;

namespace Bungalows_KAT
{
    class Klanten
    {
        public int ID { get; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Adres { get; set; }
        public string Bankkaart{ get; set; }
        public int AantalBoekingen { get; set; }

        public Klanten(int id, string voornaam, string achternaam, string adres, string bankkaart, int aantalBoekingen)
        {
            ID = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Adres = adres;
            Bankkaart = bankkaart;
            AantalBoekingen = aantalBoekingen;
        }

        public override string ToString()
        {
            return $"Id: {ID}\nVoornaam: {Voornaam}\nAchternaam: {Achternaam}\nAdres: {Adres}\nBankkaart: {Bankkaart}\nAantalBoekingen: {AantalBoekingen}";
        }
    }
}
