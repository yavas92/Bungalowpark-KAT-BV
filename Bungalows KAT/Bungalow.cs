using System;
using System.Collections.Generic;
using System.Text;

namespace Bungalows_KAT
{
    class Bungalow
    {
        // Properties
        public int Id { get; }
        public BungalowType Type { get; set; }
        public string Adres { get; set; }

        // Constructor
        public Bungalow(BungalowType type, string adres)
        {
            Type = type;
            Adres = adres;
        }

        // Methods
        public override string ToString()
        {
            return $"Adres: {Adres} \n{Type}";
        }

    }
}
