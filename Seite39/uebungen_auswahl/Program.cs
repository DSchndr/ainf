using System;
using System.Text;

namespace uebungen_auswahl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //Für € zeichen ^^
            try
            {
                Ueb1();
                Ueb2();
                Ueb3();
                Ueb4();
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Ein Fehler ist aufgetreten :/");
                Console.ReadLine();
            }
        }
        static void Ueb1()
        {
            Console.WriteLine("Problemstellung 1");
            Console.Write("Betrag Girokonto: ");
            double kontogiro = Convert.ToDouble(Console.ReadLine());
            Console.Write("Betrag Sparkonto: ");
            double kontospar = Convert.ToDouble(Console.ReadLine());
            Console.Write("Überweisungsbetrag: ");
            double ueb = Convert.ToDouble(Console.ReadLine());
            Console.SetCursorPosition(Console.CursorLeft + 26, Console.CursorTop -1);
            Console.WriteLine("€");
            ueb = Math.Round(ueb, 2);
            if (kontospar >= ueb)
            {
                kontogiro = kontogiro + ueb;
                kontospar = kontospar - ueb;
                Console.WriteLine("Girokonto: {0:0.00}€", kontogiro);
                Console.WriteLine("Sparkonto: {0:0.00}€", kontospar);
                kontospar = 0;
            }
            else
            {
                Console.WriteLine("Fehler, Geldbetrag auf dem Sparkonto zu niedrig!");
            }

        }
        static void Ueb2()
        {
            Console.WriteLine("Problemstellung 2");
            Console.Write("Betrag Girokonto: ");
            double kontogiro = Convert.ToDouble(Console.ReadLine());
            Console.Write("Zu abbuchender Betrag: ");
            double kontoabb = Convert.ToDouble(Console.ReadLine());
            Console.Write("Guter Kunde? (Y/N = Normalfall) ");
            bool gk = false;
            if (Console.ReadLine() == "Y")
            {
                gk = true;
            }
            Console.Write("Überziehungskredit: ");
            double kontouek = Convert.ToDouble(Console.ReadLine());

            Console.Write("\n");

            if ((kontogiro - kontoabb > 0) || gk || (kontogiro - kontoabb > kontouek))
            {
                kontogiro = kontogiro - kontoabb;
                Console.WriteLine("{0:0.00}€ auf dem Girokonto", kontogiro);
            }
            else
            {
                Console.WriteLine("Fehler, Geldbetrag auf dem Sparkonto zu niedrig!");
            }
        }

        static void Ueb3()
        {
            Console.WriteLine("Problemstellung 3");
            Console.Write("Betrag Sparkonto: ");
            double kontospar = Convert.ToDouble(Console.ReadLine());
            double kontogiro = 0;
            //Console.Write("Überweisungsbetrag: ");
            //double uebb = Convert.ToDouble(Console.ReadLine());
            Console.Write("Maximalbetrag: ");
            double max = Convert.ToDouble(Console.ReadLine());
            if (kontospar - max > 0)
            {
                Console.WriteLine("Betrag girokonto: " + kontogiro.ToString());
                kontogiro = kontogiro + max;
                kontospar = kontospar - max;
                Console.WriteLine("Neuer Betrag Girokonto: " + kontogiro.ToString() + "€\nNeuer Betrag Sparkonto: " + kontospar.ToString() + "€");
            }
            else
            {
                Console.WriteLine("Geldbetrag kann nicht überwiesen werden, da ihr Konto den Mindestbetrag von " + max.ToString() + "€ nicht hat.");
            }
        }
        static void Ueb4()
        {
            Console.WriteLine("\nProblemstellung 4");
            Console.Write("Seite a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Seite b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Seite c: ");
            double c = Convert.ToDouble(Console.ReadLine());
            if ((a+b > c) && (a+c > b) && (b+c > a))
            {
                Console.WriteLine("Dreieck lässt sich konstruieren");
            }
            else
            {
                Console.WriteLine("Dreieck lässt sich nicht konstruieren");
            }
        }
    }
}
