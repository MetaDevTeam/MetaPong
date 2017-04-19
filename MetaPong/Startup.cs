namespace MetaPong
{
    using CmdArt;
    using CmdArt.Screen;
    using PongElements;
    using PongElements.DrawElements;
    using PongElements.ElementsMovement;
    using System;
    using System.Threading;
    using PongElements.PrintElements;
    using Utilities;
    using Utilities.Enumeration;
    using Utilities.Input;
    using Utilities.ScreenElements;
    using Utilities.ScreenElements.Composit;

    class Startup
    {
        // General game constants
        private const int ScreenWidth = 130;
        private const int ScreenHeight = 40;
        private const int MaxPoints = 2;
        private const int Speed = 50;

        private static void HomeScreen(int width, int height)
        {
            // Setup screen
            int windowWidth = width; //Console.LargestWindowWidth; or 130
            int windowHeight = height; //Console.LargestWindowHeight; or 40

            Console.BufferWidth = windowWidth;
            Console.BufferHeight = windowHeight;
            Console.WindowWidth = windowWidth;
            Console.WindowHeight = windowHeight;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            // Create element containers
            var homeDecoration = new ScreenDecoration();
            var homeMenu = new Menu();

            // Set layout rows and columns
            int startColumn = (windowWidth / 2) - 5;
            int startRow = (windowHeight / 2) - 3;

            // player decorations
            var random = new Random();
            int playerHeight = 8;
            int player1Row = random.Next(1, windowHeight-playerHeight);
            int player2Row = random.Next(1, windowHeight-playerHeight);

            var playerOne = new PlayerO(player1Row,"Left");
            var playerTwo = new PlayerO(player2Row,"Right");

            // Ball
            int ballSize = 2;
            int ballRow = random.Next(1,windowHeight - ballSize);
            int ballHeight = random.Next(1, windowWidth - ballSize);
            BallO ball = new BallO(ballRow, ballHeight, ballSize);

            // Menu frame
            ScreenLayout menuFrame = Composer.GetBox(15, 10, startRow - 2, startColumn - 3);

            // Remder Logo
            RenderLogo(2, startColumn-25);

            // Add the decoration items to the screen
            homeDecoration.Add(menuFrame);
            homeDecoration.Add(playerOne);
            homeDecoration.Add(playerTwo);
            homeDecoration.Add(ball);
            homeDecoration.Add(new Label(0, startColumn + 4, $"{random.Next(0, 10)}-{random.Next(0, 10)}"));

            // Construct the menu
            homeMenu.Add(new MenuItem(startRow, startColumn, "1 PLAYER", Command.OnePlayer));
            homeMenu.Add(new MenuItem(startRow + 1, startColumn, "2 PLAYERS", Command.TwoPlayers));
            homeMenu.Add(new MenuItem(startRow + 2, startColumn, "OPTIONS", Command.Options));
            homeMenu.Add(new MenuItem(startRow + 3, startColumn, "SAVE GAME", Command.Save));
            homeMenu.Add(new MenuItem(startRow + 4, startColumn, "LOAD GAME", Command.Load));
            homeMenu.Add(new MenuItem(startRow + 5, startColumn, "EXIT", Command.Exit));

            Console.CursorVisible = false;

            homeDecoration.Print();
            homeMenu.Print();

            while (true)
            {
                // Keayboard funtionality
                var keyInput = new KeyboardInput();
                var command = keyInput.Listen();
                switch (command)
                {
                    case Command.MoveUp:
                        homeMenu.MoveUp();
                        homeMenu.Print();
                        break;
                    case Command.MoveDown:
                        homeMenu.MoveDown();
                        homeMenu.Print();
                        break;
                    case Command.Execute:
                        Command menuCommand = (homeMenu.GetSelected()).Command;
                        ExecCommand(menuCommand);
                        break;
                }
            }
        }

        static void ExecCommand(Command command)
        {
            switch (command)
            {
                case Command.OnePlayer:
                    RenderLogo(2, 35);
                    Thread.Sleep(1000);
                    RunPong(Speed,MaxPoints);
                    break;
                case Command.Exit:
                    Console.Clear();
                    Console.WriteLine("Exit successful!");
                    Environment.Exit(0);
                    break;
                case Command.HomeScreen:
                    //end game clear da go to home screen
                    Console.Clear();
                    ResetScore();
                    HomeScreen(ScreenWidth,ScreenHeight);

                    break;
            }
        }

        private static void RunPong(int speed, int maxPoints)
        {
            Console.Clear();

            int verticalMiddle = ScreenHeight/2 - 4;

            var playerOne = new PlayerO(verticalMiddle,"Left");
            var playerTwo = new PlayerBot(verticalMiddle,"Right", 60);
            var ball = new BallO(ScreenHeight / 2 - 1,ScreenWidth/2-1,2);

            playerOne.Print();
            playerTwo.Print();
            ball.Print();

            while (true)
            {
                // move first player
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        playerOne.MoveUp();
                        Console.Beep(40 * 100, 100);
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        playerOne.MoveDown();
                        Console.Beep(10 * 100, 100);
                    }
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        ExecCommand(Command.HomeScreen);
                    }
                }
                // move second player
                playerTwo.Tick(ball);

                // move ball
                ball.Tick();

                // - draw first player
                playerOne.Move();

                // - draw second player
                playerTwo.Move();

                // - draw ball
                ball.Move();

                // - print result
                PrintResults.PrintResult();

                if (PrintResults.firstPlayerResults == maxPoints 
                    || PrintResults.secondPlayerResults == maxPoints
                    )
                {
                    ResetScore();
                    break;
                }
                //------
                Thread.Sleep(speed);
            }

            HomeScreen(ScreenWidth,ScreenHeight);
        }

        private static void ResetScore()
        {
            PrintResults.firstPlayerResults = 0;
            PrintResults.secondPlayerResults = 0;
        }

        static void RenderLogo(int startRow, int startColumn)
        {
            string imageFile = "../../../Images/Code-Wizard.png";
            var screen = new TerminalScreen();

            var image = CmdArt.Images.Image.BuildFromImageFile(imageFile, new Size(62, 35));

            // Create a window at position (5,5) on the screen, with size 50x50
            var window = screen.CreateNewWindow(new Region(startColumn, startRow, 62, 35));

            // Set a source buffer in the window, big enough to hold the image
            // We want to focus on the region of the window at point (7, 4), where the size is
            // still 20x16
            var buffer = screen.BufferFactory.Create(image.Size);
            window.SetSourceBuffer(buffer, new Location(0, 0));

            // Render the image to the Window's buffer, then render the screen to the Console
            // including the window's buffer
            image.RenderTo(window.SourceBuffer);
            screen.Render(includeWindows: true);

            // reset colors after logo
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main()
        {
            HomeScreen(ScreenWidth,ScreenHeight);

            RunPong(Speed,MaxPoints);
        }
    }
}
