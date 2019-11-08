using System;

namespace a1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Zahl 1: ");
                int a = Convert.ToInt16(Console.ReadLine());
                Console.Write("Zahl 2: ");
                int b = Convert.ToInt16(Console.ReadLine());
                Console.Write("Operation: ");
                char c = Convert.ToChar(Console.ReadLine());
                mathe(a, b, c);
            }
        }
        static void mathe(int a, int b, char c)
        {
            int tmp = 0;
            switch (c)
            {
                case '+':
                    tmp = a + b;
                    break;
                case '-':
                    tmp = a - b;
                    break;
                case '*':
                    tmp = a * b;
                    break;
                case '/':
                    tmp = a / b;
                    break;
                case '0':
                    System.Environment.Exit(0);
                    return;
            }
            Console.WriteLine(tmp);
        }
    }
}
