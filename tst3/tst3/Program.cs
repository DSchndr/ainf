using System;

namespace tst3
{
    class Program
    {
        static void Main(string[] args)
        {
        	
        	int b;
            do {
            	Console.WriteLine("Betrag eingeben: ");
            	b = Convert.ToInt16(Console.ReadLine());
            } while ((b<=0) || (b>=100));
            int f = b/5;
            int e = (b%5)/2;
            int z = ((b%5)%2);
            Console.WriteLine("f: {0}");
        }
    }
}
