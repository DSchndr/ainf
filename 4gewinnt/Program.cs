using System;

namespace _4gewinnt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //unicode > ascii
            GameMenu gamemenu = new GameMenu();

            while (true)
            {
                Game game = new Game();
                switch (gamemenu.menu())
                {
                    case 1: break;
                    case 2:
                        GameVariables.dumbai = true;
                        break;
                    case 3:
                        GameVariables.onlinegame = true;
                        break;
                    case -1: return;
                }
                game.startgame();
                GameVariables.dumbai = false;
                GameVariables.onlinegame = false;
            }
        }
    }

    static class GameSettings
    {
        public static int FieldSizeMinX = 50;
        public static int FieldSizeMinY = 50;
        public static int blockscale = 4; //1: 1x1; 2: 2x2; 3: 3x3;...
        public static int offsetx = 4, offsety = 6; //sets offset for game area

    }
    static class GameVariables
    {
        public static byte[,] blockarr = new byte[7, 6];
        public static bool onlinegame = false;
        public static bool dumbai = false;
    }
}
