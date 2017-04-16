
namespace MetaPong.PongElements
{
    using System;
    using Utilities;

    public class Player
    {
        public static int firstPlayerPadSize = 13;
        public static int secondPlayerPadSize = 13;
        public static int firstPlayerPosition = 5;
        public static int secondPlayerPosition = 5;

        public static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintPosition.PrintAtPosition(0, y, '║');
                PrintPosition.PrintAtPosition(1, y, '║');
            }
        }

        public static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintPosition.PrintAtPosition(Console.WindowWidth - 1, y, '║');
                PrintPosition.PrintAtPosition(Console.WindowWidth - 2, y, '║');
            }
        }
    }
}
