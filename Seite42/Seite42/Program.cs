using System;
using System.Text;

namespace Seite42
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine("Hello World! € :)");
            P5();
            P6();
            P7();
            Console.ReadLine();
        }
        static void P5()
        {
            //"Ganze Zahl" = int? :P
            Console.WriteLine("\nProblemstellung 5");
            Console.Write("Zahl 1: ");
            int z1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Zahl 2: ");
            int z2 = Convert.ToInt16(Console.ReadLine());
            if (z2 == 0)
            {
                Console.Write("Fehler: Zahl 2 ist null. Computer glüht.");
            }
            else
            {
                Console.Write("Ergebnis: " + (z1/z2).ToString());
            }
            Console.WriteLine("");
        }
        static void P6()
        {
            Console.WriteLine("\nProblemstellung 6");
            Console.Write("Preis: ");
            double preis = Convert.ToDouble(Console.ReadLine());
            Console.SetCursorPosition(Console.CursorLeft + 10, Console.CursorTop - 1);
            Console.WriteLine("€");
            Console.Write("Stammkunde? (J/N): ");
            string sk = Console.ReadLine();
            if ((sk == "J") || (sk == "j"))
            {
                //preis - 10%
                preis = (preis / 100) * 90;
            }
            else if ((sk == "N") || (sk == "n"))
            {
                //preis normal, kein stammkunde
            }
            else
            {
                Console.WriteLine("Fehler: geben sie J für Ja oder N für Nein ein. Programm bricht ab.");
                return; //oder P6() um neu anzufangen.
            }
            Console.WriteLine("Preis: " + preis.ToString() + "€");
        }
        static void P7()
        {
            Console.WriteLine("\nProblemstellung 7");
            Console.Write("A: ");
            int A = Convert.ToInt16(Console.ReadLine());
            Console.Write("B: ");
            int B = Convert.ToInt16(Console.ReadLine());
            if (A > B)
            {
                Console.WriteLine("A ist größer als B");
            }
            if ( B > A)
            {
                Console.WriteLine("B ist größer als A");
            }
            if ( A == B)
            {
                Console.WriteLine("A ist gleich wie B");
            }
        }
        static void P8() { //TODO
            Console.WriteLine("\nProblemstellung 8");
        }
    }
}
