using System.Linq;
using System;
using System.Text;

namespace Seite42
{
    class Program
    {
        static void Main(string[] args)
        {
            // Die Windows console ist kacke.
            Console.OutputEncoding = Encoding.UTF8;

            // "versuchen" die funktionen der aufgaben auszuführen
            try
            {
                /*P5();
                P6();
                P7(); */
                //P8();
                P8_2();
                //P9();
                //P10();
                //P11();
            }

            // Ein fehler ist aufgetreten
            catch
            {
                Console.WriteLine("Ürgendwas blödes ist passiert :(");
            }

            //Auf den nutzer warten
            Console.ReadLine();
        }

        static void P5()
        {
            //"Ganze Zahl" = int? :P
            Console.WriteLine("\nProblemstellung 5 | Division durch Null");
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
                Console.Write("Ergebnis: " + (z1 / z2).ToString());
            }
            Console.WriteLine("");
        }
        static void P6()
        {
            Console.WriteLine("\nProblemstellung 6 | Stammkunden-Rabatt");
            Console.Write("Preis: ");
            double preis = Convert.ToDouble(Console.ReadLine());
            Console.SetCursorPosition(Console.CursorLeft + 10, Console.CursorTop - 1);
            Console.WriteLine("€");
            Console.Write("Stammkunde? (J/N): ");
            string sk = Console.ReadLine().ToLower(); //ToLower -> if abfrage braucht nurnoch kleinbuchstaben.
            if (sk == "j")
            {
                //preis - 10%
                preis = (preis / 100) * 90;
            }
            else if (sk == "n")
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
            else if (B > A)
            {
                Console.WriteLine("B ist größer als A");
            }
            else if (A == B)
            {
                Console.WriteLine("A ist gleich wie B");
            }
        }

        static void P8() //Funktion für aufgabe 8
        {
            Console.Write("\nProblemstellung 8 | 'Teenie-Check' \nAlter: ");
            byte alter = Convert.ToByte(Console.ReadLine()); //0-255
            Console.Write("Altersgruppe: ");
            if (alter <= 12)                    //Alter zwischen 0 und 12?
            {
                Console.Write("Kids");          //Altersgruppe ausgeben
                return;                         //Funktion verlassen
            }
            if (alter <= 19)                    //Alter zwischen 13 und 19?
            {
                Console.Write("Teenies");
                return;
            }
            if (alter <= 29)
            {
                Console.Write("Twens");
                return;
            }
            if (alter >= 30)
            {
                Console.Write("Grufties");
                return;
            }
        }
 
        //Funktion für Aufgabe 8 | Die Aufgabe kann man auch so lösen:
        static void P8_2()
        {
            Console.Write("\nProblemstellung 8 | 'Teenie-Check' \nAlter: ");
            byte alter = Convert.ToByte(Console.ReadLine()); //Wertebereich 0-255
            Console.Write("Altersgruppe: ");

            // Wir können in dem fall die geschweiften Klammern weglassen
            if (alter <= 12) Console.Write("Kids");         //Alter zwischen 0 und 12?
            else if (alter <= 19) Console.Write("Teenies"); //Alter zwischen 13 und 19?
            else if (alter <= 29) Console.Write("Twens");   //Alter zwischen 20 und 29?
            else Console.Write("Grufties");                 //Alter ist > als 29
        }

        static void P9()
        {
            Console.Write("\n\nProblemstellung 9 | Versandgeschäft \nAuftragswert: ");
            int zuschlag = 0, aw = Convert.ToInt16(Console.ReadLine());
            if (aw < 10)
            {
                zuschlag = 1;
            }
            else if (aw < 100)
            {
                zuschlag = 2;
            }
            else if (aw < 200)
            {
                zuschlag = 3;
            }
            Console.WriteLine("Endpreis: {0:0.00}€", (aw + zuschlag));
        }

        static void P10()
        { //Geht auch ohne array aber ich machs so weil ichs kann ¯\_(ツ)_/¯
            string[,] mt = new string[3, 3] {
                {"Grün", "Gelb",   "Blau"    },
                {"Gelb", "Rot",    "Purpur"  },
                {"Blau", "Purpur", "Violett" }
            };
            Console.WriteLine("\nProblemstellung 10 | Mischtafel");
            Console.Write("Grundfarbe #1 [Rot/Grün/Violett]: ");
            string c1 = Console.ReadLine();
            Console.Write("Grundfarbe #2 [Rot/Grün/Violett]: ");
            string c2 = Console.ReadLine();
            int un = P10_colortonumber(c1);
            int dos = P10_colortonumber(c2);
            if ((un == -1) || (dos == -1))
            {
                Console.WriteLine("Fehler: Bitte geben sie eine der drei Grundfarben (Rot/Grün/Violett) ein. Programm bricht ab.");
                return;
            }
            Console.WriteLine("Mischfarbe: {0}", mt[un, dos]);
        }
        static int P10_colortonumber(string color) //converts string with possible values of "Grün/Rot/Violett" into a integer (0,1,2)
        {
            switch (color.ToLower())
            {
                case "grün":
                case "gruen":
                    return 0;
                case "rot":
                    return 1;
                case "violett":
                    return 2;
            }
            return -1;
        }

        static void P11()
        {
            Console.WriteLine("\nProblemstellung 11 | Ganovendatei");
            string[][] gd = new string[][] {
                //            Name,              Beruf,          Merkmal 1,          Merkmal 2,      Merkmal 3
                new string[] {"Sepp Lederhose",  "Wilderer",     "Vollbart",         "hinkt",        ""},
                new string[] {"Ede Stahlhart",   "Bankräuber",   "tätowiert",        "Glatze",       "Narbe"},
                new string[] {"Pinki Schnüffel", "Spion",        "Adlernase",        "Muttermal",    "" },
                new string[] {"Pit Krumbein",    "Seeräuber",    "einäugig",         "Holzbein",     ""},
                new string[] {"Toni Langfinger", "Taschendieb",  "schmalfingrig",    "Schlappohren", ""}
            };
            Console.Write("Merkmal: ");
            string mm = Console.ReadLine();

            //Nadel im Heuhaufen suchen :P
            foreach (string[] sa in gd)
            {
                if (sa.Contains(mm))
                {
                    Console.WriteLine("Name: {0} | Beruf: {1} | Merkmal 1: {2} | Merkmal 2: {3} | Merkmal 3: {4}", sa[0], sa[1], sa[2], sa[3], sa[4]);
                    return; //Wir haben was gefunden und können aus der Funktion raus.
                }
            }
            Console.WriteLine("Nichts gefunden :/");
        }
    }
}
