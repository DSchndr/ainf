using System;

namespace nimmspiel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nimmspiel");
            Console.Write("Anzahl der Münzen: ");
            int AnzahlMuenzen = Convert.ToInt16(Console.ReadLine());
            bool run = true;
            while (run)
            {
                AnzahlMuenzen = zugMensch(AnzahlMuenzen);
                if (AnzahlMuenzen < 1)
                {
                    Console.WriteLine("Mensch gewinnt!");
                    break;
                }
                AnzahlMuenzen = zugComputer(AnzahlMuenzen);
                if (AnzahlMuenzen < 1)
                {
                    Console.WriteLine("Computer gewinnt!");
                    break;
                }
            }
            Console.ReadLine();
        }
        static int zugMensch(int AnzahlMuenzen)
        {
            Console.Write("Ziehen sie eine Münze [1-3]: ");
            int zahl = Convert.ToInt16(Console.ReadLine());
            if (zahl > 3 || zahl < 1 ) { Console.WriteLine("Ungültig."); zahl = zugMensch(AnzahlMuenzen); }
            return AnzahlMuenzen - zahl;
        }
        static int zugComputer(int AnzahlMuenzen)
        {
            var rnd = new Random();
            int zahl = rnd.Next(1,3);
            Console.WriteLine("Der Computer zieht {0} Münzen", zahl);
            return AnzahlMuenzen - zahl;
        }
    }
}
