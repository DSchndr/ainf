using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, h;
            Console.WriteLine("Umfang & Fläche eines Rechtecks");
            Console.Write("a : ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("h : ");
            h = Convert.ToDouble(Console.ReadLine());

            // nutzer nach eingabe fragen
            Console.WriteLine("f für Fläche; u für Umfang");
            string q = Console.ReadLine();
            if (q == "f")
            {
                Console.Write("Fläche : ");
                Console.WriteLine(a * h);
            }
            else if (q == "u") {
                Console.Write("Umfang : ");
                Console.WriteLine((2 * a) + (2 * h));
                Console.ReadLine();
            }else
            {
                Console.WriteLine("Fehler, beginne von vorne.");
                Main(null);
            }
            Console.ReadKey();
            
        }
    }
}
