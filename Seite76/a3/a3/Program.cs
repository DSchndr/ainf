using System;

namespace a3 {
    class Program {
        static void Main (string[] args) {
            //Spielfeld array erstellen & mit . füllen
            char[,] Spielfeld = new char[10, 10];
            for (int x = 0; x < 10; x++) {
                for (int y = 0; y < 10; y++) {
                    Spielfeld[x, y] = '.';
                }
            }
            char[,] Schiffe = new char[10, 10];

            setzenSchiffe (ref Schiffe);
            ausgebenSpielfeld (ref Spielfeld, true);

            //gameloop
            do {
                ausgebenSpielfeld (ref Spielfeld);
                schiessen (ref Spielfeld, ref Schiffe);
            } while (ende (ref Schiffe));
            Console.WriteLine("Spiel gewonnen! Blah blah blah...\n Programmierer ist hier pennen gegangen und hatte kein Bock mehr.");
        }

        static void ausgebenSpielfeld (ref char[, ] arr, bool redraw = false) {
            if (redraw) {
                //zahlen am rand setzen
                for (int x = 0; x < 10; x++) {
                    Console.SetCursorPosition (x, 0);
                    if (x == 0) {; } else if (x == 10) Console.Write ("0");
                    else Console.Write (x);
                }
                for (int y = 0; y < 10; y++) {
                    Console.SetCursorPosition (0, y);
                    if (y == 0) Console.Write (" ");
                    else if (y == 10) Console.Write ("0");
                    else Console.Write (y);
                }
            }
            //punkte im spielfeld setzen
            for (int x = 1; x < 10; x++) {
                for (int y = 1; y < 10; y++) {
                    Console.SetCursorPosition (x, y);
                    Console.Write (arr[x, y]);
                }
            }

        }
        static void setzenSchiffe (ref char[, ] arr) {
            arr[1, 2] = 'S';
            arr[5, 6] = 'S';
            arr[4, 3] = 'S';
        }
        static void schiessen (ref char[, ] SParr, ref char[, ] Sarr) {
            A : 
            Console.SetCursorPosition (0, 12);
            Console.Write ("X-Koordinate: ");
            String xs = Console.ReadLine ();
            Console.Write ("\nY-Koordinate: ");
            String ys = Console.ReadLine ();
            if (!Int32.TryParse (xs, out int x)) {
                goto A;
            }
            if (!Int32.TryParse (ys, out int y)) {
                goto A;
            }
            if (x > 9 || x < 0 || y > 9 || y < 0) {
                goto A;
            }
            if (Sarr[x, y] == 'S') {
                Sarr[x, y] = 'X';
                SParr[x, y] = 'X';
            } else {
                SParr[x, y] = '*';
            }

        }

        //Hat das array ein Schiff? -> loop weiter laufenlassen
        static bool ende (ref char[, ] arr) {
            bool ret = false;
            foreach (char c in arr) {
                if (c == 'S') ret = true;
            }
            return ret;
        }
    }
}