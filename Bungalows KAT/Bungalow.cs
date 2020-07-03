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
        public Bungalow(BungalowType type, string adres, int id)
        {
            Type = type;
            Adres = adres;
            Id = id;
        }

        // Methods
        public override string ToString()
        {
            return $"ID: {Id}\nAdres: {Adres} \n{Type}";
        }

    }
}
