using System;

namespace _4gewinnt
{
    class Game
    {
        private int fieldx = 0, fieldy = 0; //do not change this. 
        private byte color = 1; //start color
        private bool loop = true;
        private byte tries = 42;

        public Game()
        {
            GameVariables.blockarr = new byte[7, 6]; //reset array
            //center game area
            GameSettings.offsetx = Console.WindowWidth / 2 - (7 * GameSettings.blockscale + 7) / 2;
            fieldx = 7 * GameSettings.blockscale + 7 + GameSettings.offsetx; fieldy = 6 * GameSettings.blockscale + 6 + GameSettings.offsety; //field size

            Console.Clear();
            foreach (string z in Titlearray) //draw title
            {
                Console.WriteLine(z);
            }
            drawgamearea();
            changeplayer();
            gameloop();
            winnermessage();
        }

        // Loop für das Spiel
        private void gameloop()
        {
            while (loop)
            {
                Console.SetCursorPosition(fieldx + 1, fieldy + 1); //workaround
                if (GameVariables.dumbai && color == 1)
                {
                    Random rng = new Random();
                    System.Threading.Thread.Sleep(1000); //wait 1 secs
                    paintblockw(rng.Next(6));
                    continue; //nutzereingabe überspringen
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            paintblockw(0);
                            break;
                        case ConsoleKey.D2:
                            paintblockw(1);
                            break;
                        case ConsoleKey.D3:
                            paintblockw(2);
                            break;
                        case ConsoleKey.D4:
                            paintblockw(3);
                            break;
                        case ConsoleKey.D5:
                            paintblockw(4);
                            break;
                        case ConsoleKey.D6:
                            paintblockw(5);
                            break;
                        case ConsoleKey.D7:
                            paintblockw(6);
                            break;
                    }
                }
                if (GameVariables.onlinegame) onlinegameupdate();
            }
        }

        private void onlinegame()
        {

        }
        private void onlinegameupdate()
        { /*
            int abstand = GameSettings.blockscale - 1;
            Console.SetCursorPosition(GameSettings.offsetx + 1, GameSettings.offsety - 1);
            for (int i = 1; i < 8; i++)
            {
                Console.Write("{0}%", "10");
                Console.SetCursorPosition(GameSettings.offsetx + 1 + (1 + GameSettings.blockscale) * i, GameSettings.offsety - 1);
            }*/
        }

        // Dies wird nach dem loop ausgeführt und gibt den gewinner an
        private void winnermessage()
        {
            string pl;
            if (color == 2)
            {
                if (GameVariables.dumbai) pl = "AI";
                else pl = "Rot";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                if (GameVariables.dumbai) pl = "(du)";
                else pl = "Blau";
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }

            if (tries > 0)
            {
                Console.SetCursorPosition(GameSettings.offsetx, 3);
                if (GameVariables.onlinegame) Console.Write("Team");
                else Console.Write("Spieler");
            }
            else pl = "Niemand";
            Console.Write(" {0} hat das Spiel gewonnen!\n", pl);
            Console.SetCursorPosition(GameSettings.offsetx, 4);
            Console.Write("Drücke Enter um in das Menü zu kommen");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                }
            }
            Console.ResetColor();
        }

        // Ändert den Spieler / die Farbe (Blau oder Rot) und gibt den Spieler der den nächsten zug machen soll an.
        private byte changeplayer(byte Color = 1)
        {
            string Player;
            if (Color == 1)
            {
                color = 2;
                if (GameVariables.dumbai) Player = "Du b";
                else Player = "Blau ";
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else
            {
                color = 1;
                if (GameVariables.dumbai) Player = "Die AI ";
                else Player = " Rot ";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.SetCursorPosition(GameSettings.offsetx, 3);
            Console.Write("{0}ist dran   ", Player);
            return color;
        }

        // Malt die Spielfläche in der die Blöcke gesetzt werden 
        public void drawgamearea()
        {
            // Horizontal
            for (int x = GameSettings.offsetx; x <= fieldx; x = x + 1)
            {
                for (int y = GameSettings.offsety; y <= fieldy; y = y + GameSettings.blockscale + 1)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("█");
                }
            }
            // Vertikal
            for (int x = GameSettings.offsetx; x <= fieldx; x = x + GameSettings.blockscale + 1)
            {
                for (int y = GameSettings.offsety; y <= fieldy; y = y + 1)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("█");
                }
            }
            // Text unter dem Spielfeld
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i <= 6; i++)
            {
                Console.SetCursorPosition(GameSettings.offsetx + (1 + GameSettings.blockscale) * i + GameSettings.blockscale / 2, fieldy + 1);
                Console.Write(i + 1);
            }
        }

        // Wrapper für paintblock, damit die blöcke an der untersten position platziert werden, der spieler gewechselt wird und geprüft wird ob das spiel nach dem zug gewonnen ist.
        public void paintblockw(int x)
        {
            // An der untersten Stelle beginnen und bis zum nächsten leeren feld hochgehen
            for (int i = 5; i >= 0; i--)
            {
                if (GameVariables.blockarr[x, i] == 0)
                {
                    //                    col row
                    GameVariables.blockarr[x, i] = color;
                    paintblock(x, i);
                    color = changeplayer(color);
                    if (GameLogic.check(x, i)) loop = false;
                    tries--;
                    if (tries == 0) loop = false;
                    break;
                }
            }
        }

        // Malt einen Block mit der Größe von blockscale an der angegeben position in dem spielfeld
        private void paintblock(int posx, int posy)
        {
            posx = GameSettings.offsetx + 1 + (1 + GameSettings.blockscale) * posx;
            posy = GameSettings.offsety + 1 + (1 + GameSettings.blockscale) * posy;

            if (color == 1) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.SetCursorPosition(posx, posy);
            for (int x = 0; x <= GameSettings.blockscale - 1; x++)
            {
                for (int y = 0; y <= GameSettings.blockscale - 1; y++)
                {
                    Console.SetCursorPosition(x + posx, y + posy);
                    Console.Write("█");
                }
            }
        }
        //TODO: Looks like shit
        private String[] Titlearray = new string[]
            {
                @"        4     ",
                @"        gewinnt",
            };
    }
}