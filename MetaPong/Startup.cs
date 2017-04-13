namespace MetaPong
{
    using System;
    using Utilities.ScreenElements;

    class Startup
    {
        static void Main(string[] args)
        {
            RunInterfaceDemo();
        }

        private static void RunInterfaceDemo()
        {
// Setup screen
            int windowWidth = Console.LargestWindowWidth - 5;
            int windowHeight = Console.LargestWindowHeight - 5;


            Console.BufferWidth = windowWidth;
            Console.BufferHeight = windowHeight;
            Console.WindowWidth = windowWidth;
            Console.WindowHeight = windowHeight;

            var optionsScreen = new ScreenGroup();

            var startColumn = (windowWidth / 2) - 5;
            var startRow = (windowHeight / 2) - 3;

            optionsScreen.Add(new ScreenLable(startRow, startColumn, "1 PLAYER"));
            optionsScreen.Add(new ScreenLable(startRow + 1, startColumn, "2 PLAYERS"));
            optionsScreen.Add(new ScreenLable(startRow + 2, startColumn, "OPTIONS"));
            optionsScreen.Add(new ScreenLable(startRow + 3, startColumn, "SAVE GAME"));
            optionsScreen.Add(new ScreenLable(startRow + 4, startColumn, "LOAD GAME"));
            optionsScreen.Add(new ScreenLable(startRow + 5, startColumn, "EXIT"));

            optionsScreen.Print();

            Console.ReadKey(true);
        }
    }
}
