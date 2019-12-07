using System;
using System.Runtime.InteropServices;


namespace _4gewinnt
{
    class GameMenu
    {
        public int menu()
        {
            platformcheck();
            foreach (string s in Menutextarray)
            {
                Console.WriteLine(s);
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1: return 1; //launch offline game
                        case ConsoleKey.D2: return 2; //launch ai game
                        case ConsoleKey.D3: return 3; //launch online game
                        case ConsoleKey.D4:
                            //set field size
                            break;
                        case ConsoleKey.D5:
                            setBlocksize(); //set block size
                            return 0;
                        case ConsoleKey.D7: return -1;
                    }
                }
            }
        }
        private void setBlocksize()
        {
            Console.WriteLine("Press ESC to return to menu");
            while (true)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("blocksize: {0}x{0}     ", GameSettings.blockscale);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Add:
                        GameSettings.blockscale++;
                        break;
                    case ConsoleKey.Subtract:
                        GameSettings.blockscale--;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
        private static void platformcheck()
        {
            //check platform and print message, else resize window.

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Console.WriteLine("Linux/Macos detected. Please resize your console window manually.");
                while ((Console.WindowHeight < GameSettings.FieldSizeMinX) || (Console.WindowWidth < GameSettings.FieldSizeMinY))
                {
                    ;
                }
            }
            else
            {
                Console.SetWindowSize(GameSettings.FieldSizeMinX, GameSettings.FieldSizeMinY);
            }
            Console.Clear();
        }
        private String[] Menutextarray = new String[]
    {
                @"4 Gewinnt",
                @"",
                @"Spielmodus:",
                @"[1]: Offline gegen zweiten Spieler spielen",
                @"[2]: Offline gegen (sehr dumme) AI spielen",
                @"[3]: Online                        spielen //TODO",
                @"",
                @"Einstellungen:",
                @"[4]: Feldgröße    einstellen //TODO",
                @"[5]: Blockgröße   einstellen //hack",
                @"[6]: Spielregeln //TODO",
                @"[7]: Spiel beenden",
    };
    }
}