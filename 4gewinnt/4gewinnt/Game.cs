//TODO: Implement check to find out if the gamearea fits into the console; crashes game on windows

using System;
using System.Text;

namespace _4gewinnt
{
    class Game
    {
        private int fieldx = 0, fieldy = 0; //do not change this. 
        private byte color = 1; //start color
        private bool loop = true; //game ends if false
        private int tries = GameSettings.GameAreaX * GameSettings.GameAreaY;
        private int consolewidth, consoleheight; // initial window size
        private bool isonlinegame, isaigame, istutorial;
        private byte[,] blockarr = new byte[GameSettings.GameAreaX, GameSettings.GameAreaY];
        public Game(bool IsOnlineGame, bool IsAiGame, bool IsTutorial)
        {
            isonlinegame = IsOnlineGame;
            isaigame = IsAiGame;
            istutorial = IsTutorial;
            consoleheight = Console.WindowHeight;
            consolewidth = Console.WindowWidth;
            if (istutorial && (!isaigame || !isonlinegame)) tutorial();
            else if (istutorial && isaigame && isonlinegame) drawsomethingnice(); //normally impossible, so we draw something nice instead of letting the code do wierd things ^^
            else if (!istutorial)
            {
                //can be removed if ticktacktoe is not implemented in final version
                if ((GameSettings.GameAreaX == 3) && (GameSettings.GameAreaY == 3)) GameSettings.GameLogicDist = 3;
                else GameSettings.GameLogicDist = 4;

                draw();
                changeplayer();
                gameloop();
                winnermessage();
            }
        }

        #region Tutorial
        //TODO: polish this code area
        private void tutorial()
        {
            GameSettings.GameAreaX = 7; GameSettings.GameAreaY = 6;
            draw();
            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 2);
                        Console.Write("4 Gewinnt ist eigentlich garnicht so komplex.");
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 1);
                        Console.Write("Hier siehst du das 6*7 Spielfeld");
                        break;
                    case 1:
                        redraw();
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 2);
                        Console.Write("Du setzt die Blöcke indem du");
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 1);
                        Console.Write("die Tasten 1-7 drückst.");
                        break;
                    case 2:
                        redraw();
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 2);
                        Console.Write("Probiers aus!");
                        color = 2;
                        while (loop)
                        {
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
                        }
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 1);
                        Console.Write("Gut gemacht!");

                        break;
                    case 3:
                        blockarr[0, 5] = 1;
                        blockarr[1, 5] = 1;
                        blockarr[2, 5] = 1;
                        blockarr[3, 5] = 1;

                        redraw();
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 2);
                        Console.Write("Wenn du 4 Blöcke horizontal");
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 1);
                        Console.Write("gesetzt hast hast du das Spiel gewonnen!");
                        break;
                    case 4:
                        blockarr[1, 2] = 2;
                        blockarr[2, 3] = 2;
                        blockarr[3, 4] = 2;
                        blockarr[4, 5] = 2;

                        blockarr[6, 5] = 1;
                        blockarr[6, 4] = 1;
                        blockarr[6, 3] = 1;
                        blockarr[6, 2] = 1;
                        redraw();
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 2);
                        Console.Write("Das ganze geht auch");
                        Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 1);
                        Console.Write("Vertikal und Diagonal");
                        break;
                }
                waitforenter();
            }
            Console.SetCursorPosition(GameSettings.offsetx, GameSettings.offsety - 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Drücke [Enter] um in das Menü zu kommen!");
            waitforenter();
            Console.ResetColor();
        }
        #endregion

        #region Drawing
        private void draw()
        {
            int fails = 0;
        A:
            fails++;
            //center game area
            GameSettings.offsetx = Console.WindowWidth / 2 - (GameSettings.GameAreaX * GameSettings.blockscale + GameSettings.GameAreaX) / 2;
            fieldx = GameSettings.GameAreaX * GameSettings.blockscale + GameSettings.GameAreaX + GameSettings.offsetx; fieldy = GameSettings.GameAreaY * GameSettings.blockscale + GameSettings.GameAreaY + GameSettings.offsety; //field size

            // HACK: Set blockscale automatically
            if (GameSettings.autoblockscale)
            {
                if ((fieldx > Console.WindowWidth) || (fieldy + 1 > Console.WindowHeight))
                {
                    GameSettings.blockscale--;
                    goto A;
                }
                else if ((fieldy + 1 < Console.WindowHeight) && (fails <= 2))
                {
                    GameSettings.blockscale++;
                    goto A;
                }
            }

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
            if (!istutorial)
            {
                Console.WriteLine(new StringBuilder().Insert(0, "*** REDRAWING WINDOW ***\n", 8).ToString());
                System.Threading.Thread.Sleep(500);
            }
            draw();
            byte origc = color;
            for (int x = 0; x <= GameSettings.GameAreaX - 1; x++)
            {
                for (int y = 0; y <= GameSettings.GameAreaY - 1; y++)
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

            //BUG: bei 1x1 ist der text um 1 zu weit links 
            // Text unter dem Spielfeld
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < GameSettings.GameAreaX; i++)
            {
                Console.SetCursorPosition(GameSettings.offsetx + (1 + GameSettings.blockscale) * i + GameSettings.blockscale / 2 + 1, fieldy + 1);
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
            else if (color == 3) Console.ForegroundColor = ConsoleColor.DarkYellow;
            //else return;
            else Console.ResetColor();

            Console.SetCursorPosition(posx, posy);
            for (int x = 0; x <= GameSettings.blockscale - 1; x++)
            {
                for (int y = 0; y <= GameSettings.blockscale - 1; y++)
                {
                    Console.SetCursorPosition(x + posx, y + posy);
                    if (color == 0) Console.Write(" ");
                    else Console.Write("█");
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
                    paintblockw(rng.Next(GameSettings.GameAreaX));
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

        //Wartet bis enter gedrückt wird
        private void waitforenter()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                }
            }
        }

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
            waitforenter();
            Console.ResetColor();
        }

        // Wrapper für paintblock, damit die blöcke an der untersten position platziert werden, der spieler gewechselt wird und geprüft wird ob das spiel nach dem zug gewonnen ist.
        public void paintblockw(int x)
        {
            if ((x >= GameSettings.GameAreaX) || (x < 0)) return;
            if ((GameSettings.GameAreaX == 3) && (GameSettings.GameAreaY == 3)) { paintblockwttt(x); return; }
            // An der untersten Stelle beginnen und bis zum nächsten leeren feld hochgehen
            for (int i = GameSettings.GameAreaY - 1; i >= 0; i--)
            {
                if (blockarr[x, i] == 0)
                {
                    //      col row
                    blockarr[x, i] = color;
                    paintblock(x, i);
                    if (!istutorial)
                    {
                        color = changeplayer(color);
                    }
                    if (GameLogic.check(x, i, blockarr)) loop = false;
                    tries--;
                    if (tries == 0) loop = false;
                    break;
                }
            }
        }

        // tick-tack-toe painblock wrapper

        //todo: overwrite paintblockw with this when we are in "ttt mode"
        private void paintblockwttt(int x)
        {
            //todo: code cleanup & find bug that causes out of bounds & fix ai
            var tmpc = color;
            var lp = true;
            var y = 0;

            while (lp)
            {
                //gefärbte blöcke überspringen; return wenn keine felder mehr frei sind
                color = 3;
                if (blockarr[x, y] == 0) { paintblock(x, y); }
                else if (y == 2) return;
                else { y++; continue; }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if ((y > 0) && (blockarr[x, y - 1] == 0))
                            {
                                color = 0;
                                paintblock(x, y);
                                y--;
                            }
                            else if ((y == 2) && (blockarr[x, y - 2] == 0))
                            {
                                color = 0;
                                paintblock(x, y);
                                y -= 2;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (y < 2 && (blockarr[x, y + 1] == 0))
                            {
                                color = 0;
                                paintblock(x, y);
                                y++;
                            }
                            else if ((y == 0) && (blockarr[x, y + 2] == 0))
                            {
                                color = 0;
                                paintblock(x, y);
                                y += 2;
                            }
                            break;
                        case ConsoleKey.Enter:
                            lp = false;
                            color = tmpc;
                            paintblock(x, y);
                            blockarr[x, y] = tmpc;
                            continue;
                    }
                    color = 3;
                    paintblock(x, y);
                }
            }
            color = changeplayer(tmpc);
            if (GameLogic.check(x, y, blockarr)) loop = false;
            return;
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
            Console.Write($"{Player}ist dran   ");
            return color;
        }
        private void drawsomethingnice()
        {
            Console.Clear(); Console.Write(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("S2V5OiA=")));
            if (Console.ReadLine() == System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("dGh4"))) Console.WriteLine(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("RWFzdGVyZWdnIF5eCnRoeCB0bzogLi4u")));
            Console.WriteLine("\nPress [Enter] to continue! :)"); Console.ReadLine(); GameSettings.GameAreaX = 3;GameSettings.GameAreaY = 3;new Game(false, false, false);GameSettings.GameAreaX = 7; GameSettings.GameAreaY = 6;
            return;
        }

        //Title which gets drawn over the game area //TODO: Change to stringbuilder
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
