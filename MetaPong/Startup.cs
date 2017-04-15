namespace MetaPong
{
    using PongElements;
    using PongElements.DrawElements;
    using PongElements.ElementsMovement;
    using System;
    using System.Threading;
    using Utilities.ScreenElements;

    class Startup
    {
        //static void RemoveScrollBars()
        //{
        //    Console.BufferHeight = Console.WindowHeight;
        //    Console.BufferWidth = Console.WindowWidth;
        //
        //}

        private static void RunInterfaceDemo()
        {
            // Setup screen
            int windowWidth = Console.LargestWindowWidth - 5;
            int windowHeight = Console.LargestWindowHeight - 5;


            Console.BufferWidth = windowWidth;
            Console.BufferHeight = windowHeight;
            Console.WindowWidth = windowWidth;
            Console.WindowHeight = windowHeight;
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

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

        static void Main(string[] args)
        {
            RunInterfaceDemo();

            //RemoveScrollBars();

            SetPosition.SetInitialPosition();

            while (true)
            {
                // move first player
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        PlayerMovement.MoveFirstPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        PlayerMovement.MoveFirstPlayerDown();
                    }
                }
                // move second player
                PlayerMovement.MoveSecondPlayerBot();

                // move ball
                BallMovement.MoveBall();

                // redraw all
                // - clear all
                Console.Clear();

                // - draw first player
                Player.DrawFirstPlayer();

                // - draw second player
                Player.DrawSecondPlayer();

                // - draw ball
                Ball.DrawBall();

                // - print result
                PrintResults.PrintResult();

                //------
                Thread.Sleep(50);
            }
        }
    }
}
