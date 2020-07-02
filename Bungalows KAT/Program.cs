using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Bungalows_KAT
{
    class Program
    {
        static BungalowType[] BungalowTypes = new BungalowType[3];
        static Bungalow[] Bungalows = new Bungalow[10];
        static void Main(string[] args)
        {

            BungalowTypes[0] = new BungalowType("Familie bungalow", 4, 2, 199.95);
            BungalowTypes[1] = new BungalowType("Koppel bungalow", 2, 0, 119.95);
            BungalowTypes[2] = new BungalowType("Swingers bungalow", 10, 0, 899.95);

            for (int i = 0; i < Bungalows.Length; i++)
            {
                Bungalows[i] = new Bungalow(BungalowTypes[i % 3], "Jan de Josstraat " + ((i * 20) + 1));
            }



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
                        Console.WriteLine();
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
                        Console.WriteLine();
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
