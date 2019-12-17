//Dein Name Du Spasst
using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            double r, flaeche, um;
            string antwort;

            for (antwort = "ja"; !(antwort == "nein"); )
            {
                for (r = 0; r <= 0;)
                {
                    Console.Write("Radius: ");
                    r = Convert.ToDouble(Console.ReadLine());
                }
                flaeche = Math.PI * r * r;
                um = 2 * Math.PI * r;
                Console.WriteLine("fläche: {0}", flaeche);
                Console.WriteLine("um: {0}", um);
                Console.Write("Wiederholen? ");
                antwort = Console.ReadLine();
            }
        }
    }
}