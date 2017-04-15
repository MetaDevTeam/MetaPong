namespace MetaPong
{
    using System;
    using System.Threading;
    using CmdArt;
    using CmdArt.Screen;
    using Utilities;
    using Utilities.ScreenElements;

    class Startup
    {
        static int firstPlayerPadSize = 7;
        static int secondPlayerPadSize = 7;
        static int ballPositionX = 5;
        static int ballPositionY = 5;
        static bool ballDirectionUp = true;
        static bool ballDirectionRight = true;
        static int firstPlayerPosition = 5;
        static int secondPlayerPosition = 5;
        static int firstPlayerResults = 0;
        static int secondPlayerResults = 0;
        static Random random = new Random();

        static void RemoveScrollBars()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

        }

        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintAtPosition(0, y, '[');
                PrintAtPosition(1, y, ']');
            }
        }

        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, ']');
                PrintAtPosition(Console.WindowWidth - 2, y, '[');
            }
        }

        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, 'O');
        }

        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        static void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write($"{firstPlayerResults}-{secondPlayerResults}");
        }

        static void SetInitialPosition()
        {
            firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
            SetBallOnStartPosition();
        }

        static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < Console.WindowHeight - firstPlayerPadSize)
            {
                firstPlayerPosition++;
            }
        }

        static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition--;
            }
        }

        static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < Console.WindowHeight - secondPlayerPadSize)
            {
                secondPlayerPosition++;
            }
        }

        static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }
        }

        static void MoveSecondPlayerBot()
        {
            int randomNum = random.Next(1, 101);

            if (randomNum <= 60)
            {
                if (ballDirectionUp == true)
                {
                    MoveSecondPlayerUp();
                }

                else
                {
                    MoveSecondPlayerDown();
                }
            }
        }

        static void SetBallOnStartPosition()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }

        static void MoveBall()
        {
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }

            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }

            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallOnStartPosition();
                ballDirectionRight = false;
                ballDirectionUp = true;
                firstPlayerResults++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("First Player Wins!");
                Console.ReadKey();
            }

            if (ballPositionX == 0)
            {
                SetBallOnStartPosition();
                ballDirectionRight = true;
                ballDirectionUp = true;
                secondPlayerResults++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Second Player Wins!");
                Console.ReadKey();
            }

            if (ballPositionX < 3)
            {
                if (ballPositionY >= firstPlayerPosition
                    && ballPositionY <= firstPlayerPosition + firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }

            if (ballPositionX >= Console.WindowWidth - 4)
            {
                if (ballPositionY >= secondPlayerPosition
                    && ballPositionY <= secondPlayerPosition + secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }

            if (ballDirectionUp)
            {
                ballPositionY--;
            }

            else
            {
                ballPositionY++;
            }

            if (ballDirectionRight)
            {
                ballPositionX++;
            }

            else
            {
                ballPositionX--;
            }
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

            int startColumn = (windowWidth / 2) - 5;
            int startRow = (windowHeight / 2) - 3;
            int playerHeight = 8;
            int player1Row = random.Next(1, windowHeight-playerHeight);
            int player2Row = random.Next(1, windowHeight-playerHeight);

            ScreenLayout menuFrame = Composer.GetBox(15, 10, startRow - 2, startColumn - 3);
            ScreenLayout playerOne = Composer.GetBox(2, playerHeight, player1Row, 0);
            ScreenLayout playerTwo = Composer.GetBox(2, playerHeight, player2Row, windowWidth-2);

            // Ball
            int ballSize = 2;
            int ballRow = random.Next(1,windowHeight - ballSize);
            int ballHeight = random.Next(1, windowWidth - ballSize);
            ScreenLayout ball = Composer.GetBox(2, 2, ballRow, ballHeight);

            optionsScreen.Add(menuFrame);
            optionsScreen.Add(playerOne);
            optionsScreen.Add(playerTwo);
            optionsScreen.Add(ball);
            optionsScreen.Add(new ScreenLabel(startRow, startColumn, "1 PLAYER"));
            optionsScreen.Add(new ScreenLabel(startRow + 1, startColumn, "2 PLAYERS"));
            optionsScreen.Add(new ScreenLabel(startRow + 2, startColumn, "OPTIONS"));
            optionsScreen.Add(new ScreenLabel(startRow + 3, startColumn, "SAVE GAME"));
            optionsScreen.Add(new ScreenLabel(startRow + 4, startColumn, "LOAD GAME"));
            optionsScreen.Add(new ScreenLabel(startRow + 5, startColumn, "EXIT"));
            optionsScreen.Add(new ScreenLabel(0, startColumn+4, $"{random.Next(0,10)}-{random.Next(0,10)}"));

            RenderLogo();

            Console.CursorVisible = false;

            optionsScreen.Print();

            Console.ReadKey(true);
        }

        static void RenderLogo()
        {
            string imageFile = "../../../Images/software-university-logo.jpg";
            var screen = new TerminalScreen();

            var image = CmdArt.Images.Image.BuildFromImageFile(imageFile, new Size(20, 25));

            // Create a window at position (5,5) on the screen, with size 50x50
            var window = screen.CreateNewWindow(new Region(50, 2, 20, 25));

            // Set a source buffer in the window, big enough to hold the image
            // We want to focus on the region of the window at point (7, 4), where the size is
            // still 20x16
            var buffer = screen.BufferFactory.Create(image.Size);
            window.SetSourceBuffer(buffer, new Location(0, 0));

            // Render the image to the Window's buffer, then render the screen to the Console
            // including the window's buffer
            image.RenderTo(window.SourceBuffer);
            screen.Render(includeWindows: true);

            Console.ReadKey(true);
        }

        static void Main(string[] args)
        {
            RunInterfaceDemo();

            RemoveScrollBars();
            SetInitialPosition();

            while (true)
            {
                // move first player
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveFirstPlayerDown();
                    }
                }
                // move second player
                MoveSecondPlayerBot();
                // move ball
                MoveBall();
                // redraw all
                // - clear all
                Console.Clear();
                // - draw first player
                DrawFirstPlayer();
                // - draw second player
                DrawSecondPlayer();
                // - draw ball
                DrawBall();
                // - print result
                PrintResult();
                //------
                Thread.Sleep(50);
            }
        }
    }
}
