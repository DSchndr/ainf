using System;

namespace _4gewinnt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //unicode > ascii
            Console.CursorVisible = false;

            //Crude "crash handler"
            try { GameMenu gamemenu = new GameMenu(); }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Excuse moi!\nThe game has crashed :/\n\nSend this to the developer:\n");
                Console.WriteLine(ex.ToString());
            }
            //GameMenu gamemenu = new GameMenu();
        }
    }

    static class GameSettings
    {
        public static int FieldSizeMinX = 45;
        public static int FieldSizeMinY = 60; 
        public static int GameAreaX = 7; //9 ist das limit
        public static int GameAreaY = 6; //? ist das limit
        public static bool autoblockscale = true;
        public static int blockscale = 6; //1: 1x1; 2: 2x2; 3: 3x3;...
        public static int offsetx = 4, offsety = 8; //sets offset for game area

    }
}
