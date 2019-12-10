using System.Text;
using System;
using System.Runtime.InteropServices;

namespace _4gewinnt
{
    class GameMenu
    {
        public GameMenu()
        {
            Game game = null;

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
                        case ConsoleKey.D1: goto C; //launch offline game
                        case ConsoleKey.D2: GameVariables.dumbai = true; goto C; //launch ai game
                        case ConsoleKey.D3: GameVariables.onlinegame = true; goto C; //launch online game
                        case ConsoleKey.D4:
                            //set field size
                            goto A;
                        case ConsoleKey.D5:
                            setBlocksize(); //set block size
                            goto A;
                        case ConsoleKey.D6:
                            tutorial();
                            goto A;
                        case ConsoleKey.D7: goto B;
                    }
                }
            }

        B:
            return;

        C:
            game = new Game();
            GameVariables.dumbai = false;
            GameVariables.onlinegame = false;
            goto A;
        }

        private void tutorial() {

        }

        // Setzt die Größe der Blöcke in dem Spiel
        private void setBlocksize()
        {
            Console.WriteLine("Press ESC to return to menu");
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
                "[4]: Feldgröße    einstellen //TODO \n" +
                "[5]: Blockgröße   einstellen //hack \n" +
                "[6]: Spielregeln //TODO \n" +
                "[7]: Spiel beenden \n"
    );



    }

}