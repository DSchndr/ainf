using System;

namespace uebung1
{
    class Program
    {
        static void Main(string[] args)
        {
            double eins, zwei;
            // double polizei;

            Console.WriteLine("Mathematische Funktionen \n");
            Console.Write("Geben Sie die erste Zahl ein : ");
            eins = Convert.ToDouble(Console.ReadLine());
            Console.Write("Geben sie die zweite Zahl ein : ");
            zwei = Convert.ToDouble(Console.ReadLine());
            Console.Write("Addition der beiden Zahlen : ");
            Console.WriteLine(eins + zwei);
            Console.WriteLine("");
            Console.Write("Subtraktion der beiden Zahlen : ");
            Console.WriteLine(eins - zwei);
            Console.WriteLine("");
            Console.Write("Division der beiden Zahlen : ");
            Console.WriteLine(eins / zwei);
            Console.WriteLine("");
            Console.Write("Multiplikation der beiden Zahlen : ");
            Console.WriteLine(eins * zwei);
            Console.Write("");
            Console.ReadLine();
        }
    }
}
