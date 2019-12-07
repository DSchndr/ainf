using System;

namespace _4gewinnt
{

    class Game
    {
        private int fieldx = 0; int fieldy = 0; //do not change this. 
        private byte color = 1; //start color
        private bool loop = true; //replace with isgamewon
        private byte tries = 42;

        public void startgame()
        {
            GameVariables.blockarr = new byte[7, 6]; //reset array
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

        void gameloop()
        {
            while (loop)
            {
                Console.SetCursorPosition(fieldx + 1, fieldy + 1); //workaround
                if (GameVariables.dumbai && color == 1)
                {
                    Random rng = new Random();
                    System.Threading.Thread.Sleep(1000); //wait 1 secs
                    paintblock2(rng.Next(6));
                    continue;
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            paintblock2(0);
                            break;
                        case ConsoleKey.D2:
                            paintblock2(1);
                            break;
                        case ConsoleKey.D3:
                            paintblock2(2);
                            break;
                        case ConsoleKey.D4:
                            paintblock2(3);
                            break;
                        case ConsoleKey.D5:
                            paintblock2(4);
                            break;
                        case ConsoleKey.D6:
                            paintblock2(5);
                            break;
                        case ConsoleKey.D7:
                            paintblock2(6);
                            break;
                    }
                }
                if (GameVariables.onlinegame) onlinegameupdate();
            }
        }

        public void onlinegame()
        {

        }
        public void onlinegameupdate()
        {
            int abstand = GameSettings.blockscale - 1;
            Console.SetCursorPosition(GameSettings.offsetx + 1, GameSettings.offsety - 1);
            for (int i = 1; i < 8; i++)
            {
                Console.Write("{0}%", "10");
                Console.SetCursorPosition(GameSettings.offsetx + 1 + (1 + GameSettings.blockscale) * i, GameSettings.offsety - 1);
            }
        }

        void winnermessage()
        {
            Console.SetCursorPosition(0, 3);
            string pl;
            if (color == 2)
            {
                if (GameVariables.dumbai) pl = "AI";
                else pl = "Rot";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                pl = "Blau";
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }

            if (GameVariables.onlinegame) Console.Write("Team");
            else Console.Write("Spieler");
            Console.Write(" {0} hat das Spiel gewonnen!\nDrücke Enter um in das Menü zu kommen\n", pl);
            Console.ReadLine();
            Console.ResetColor();
        }
        byte changeplayer(byte Color = 1)
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
                Player = " Rot ";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.SetCursorPosition(4, 3);
            Console.Write("{0}ist dran ", Player);
            return color;
        }

        void drawgamearea()
        {
            for (int x = GameSettings.offsetx; x <= fieldx; x = x + 1)
            {
                for (int y = GameSettings.offsety; y <= fieldy; y = y + GameSettings.blockscale + 1)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("█");
                }
            }

            for (int x = GameSettings.offsetx; x <= fieldx; x = x + GameSettings.blockscale + 1)
            {
                for (int y = GameSettings.offsety; y <= fieldy; y = y + 1)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("█");
                }
            }
        }

        // Wrapper für paintblock, damit die blöcke an der untersten position platziert werden, der spieler gewechselt wird und geprüft wird ob das spiel nach dem zug gewonnen ist.
        void paintblock2(int x)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (GameVariables.blockarr[x, i] == 0)
                {
                    GameVariables.blockarr[x, i] = color;
                    paintblock(x, i);
                    color = changeplayer(color);
                    if (GameLogic.checkfield(x, i)) { loop = false; }
                    tries--;
                    if (tries == 0)
                    {
                        loop = false;
                        Console.WriteLine("Unentschieden"); //fixme
                        Console.ReadKey();
                        return;
                    }
                    break;
                }
            }
        }
        void paintblock(int posx, int posy)
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