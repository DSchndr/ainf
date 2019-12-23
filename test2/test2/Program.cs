using System;
using System.IO;
using System.Text;
using System.Diagnostics;
class Test2
{
    /* 
    
    *** Playground for random crap. ***
    
    */
    public static void Main()
    {
        //string path = @"/home/dennis/test1.sh";
        //decodeandlaunch("IyEvYmluL2Jhc2gKZWNobyAiSGFsbG8hIgpyZWFkCg==", path);
        Test2 test2 = new Test2();
        //test2.nyanneee();
        //test2.algo();
        Console.ReadLine();
        //test2.test();
        //nani();
        nani2();
        Console.ReadLine();
        

    }

    public static void nani2()
    {
        int minleft = 10, minright = 10;

        for (int row = 1; row <= 10; row++)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            for (int column = 1; column <= 19; column++)
            {

                if (column >= minleft && column <= minright)
                {

                    if (column % 4 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("o");
                    }
                    else
                    {
                        if (minleft == minright)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("^");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("#");
                        }

                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            minleft--;
            minright++;
            Console.ResetColor();

        }

        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("M");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("e");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("r");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("r");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("y");
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("C");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("h");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("i");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("s");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("t");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("m");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("a");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("s");
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(":3");

        Console.ResetColor();

        Console.ReadLine();
    }

    public static void nani()
    {
        int minleft = 10, minright = 10;

        for (int row = 1; row <= 10; row++)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            for (int column = 1; column <= 19; column++)
            {

                if (column >= minleft && column <= minright)
                {

                    if (column % 4 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("o");
                    }
                    else
                    {
                        if (minleft == minright)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("*");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("#");
                        }

                    }
                }

                else
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine(" ");
            minleft--;
            minright++;
            Console.ResetColor();

        }

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\nMe");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("rr");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("y ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("Ch");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("ris");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("tm");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("as ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(":3");

        Console.ResetColor();

        Console.ReadLine();


    }

    public void test()
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        for (int x = 0; x <= Console.WindowWidth; x++)
        {
            for (int y = 0; y <= Console.WindowHeight; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
            }
        }
    }

    private String[] nyanneee_str = new string[] {
        @"Nyan catu-chan",
        @"",
        @"___━*━___━━___━__*___━_*___┓━╭­­­­­━━━━╮",
        @"__*_━━___━━___━━*____━━___┗┓|:­­­­­:::::^---^",
        @"___━━___━*━___━━____━━*___━┗|:­­­­­:::|｡◕‿‿­­­­◕｡|",
        @"___*━__━━_*___━━___*━━___*━━╰O­­­­­--O---O--O ╯"

    };
    public void nyanneee()
    {
        foreach (string s in nyanneee_str)
        {
            Console.WriteLine(s);
        }
    }



    // decodeandlaunch("QGVjaG8gb2ZmDQplY2hvIGhhbGxvIDpE"); //schreibt zu c:\test.bat und führt aus
    // decodeandlaunch("QGVjaG8gb2ZmDQplY2hvIGhhbGxvIDpE", @"c:\hallo.bat"); //schreibt zu c:\hallo.bat und führt aus
    public static void decodeandlaunch(string b64string, string path = @"c:\test.bat")
    {
        File.WriteAllBytes(path, Convert.FromBase64String(b64string));

        Process process;
        ProcessStartInfo processInfo;
        //processInfo = new ProcessStartInfo("cmd.exe", "/c " + path);  //Windows
        processInfo = new ProcessStartInfo("xterm", "-hold -e " + path);          //Linux
        processInfo.CreateNoWindow = false;
        processInfo.UseShellExecute = false;

        process = Process.Start(processInfo);
        process.WaitForExit();
        File.Delete(path);
    }
}
