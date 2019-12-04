using System;

namespace Seite53
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                A1();
                A2();
                A3();
                A4();
                A5_1();
                A5_2();
            }
            catch
            {
                Console.WriteLine("Ürgendwas sehr sehr doofes ist passiert :/");
            }
            Console.WriteLine("Done. Press zhe ender Taste.");
            Console.ReadLine();
        }

        static bool A1()
        {
            Console.Write("Problemstellung 1: Anzahl der Vorfahren\n Anzahl der Generationen: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 0) return false;
            
            int tmp = 1;
            for (int i = 1; i <= n; i++ ) tmp = tmp * 2;

            Console.WriteLine("{0} Vorfahren vor {1} Generationen.", tmp, n);
            // Math.Pow wäre ja cheaten ;)
            //Console.WriteLine("{0} Vorfahren vor {1} Generationen.", Math.Pow(2, n), n); //2 hoch die Anzahl der generationen
            return true;
        }

        // Der code sieht richtig scheisse aus und nichtmal ich versteh den, AAAABER er funktioniert! :D
        static void A2()
        {
            Console.WriteLine("\nProblemstellung 2: Kleines 1 mal 1");
            string b = ""; //temporary variable for first column
            bool tmp = false; //temporary variable used to reset x back to -1
            for (int x = -1; x <= 10; x++)
            {
                if (x == 0) //2te zeile hat nur "-"
                {
                    for (int a = 0; a < 100; a++)
                    {
                        Console.SetCursorPosition(a, Console.CursorTop);
                        Console.Write("-");
                    }
                    Console.Write("\n");
                    continue; // raus mit de ~viechers~ for loop
                }
                if (x == -1) //1ste zeile hat den stern im ersten feld
                {
                    b = "*";
                    x = 1;
                    tmp = true;
                }
                else if (x > 0)
                { //3 bis nte zeile hat eine zahl im ersten feld
                    b = x.ToString();
                }

                //Console.WriteLine("\t{0}\t|\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{9}\t{10}", b, 1 * x, 2 * x, 3 * x, 4 * x, 5 * x, 6 * x, 7 * x, 8 * x, 9 * x, 10 * x); //zeile ausgeben
                Console.Write("\t{0}\t|",b);
                for (int i = 1; i < 11; i++) Console.Write("\t{0}", i * x);
                Console.Write("\n");

                if (tmp) { x = -1; tmp = false; } //x wieder auf -1 zurücksetzen
            }
        }
        static void A3()
        {
            Console.WriteLine("\nProblemstellung 3: Formen");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("\n");
                for (int a = 1; a <= i; a++)
                {
                    Console.SetCursorPosition(a, Console.CursorTop);
                    Console.Write("#");
                }
            }
            Console.Write("\n");
            for (int i = 10; i >= 1; i--) //das ganze im rückwärtsgang
            {
                Console.Write("\n");
                for (int a = 1; a <= i; a++)
                {
                    Console.SetCursorPosition(a, Console.CursorTop);
                    Console.Write("#");
                }
            }
            Console.Write("\n");
            for (int i = 10; i >= 1; i--) // das ganze im gang P
            {
                Console.Write("\n");
                for (int a = 0; a <= ((10 - i) * 2); a++)
                {
                    Console.SetCursorPosition(i + a, Console.CursorTop);
                    Console.Write("#");
                }
            }
        }
        static void A4()
        {
            Console.WriteLine("\nProblemstellung 4: Eingabenkontrolle");
            while (A1()) {; } // A1 gibt false zurück wenn 0 eingeben wurde -> loop macht kein loop mehr :(
        }
        static void A5_1()
        {
            Console.WriteLine("\nProblemstellung 5: 2 Bedingungen (L1)");
            bool Bool = true;
            int tmp = ' ';
            while (Bool)
            {
                Console.WriteLine("*");
                tmp = Console.Read();
                if (tmp == 'J' || tmp == 'j') Bool = false;
            }
        }
        static void A5_2()
        {
            Console.WriteLine("\nProblemstellung 5: 2 Bedingungen (L2)");
        
        // Is this basic or c#?
        A:
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.J) return;
            }
            Console.WriteLine("*");
            goto A;
        }
    }
}

