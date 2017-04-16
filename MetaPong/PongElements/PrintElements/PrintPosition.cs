
namespace MetaPong.PongElements
{
    using System;

    public class PrintPosition
    {
        public static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
