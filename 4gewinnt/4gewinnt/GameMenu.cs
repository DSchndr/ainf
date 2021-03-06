using System.Text;
using System;
using System.Runtime.InteropServices;

namespace _4gewinnt
{
    class GameMenu
    {
        public GameMenu()
        {
            platformcheck();

        A:
            Console.Clear();
            Console.WriteLine(Menutext);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1: new Game(false, false, false); break; //offline game
                        case ConsoleKey.D2: new Game(false, true,  false); break; //ai game
                        case ConsoleKey.D3: new Game(true,  false, false); break; //online game
                        case ConsoleKey.E:  new Game(true,  true,  true ); break; //buggy game
                        case ConsoleKey.D4: setFieldsize(); break; //set field size
                        case ConsoleKey.D5: setBlocksize(); break; //set block size
                        case ConsoleKey.D6: new Game(false, false, true); break;  //tutorial "game"
                        case ConsoleKey.D7: goto B;
                    }
                    goto A;
                }
            }

        B:
            return;
        }
        private void setFieldsize()
        {
            Console.WriteLine("Press ESC to return to menu | Press Left/Right to change the X size and Up/Down to change the Y size");
            while (true)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"fieldsize: x: {GameSettings.GameAreaX} | y: {GameSettings.GameAreaY}");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (GameSettings.GameAreaY < 9) GameSettings.GameAreaY++;
                        break;
                    case ConsoleKey.DownArrow:
                        if (GameSettings.GameAreaY > 4) GameSettings.GameAreaY--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (GameSettings.GameAreaX < 9) GameSettings.GameAreaX++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (GameSettings.GameAreaX > 4) GameSettings.GameAreaX--;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        // Setzt die Größe der Blöcke in dem Spiel
        private void setBlocksize()
        {
            GameSettings.autoblockscale = false;
            Console.WriteLine("Press ESC to return to menu | Be warned: this can crash the game on windows");
            while (true)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("blocksize: {0}x{0}   ", GameSettings.blockscale);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Add:
                        if (GameSettings.blockscale < 20) GameSettings.blockscale++;
                        break;
                    case ConsoleKey.Subtract:
                        if (GameSettings.blockscale > 0) GameSettings.blockscale--;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        /*
        C# kann die Größe der Console unter linux und macos nicht ändern.
        Deswegen muss dies der Nutzer machen.
        */
        private static void platformcheck()
        {
            //check platform and print message, else resize window.

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Console.WriteLine("Linux/Macos detected. Please resize your console window manually.");
                // worked on .net core 2.2
                /*while ((Console.WindowHeight < GameSettings.FieldSizeMinX) || (Console.WindowWidth < GameSettings.FieldSizeMinY))
                {
                    ;
                }*/
                Console.ReadLine();
            }
            else
            {
                //Console.SetWindowSize();
                Console.SetWindowSize(GameSettings.FieldSizeMinX, GameSettings.FieldSizeMinY);
            }
            Console.Clear();
        }
        private StringBuilder Menutext = new StringBuilder
    (
                "4 Gewinnt\n" +
                "\n" +
                "Spielmodus: \n" +
                "[1]: Offline gegen zweiten Spieler spielen\n" +
                "[2]: Offline gegen (sehr dumme) AI spielen\n" +
                "[3]: Online                        spielen //TODO \n" +
                "\n" +
                "Einstellungen: \n" +
                "[4]: Feldgröße    einstellen \n" +
                "[5]: Blockgröße   einstellen //hack \n" +
                "[6]: Spielregeln \n" +
                "[7]: Spiel beenden \n"
    );



    }

}