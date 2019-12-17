using System.Linq;
using System;

namespace seite59
{
    class Program
    {
        static void Main(string[] args)
        {
            //A1();
            //A2();
            //A3();
            A4();
        }
        static void A1()
        {
            Console.WriteLine("Problemstellung 1: Minimum von Zufallszahlen");
            int[] arr = new int[99];
            var rng = new Random();
            for (int i = 0; i < 99; i++)
            {
                arr[i] = rng.Next(10000);
            }
            Console.WriteLine(arr.Min());
            Console.WriteLine(Array.IndexOf(arr, arr.Min()));
        }
        static void A2()
        { //TODO
        Console.WriteLine("Problemstellung 2: Würfel-Häufigkeiten beim Backgammon-Spiel");
            /*
                int[,] arr = new int[6,6];
                for (int i = 1; i <= 100; i++) {
                    //Console.Write("Enter Drücken zum Würfeln");
            */
        }
        static void A3()
        {
            Console.WriteLine("Problemstellung 3: Briefkästen in einem Hochhaus");
            string[,] arr = new String[5, 9];
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    //super duper crude
                    arr[y, x] = string.Format("{0}{1}", y, x); // <------ WÖRKS FÖR Moæ                
                }
            }
            for (int y = 4; y >= 0; y--)
            {
                for (int x = 1; x <= 8; x++)
                {
                    Console.Write("{0} ", arr[y, x]);
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
        static void A4() {
            Console.WriteLine("Problemstellung 4: Buchstaben zählen");
            string s;
            int c = 0;
            s = string.Concat(Console.ReadLine().Take(100));
            foreach(char buchstabe in s) {
                if(buchstabe == 'e') c++;
            }
            Console.WriteLine($"{c} e's in dem text");
        }
    }
}

