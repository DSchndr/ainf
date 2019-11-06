using System;

namespace Aufgabe3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kreisfläche eines Kreises berechnen");
            Console.Write("Radius: ");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.Write("Fläche : ");
            Console.WriteLine(Math.PI * r*r);
            Console.ReadLine();

        }
    }
}
 