using System;
using System.Collections.Generic;
using System.Text;

namespace Bungalows_KAT
{
    class BungalowType
    {
        // Properties
        public int Id { get; set; }
        public string Type { get; set; }
        public int AantalVolwassenen { get; set; }
        public int AantalKinderen { get; set; }
        public double Prijs { get; set; }

        // Constructor
        public BungalowType(string type, int aantalVolwassenen, int aantalKinderen, double prijs)
        {
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
