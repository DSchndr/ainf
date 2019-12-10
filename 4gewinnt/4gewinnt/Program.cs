using System;

namespace _4gewinnt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //unicode > ascii
            
            try { GameMenu gamemenu = new GameMenu();}
            catch (Exception ex){
                Console.Clear();
                Console.WriteLine("Excuse moi!\nThe game has crashed :/\n\nSend this to the developer:\n");
                Console.WriteLine(ex.ToString());
            }
            //GameMenu gamemenu = new GameMenu();
        }
    }

    static class GameSettings
    {
        public static int FieldSizeMinX = 50;
        public static int FieldSizeMinY = 50;
        public static int blockscale = 6; //1: 1x1; 2: 2x2; 3: 3x3;...
        public static int offsetx = 4, offsety = 6; //sets offset for game area

    }
    static class GameVariables
    {
        public static byte[,] blockarr; //= new byte[7, 6];
        public static bool onlinegame = false;
        public static bool dumbai = false;
    }
}
