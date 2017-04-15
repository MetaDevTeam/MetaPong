
namespace MetaPong.PongElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PrintResults
    {
        public static int firstPlayerResults = 0;
        public static int secondPlayerResults = 0;
        
        public static void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write($"{firstPlayerResults}-{secondPlayerResults}");
        }
    }
}
