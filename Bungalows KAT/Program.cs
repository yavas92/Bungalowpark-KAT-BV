using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Bungalows_KAT
{
    class Program
    {
        static BungalowType[] BungalowTypes = new BungalowType[3];
        static Bungalow[] Bungalows = new Bungalow[10];
        static Klanten[] Klanten = new Klanten[4];
        static void Main(string[] args)
        {

            BungalowTypes[0] = new BungalowType("Familie bungalow", 4, 2, 199.95);
            BungalowTypes[1] = new BungalowType("Koppel bungalow", 2, 0, 119.95);
            BungalowTypes[2] = new BungalowType("Swingers bungalow", 10, 0, 899.95);

            for (int i = 0; i < Bungalows.Length; i++)
            {
                Bungalows[i] = new Bungalow(BungalowTypes[i % 3], "Jan de Josstraat " + ((i * 20) + 1));
            }

            Klanten[0] = new Klanten(1, "Abdullah", "Yavas", "Varkensstraat 2, Oink", "BE012345678", 0);
            Klanten[1] = new Klanten(2, "Koen", "Vandenberg", "Koestraat 3, Meuh", "BE112345678", 0);
            Klanten[2] = new Klanten(3, "Thomas", "Haenen", "Haanstraat 52, Koekelekoe", "BE212345678", 0);
            Klanten[3] = new Klanten(4, "Jo", "Wouters", "Geitstraat 13, Meheheh", "BE312345678", 0);


            bool quit = false;
            do
            {
                Console.Clear();
                TrekLijn("Menu");
                Console.WriteLine("1. Bungalow");
                Console.WriteLine("2. BungalowTypes");
                Console.WriteLine("3. Dagkalender");
                Console.WriteLine("4. Klanten");
                Console.WriteLine("5. Stoppen");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine();
                        MenuBungalow();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine();
                        MenuBungalowTypes();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine();
                        MenuDagkalender();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine();
                        MenuKlanten();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.WriteLine("+------+");
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Error: verkeerde optie");
                        break;
                }
            } while (!quit);
            Console.Read();
        }

        static void MenuBungalow()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                TrekLijn("Bungalows");
                Console.WriteLine("1. Bekijken");
                Console.WriteLine("2. Verwijderen");
                Console.WriteLine("3. Bewerken");
                Console.WriteLine("4. Toevoegen");
                Console.WriteLine("5. Terug naar hoofdmenu");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        BungalowsBekijken();
                        break;

                    //Verwijderen
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        BungalowVerwijderen();
                        break;

                    //Bewerken
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        BungalowBewerken();
                        break;

                    //Toevoegen
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        BungalowToevoegen();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Error: verkeerde optie");
                        break;
                }
            } while (!quit);

        }

        private static void BungalowsBekijken()
        {
            int index = 0;
            Console.Clear();
            foreach (var bung in Bungalows)
            {
                Console.WriteLine("Index Bungalow: " + index);
                ++index;
                Console.WriteLine(bung.ToString());
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void BungalowVerwijderen()
        {
            Console.WriteLine("-------------------------");
            //Ask for index of bungalow that needs to be eddited
            Console.WriteLine($"Welke bungalow wil je verwijderen? (0-{Bungalows.Length - 1})");
            //Check if input is correct
            int index = int.MinValue;
            bool input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (index < 0 || index >= Bungalows.Length)
                    Console.WriteLine("Dit is geen geldige index");
                else
                    input = true;
            }

            PrintBungalow(index);
            Console.WriteLine();

            Console.WriteLine("Bent u zeker dat u deze bungalow wilt verwijderen? (ja/nee)");
            input = false;
            while (!input)
            {
                string jaNee = Console.ReadLine();
                if (jaNee.ToLower().Equals("ja"))
                {
                    // verplaats de te verwijderen index met de laatste index
                    Bungalows[index] = Bungalows[Bungalows.Length - 1];
                    Array.Resize(ref Bungalows, Bungalows.Length - 1);
                    Console.WriteLine("Bungalow is verwijderd.");
                    input = true;
                }
                else if (jaNee.ToLower().Equals("nee"))
                {
                    Console.WriteLine("Verwijderen is geannuleerd.");
                    input = true;
                }
                else
                {
                    Console.WriteLine("Geen geldige input, probeer opnieuw");
                }
            }
        }
        #region Bungalow
        static void PrintBungalow(int index)
        {
            Console.WriteLine(Bungalows[index].ToString());

        }

        static void BungalowBewerken()
        {
            Console.WriteLine("-------------------------");
            //Ask for index of bungalow that needs to be eddited
            Console.WriteLine($"Welke bungalow wil je bewerken? (0-{Bungalows.Length - 1})");
            //Check if input is correct
            int index = int.MinValue;
            bool input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (index < 0 || index >= Bungalows.Length)
                    Console.WriteLine("Dit is geen geldige index");
                else
                    input = true;
            }

            PrintBungalow(index);
            Console.WriteLine();

            //Ask for BungalowType index
            Console.WriteLine($"Welk bungalow type wil je? (0-{BungalowTypes.Length - 1}) (-1 om niet te bewerken)");
            for (int i = 0; i < BungalowTypes.Length; i++)
            {
                Console.WriteLine($"{i}. {BungalowTypes[i].Type}");
            }
            input = false;
            int type = int.MinValue;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (type < -1 || type >= BungalowTypes.Length)
                    Console.WriteLine("Dit is geen geldige index");
                else
                    input = true;
            }

            //Get new Adress
            Console.WriteLine("Nieuw bungalow adres? (leeg laten om niet te bewerken)");
            string adress = Console.ReadLine();

            //Make needed changes to bungalow
            Bungalow newBungalow = Bungalows[index];
            if (type != -1)
                newBungalow.Type = BungalowTypes[type];
            if (!String.IsNullOrWhiteSpace(adress))
                newBungalow.Adres = adress;
            Bungalows[index] = newBungalow;

            Console.Clear();
            PrintBungalow(index);
            Console.WriteLine();
        }

        static void BungalowToevoegen()
        {
            int type = 0;
            string adres;
            bool input = false;
            Console.WriteLine($"Welke bungalow type? (0-{BungalowTypes.Length - 1})");
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (type < 0 || type >= BungalowTypes.Length)
                    Console.WriteLine("Dit is geen geldige index");
                else
                    input = true;
            }
            Console.WriteLine("Wat is het bungalow adres?");
            adres = Console.ReadLine();
            Array.Resize(ref Bungalows, Bungalows.Length + 1);
            Bungalows[Bungalows.Length - 1] = new Bungalow(BungalowTypes[type], adres);
        }
        #endregion
        #region BungalowTypes
        static void MenuBungalowTypes()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                TrekLijn("Bungalow types");
                Console.WriteLine("1. Bekijken");
                Console.WriteLine("2. Verwijderen");
                Console.WriteLine("3. Bewerken");
                Console.WriteLine("4. Toevoegen");
                Console.WriteLine("5. Terug naar hoofdmenu");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        BungalowTypesBekijken();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        BungalowTypesVerwijderen();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        BungalowTypesBewerken();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        BungalowTypesToevoegen();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Error: verkeerde optie");
                        break;
                }
            } while (!quit);
        }

        static void PrintBungalowType(int index)
        {
            Console.WriteLine(BungalowTypes[index].ToString());

        }

        private static void BungalowTypesToevoegen()
        {
            //Get new Adress
            Console.WriteLine("Nieuw bungalow type naam?");
            string type = "";
            do
            {
                type = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(type));

            // Read volwassenen
            Console.WriteLine("Nieuw aantal volwassenen? (min. 1)");
            int aantalVolwassenen = -1;
            bool input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out aantalVolwassenen))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (aantalVolwassenen < 1)
                    Console.WriteLine("Geen geldig aantal");
                else
                    input = true;
            }

            // Read kinderen
            Console.WriteLine("Nieuw aantal kinderen?");
            int aantalKinderen = -1;
            input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out aantalKinderen))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (aantalKinderen < 0)
                    Console.WriteLine("Geen geldig aantal");
                else
                    input = true;
            }

            // Read prijs
            Console.WriteLine("Nieuw prijs?");
            double prijs = -1;
            input = false;
            while (!input)
            {
                if (!double.TryParse(Console.ReadLine(), out prijs))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (prijs < 0)
                    Console.WriteLine("Geen geldig aantal");
                else
                    input = true;
            }
            Array.Resize(ref BungalowTypes, BungalowTypes.Length + 1);
            BungalowTypes[BungalowTypes.Length - 1] = new BungalowType(type, aantalVolwassenen, aantalKinderen, prijs);

            Console.Clear();
            PrintBungalowType(BungalowTypes.Length - 1);
            Console.WriteLine();
        }

        private static void BungalowTypesBewerken()
        {
            Console.WriteLine("-------------------------");
            //Ask for index of bungalow that needs to be eddited
            Console.WriteLine($"Welke bungalow type wil je bewerken? (0-{BungalowTypes.Length - 1})");
            //Check if input is correct
            int index = int.MinValue;
            bool input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (index < 0 || index >= BungalowTypes.Length)
                    Console.WriteLine("Dit is geen geldige index");
                else
                    input = true;
            }

            PrintBungalowType(index);
            Console.WriteLine();

            //Get new Adress
            Console.WriteLine("Nieuw bungalow type naam? (leeg laten om niet te bewerken)");
            string type = Console.ReadLine();

            //Make needed changes to bungalow
            //BungalowType newBungalow = BungalowTypes[index];
            if (!String.IsNullOrWhiteSpace(type))
                BungalowTypes[index].Type = type;
            //BungalowTypes[index] = newBungalow;

            // Read volwassenen
            Console.WriteLine("Nieuw aantal volwassenen? (min. 1) (-1 om niet te bewerken)");
            int aantalVolwassenen = -1;
            input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out aantalVolwassenen))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (aantalVolwassenen < 1 && !(aantalVolwassenen == -1))
                    Console.WriteLine("Geen geldig aantal");
                else
                    input = true;
            }
            if (aantalVolwassenen != -1)
                BungalowTypes[index].AantalVolwassenen = aantalVolwassenen;

            // Read kinderen
            Console.WriteLine("Nieuw aantal kinderen? (min. 0) (-1 om niet te bewerken)");
            int aantalKinderen = -1;
            input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out aantalKinderen))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (aantalKinderen < -1)
                    Console.WriteLine("Geen geldig aantal");
                else
                    input = true;
            }
            if (aantalKinderen != -1)
                BungalowTypes[index].AantalKinderen = aantalKinderen;

            // Read prijs
            Console.WriteLine("Nieuw prijs? (min. 0) (-1 om niet te bewerken)");
            double prijs = -1;
            input = false;
            while (!input)
            {
                if (!double.TryParse(Console.ReadLine(), out prijs))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (prijs < 0 && !(prijs == -1))
                    Console.WriteLine("Geen geldig aantal");
                else
                    input = true;
            }
            if (prijs != -1)
                BungalowTypes[index].Prijs = prijs;


            Console.Clear();
            PrintBungalow(index);
            Console.WriteLine();
        }

        public static void BungalowTypesVerwijderen()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            //Ask for index of bungalow that needs to be eddited
            Console.WriteLine($"Welke bungalow type wil je verwijderen? (0-{BungalowTypes.Length - 1})");
            //Check if input is correct
            int index = int.MinValue;
            bool input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (index < 0 || index >= BungalowTypes.Length)
                    Console.WriteLine("Dit is geen geldige index");
                else
                    input = true;
            }

            PrintBungalowType(index);
            Console.WriteLine();

            Console.WriteLine("Bent u zeker dat u deze bungalow type wilt verwijderen? (ja/nee)");
            input = false;
            while (!input)
            {
                string jaNee = Console.ReadLine();
                if (jaNee.ToLower().Equals("ja"))
                {
                    // verplaats de te verwijderen index met de laatste index
                    BungalowTypes[index] = BungalowTypes[BungalowTypes.Length - 1];
                    Array.Resize(ref BungalowTypes, BungalowTypes.Length - 1);
                    Console.WriteLine("Bungalow type is verwijderd.");
                    input = true;
                }
                else if (jaNee.ToLower().Equals("nee"))
                {
                    Console.WriteLine("Verwijderen is geannuleerd.");
                    input = true;
                }
                else
                {
                    Console.WriteLine("Geen geldige input, probeer opnieuw");
                }
            }
        }

        static void BungalowTypesBekijken()
        {
            Console.Clear();
            for (int i = 0; i < BungalowTypes.Length; ++i)
            {
                Console.WriteLine($"Index nr{i}");
                Console.WriteLine(BungalowTypes[i].ToString());
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        #endregion
        #region DagKalender
        static void MenuDagkalender()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                TrekLijn("Dagkalender");
                Console.WriteLine("1. Bekijken");
                Console.WriteLine("2. Verwijderen");
                Console.WriteLine("3. Toevoegen");
                Console.WriteLine("4. Terug naar hoofdmenu");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Error: verkeerde optie");
                        break;
                }
            } while (!quit);
        }
        #endregion
        #region Klanten
        static void MenuKlanten()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                TrekLijn("Klanten");
                Console.WriteLine("1. Bekijken");
                Console.WriteLine("2. Verwijderen");
                Console.WriteLine("3. Bewerken");
                Console.WriteLine("4. Toevoegen");
                Console.WriteLine("5. Terug naar hoofdmenu");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        // bekijken
                        KlantenBekijken();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        // verwijderen
                        KlantVerwijderen();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        // bewerken
                        KlantBewerken();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        // toevoegen
                        KlantToevoegen();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Error: verkeerde optie");
                        break;
                }
            } while (!quit);
        }

        private static void KlantToevoegen()
        {
            Console.WriteLine("-------------------------");
            //Get new Voornaam
            Console.WriteLine("Nieuw klant voornaam?");
            string voornaam = Console.ReadLine();

            //Get new Naam
            Console.WriteLine("Nieuw klant naam?");
            string achternaam = Console.ReadLine();

            //Get new Adres
            Console.WriteLine("Nieuw klant adres?");
            string adres = Console.ReadLine();

            //Get new Bankkaart
            Console.WriteLine("Nieuw klant bankkaart?");
            string bankkaart = Console.ReadLine();

            // Get new AantalBoekingen
            Console.WriteLine("Nieuw aantal boekingen?");
            int aantalBoekingen = -1;
            bool input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out aantalBoekingen))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (aantalBoekingen < 0)
                    Console.WriteLine("Geen geldig aantal");
                else
                    input = true;
            }

            //Get new index
            int index = GetHighestId() + 1;
            Array.Resize(ref Klanten, Klanten.Length + 1);
            Klanten[Klanten.Length - 1] = new Klanten(index, voornaam, achternaam, adres, bankkaart,aantalBoekingen);

            Console.Clear();
            PrintKlant(Klanten.Length - 1);
            Console.WriteLine();  
        }

        private static int GetHighestId()
        {
            int highest = int.MinValue;
            foreach (Klanten item in Klanten)
            {
                if (item.ID > highest)
                    highest = item.ID;
            }
            return highest;
        }

        private static void KlantBewerken()
        {
            Console.WriteLine("-------------------------");
            //Ask for index of klant that needs to be eddited
            Console.WriteLine($"Welke klant wil je bewerken? (0-{BungalowTypes.Length - 1})");
            //Check if input is correct
            int index = int.MinValue;
            bool input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (index < 0 || index >= Klanten.Length)
                    Console.WriteLine("Dit is geen geldige index");
                else
                    input = true;
            }

            PrintKlant(index);
            Console.WriteLine();

            //Get new Voornaam
            Console.WriteLine("Nieuw klant voornaam? (leeg laten om niet te bewerken)");
            string voornaam = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(voornaam))
                Klanten[index].Voornaam = voornaam;

            //Get new Naam
            Console.WriteLine("Nieuw klant naam? (leeg laten om niet te bewerken)");
            string achternaam = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(achternaam))
                Klanten[index].Achternaam = achternaam;

            //Get new Adres
            Console.WriteLine("Nieuw klant adres? (leeg laten om niet te bewerken)");
            string adres = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(adres))
                Klanten[index].Adres = adres;

            //Get new Bankkaart
            Console.WriteLine("Nieuw klant bankkaart? (leeg laten om niet te bewerken)");
            string bankkaart = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(bankkaart))
                Klanten[index].Bankkaart = bankkaart;


            // Get new AantalBoekingen
            Console.WriteLine("Nieuw aantal boekingen? (-1 om niet te bewerken)");
            int aantalBoekingen = -1;
            input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out aantalBoekingen))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (aantalBoekingen < -1)
                    Console.WriteLine("Geen geldig aantal");
                else
                    input = true;
            }
            if (aantalBoekingen != -1)
                Klanten[index].AantalBoekingen = aantalBoekingen;

            Console.Clear();
            PrintKlant(index);
            Console.WriteLine();
        }

        private static void KlantVerwijderen()
        {
            Console.WriteLine("-------------------------");
            //Ask for index of bungalow that needs to be eddited
            Console.WriteLine($"Welke klant wil je verwijderen? (0-{Klanten.Length - 1})");
            //Check if input is correct
            int index = int.MinValue;
            bool input = false;
            while (!input)
            {
                if (!Int32.TryParse(Console.ReadLine(), out index))
                    Console.WriteLine("Dit is geen geldige nummer");
                else if (index < 0 || index >= Klanten.Length)
                    Console.WriteLine("Dit is geen geldige index");
                else
                    input = true;
            }

            PrintKlant(index);
            Console.WriteLine();

            Console.WriteLine("Bent u zeker dat u deze klant wilt verwijderen? (ja/nee)");
            input = false;
            while (!input)
            {
                string jaNee = Console.ReadLine();
                if (jaNee.ToLower().Equals("ja"))
                {
                    // verplaats de te verwijderen index met de laatste index
                    Klanten[index] = Klanten[Klanten.Length - 1];
                    Array.Resize(ref Klanten, Klanten.Length - 1);
                    Console.WriteLine("Bungalow is verwijderd.");
                    input = true;
                }
                else if (jaNee.ToLower().Equals("nee"))
                {
                    Console.WriteLine("Verwijderen is geannuleerd.");
                    input = true;
                }
                else
                {
                    Console.WriteLine("Geen geldige input, probeer opnieuw");
                }
            }
        }

        private static void PrintKlant(int index)
        {
            Console.WriteLine(Klanten[index].ToString());
        }

        static void KlantenBekijken()
        {
            int index = 0;
            Console.Clear();
            foreach (var klant in Klanten)
            {
                Console.WriteLine(klant.ToString());
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        #endregion

        static void TrekLijn(string titel)
        {

            // +-------+
            // | TITEL |
            // +-------+

            Console.WriteLine($"+{"+".PadLeft(titel.Length + 3, '-')}");
            Console.WriteLine($"| {titel} |");
            Console.WriteLine($"+{"+".PadLeft(titel.Length + 3, '-')}");

        }


        // "| " -> 2 characters
        // Titel -> 4 charaters
        // " |" -> 2 characters

        // 6 characters -> "| Test"

        // 8 characters -> "| Test |"


    }
}
