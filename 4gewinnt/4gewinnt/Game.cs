using System;
using System.Text;

namespace _4gewinnt
{
    class Game
    {
        private int fieldx = 0, fieldy = 0; //do not change this. 
        private byte color = 1; //start color
        private bool loop = true; //game ends if false
        private byte tries = 42; // we have 7*6 tries
        private int consolewidth, consoleheight; // initial window size
        private bool isonlinegame, isaigame;
        private static byte[,] blockarr = new byte[7, 6];

        public Game(bool IsOnlineGame, bool IsAiGame)
        {
            isonlinegame = IsOnlineGame;
            isaigame = IsAiGame;
            consoleheight = Console.WindowHeight;
            consolewidth = Console.WindowWidth;
            draw();
            changeplayer();
            gameloop();
            winnermessage();
        }

        #region Drawing
        private void draw()
        {
            //center game area
            GameSettings.offsetx = Console.WindowWidth / 2 - (7 * GameSettings.blockscale + 7) / 2;
            fieldx = 7 * GameSettings.blockscale + 7 + GameSettings.offsetx; fieldy = 6 * GameSettings.blockscale + 6 + GameSettings.offsety; //field size

            Console.Clear();
            Console.ResetColor();
            foreach (string z in Titlearray) //draw title
            {
                if (Console.WindowWidth < 73) { Console.WriteLine("4 Gewinnt"); break; } //fenster zu klein
                else Console.SetCursorPosition(Console.WindowWidth / 2 - Titlearray[0].Length / 2, Console.CursorTop);
                Console.WriteLine(z);
            }
            drawgamearea();
        }
        private void redraw()
        {
            //Todo: change blocksize so that blocks fit into console
            consoleheight = Console.WindowHeight;
            consolewidth = Console.WindowWidth;
            Console.Clear();
            Console.WriteLine(new StringBuilder().Insert(0, "*** RESIZING WINDOW ***\n", 8).ToString());
            System.Threading.Thread.Sleep(500);
            draw();
            byte origc = color;
            for (int x = 0; x <= 6; x++)
            {
                for (int y = 0; y <= 5; y++)
                {
                    color = blockarr[x, y];
                    paintblock(x, y);
                }
            }
            color = origc;
        }

        // "Malt" die Spielfläche in der die Blöcke gesetzt werden 
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

        // Malt einen Block mit der Größe von blockscale an der angegeben position in dem spielfeld
        private void paintblock(int posx, int posy)
        {
            posx = GameSettings.offsetx + 1 + (1 + GameSettings.blockscale) * posx;
            posy = GameSettings.offsety + 1 + (1 + GameSettings.blockscale) * posy;

            if (color == 1) Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (color == 2) Console.ForegroundColor = ConsoleColor.DarkBlue;
            else return;

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
        #endregion

        #region Gameloop

        // Loop für das Spiel
        private void gameloop()
        {
            while (loop)
            {
                //Größe der Console hat sich verändert -> redraw
                if (!(Console.WindowHeight == consoleheight) || !(Console.WindowWidth == consolewidth)) redraw();
                Console.SetCursorPosition(fieldx + 1, fieldy + 1); //workaround

                #region AI
                //BUG: Spiel *kann* sich aufhängen wenn der "rng" immer den gleichen zahlenbereich liefert der nicht gesetzt werden kann.
                //TODO: Inteligentere AI ~Mephi
                if (isaigame && color == 1)
                {
                    Random rng = new Random();
                    System.Threading.Thread.Sleep(1000); //wait 1 sec
                    paintblockw(rng.Next(6));
                    continue; //nutzereingabe überspringen
                }
                #endregion
                
                #region Userinput
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (char.IsDigit(key.KeyChar)) // 0 - 9
                    {
                        paintblockw(int.Parse(key.KeyChar.ToString()) - 1);
                    }
                    else if (key.Key == ConsoleKey.Escape) //Andere taste
                    {
                        loop = false;
                        tries = 0;
                    }
                }
                #endregion
                if (isonlinegame) onlinegameupdate();
            }
        }
        #endregion

        #region OnlineFun
        //TODO
        private void onlinegame()
        {

        }
        private void onlinegameupdate()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i <= 6; i++)
            {
                Console.SetCursorPosition(GameSettings.offsetx + (1 + GameSettings.blockscale) * i + GameSettings.blockscale / 2, GameSettings.offsety - 1);
                Console.Write("0%");
            }
        }
        #endregion

        #region Utils
        // Dies wird nach dem loop ausgeführt und gibt den gewinner an
        private void winnermessage()
        {
            string pl;
            if (color == 2)
            {
                if (isaigame) pl = "AI";
                else pl = "Rot";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                if (isaigame) pl = "(du)";
                else pl = "Blau";
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }

            Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 2);
            if (tries > 0)
            {
                if (isonlinegame) Console.Write("Team");
                else Console.Write("Spieler");
            }
            else pl = "Niemand";
            Console.Write($" {pl} hat das Spiel gewonnen!\n");
            Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Drücke [Enter] um in das Menü zu kommen!");
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

        // Wrapper für paintblock, damit die blöcke an der untersten position platziert werden, der spieler gewechselt wird und geprüft wird ob das spiel nach dem zug gewonnen ist.
        public void paintblockw(int x)
        {
            if ((x >= 7) || (x < 0)) return;
            // An der untersten Stelle beginnen und bis zum nächsten leeren feld hochgehen
            for (int i = 5; i >= 0; i--)
            {
                if (blockarr[x, i] == 0)
                {
                    //      col row
                    blockarr[x, i] = color;
                    paintblock(x, i);
                    color = changeplayer(color);
                    if (GameLogic.check(x, i, blockarr)) loop = false;
                    tries--;
                    if (tries == 0) loop = false;
                    break;
                }
            }
        }

        // Ändert den Spieler / die Farbe (Blau oder Rot) und gibt den Spieler der den nächsten zug machen soll an.
        private byte changeplayer(byte Color = 1)
        {
            string Player = "";
            if (Color == 1)
            {
                color = 2;
                if (isaigame) Player = "Du b";
                else Player = "Blau ";
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else if (Color == 2)
            {
                color = 1;
                if (isaigame) Player = "Die AI ";
                else Player = " Rot ";
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else throw new Exception("Invalid color for changeplayer()");
            if (isonlinegame) Player = "Team " + Player;
            Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 2);
            Console.Write("{0}ist dran   ", Player);
            return color;
        }

        //Title which gets drawn over the game area
        private String[] Titlearray = new string[]
            {
                @"██╗  ██╗     ██████╗ ███████╗██╗    ██╗██╗███╗   ██╗███╗   ██╗████████╗",
                @"██║  ██║    ██╔════╝ ██╔════╝██║    ██║██║████╗  ██║████╗  ██║╚══██╔══╝",
                @"███████║    ██║  ███╗█████╗  ██║ █╗ ██║██║██╔██╗ ██║██╔██╗ ██║   ██║   ",
                @"╚════██║    ██║   ██║██╔══╝  ██║███╗██║██║██║╚██╗██║██║╚██╗██║   ██║   ",
                @"     ██║    ╚██████╔╝███████╗╚███╔███╔╝██║██║ ╚████║██║ ╚████║   ██║   ",
                @"     ╚═╝     ╚═════╝ ╚══════╝ ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝  ╚═══╝   ╚═╝   "
            };
        #endregion
    }
}