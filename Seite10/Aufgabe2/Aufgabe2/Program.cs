using System;

namespace Aufgabe2
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
            Console.Write("Fläche : ");
            Console.WriteLine(a * h);

            Console.Write("Umfang : ");
            Console.WriteLine( (2*a) + (2*h));
            Console.ReadLine();
        }
    }
}
