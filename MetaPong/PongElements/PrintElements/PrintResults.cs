namespace MetaPong.PongElements.PrintElements
{
    using System;

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
