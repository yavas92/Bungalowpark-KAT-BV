using System;
using System.Collections.Generic;
using System.Text;

namespace Bungalows_KAT
{
    class BungalowType
    {
        private static int laatsteTypeNummer = 0;

        // Properties
        public string Type { get; set; }

        public int AantalVolwassenen { get; set; }
        public int AantalKinderen { get; set; }
        public double Prijs { get; set; }

        // Constructor
        public BungalowType(string type, int aantalVolwassenen, int aantalKinderen, double prijs)
        {
            //switch(laatsteTypeNummer)
            //{
            //    case 0:
            //        Type = "Familie bungalow";
            //        break;
            //    case 1:
            //        Type = "Koppel bungalow";
            //        break;
            //    case 2:
            //        Type = "Swingers bungalow";
            //        break;
            //    default:
            //        Type = laatsteTypeNummer + " is nog niet gedefineerd";
            //        break;
            //}
            //laatsteTypeNummer++;
            Type = type;
            AantalVolwassenen = aantalVolwassenen;
            AantalKinderen = aantalKinderen;
            Prijs = prijs;
        }

        // Methods
        public override string ToString()
        {
            return $"Bungalow Type: {Type} \nAantal volwassenen: {AantalVolwassenen} \nAantal kinderen: {AantalKinderen} \nPrijs: {Prijs} euro per dag";
        }

    }
}
