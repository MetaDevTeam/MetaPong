﻿namespace MetaPong
{
    using CmdArt;
    using CmdArt.Screen;
    using PongElements.GameObjects;
    using System;
    using System.Threading;
    using PongElements;
    using Utilities;
    using Utilities.Enumeration;
    using Utilities.Input;
    using Utilities.ScreenElements;
    using Utilities.ScreenElements.Composit;
    using Data;
    using Data.ImportData;
    using System.Linq;

    public class Startup
    {
        // General game constants
        public const int ScreenWidth = 130;
        public const int ScreenHeight = 40;
        public const int MaxPoints = 5;
        public const int Speed = 50;
        static string username = "";

        public static void HomeScreen(MetaPongContext context, int width, int height)
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

            var playerOne = new Player(player1Row,"Left","");
            var playerTwo = new PlayerBot(player2Row,"Right",100);

            // Ball
            int ballSize = 2;
            int ballRow = random.Next(1,windowHeight - ballSize);
            int ballHeight = random.Next(1, windowWidth - ballSize);
            Ball ball = new Ball(ballRow, ballHeight, ballSize);

            // Menu frame
            MovingElement menuFrame = Composer.GetBox(15, 10, startRow - 2, startColumn - 3);

            // Remder Logo
            RenderLogo(2, startColumn-25);

            // Add the decoration items to the screen
            homeDecoration.Add(menuFrame);
            homeDecoration.Add(playerOne);
            homeDecoration.Add(playerTwo);
            homeDecoration.Add(ball);
            homeDecoration.Add(new Label(0, startColumn + 4, $"{random.Next(0, 10)}-{random.Next(0, 10)}"));

            // Construct the menu
            homeMenu.Add(new MenuItem(startRow, startColumn, "NEW GAME", Command.NewGame));
            homeMenu.Add(new MenuItem(startRow + 1, startColumn, "ADD USER", Command.AddUser));
            homeMenu.Add(new MenuItem(startRow + 2, startColumn, "LOAD USER", Command.LoadUser));
            homeMenu.Add(new MenuItem(startRow + 3, startColumn, "OPTIONS", Command.Options));
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
                        ExecCommand(context, menuCommand);
                        break;
                }
            }
        }

        public static void ExecCommand(MetaPongContext context, Command command)
        {
            

            switch (command)
            {
                case Command.NewGame:
                    if (!context.Users.Any(u => u.Username == Startup.username))
                    {
                        var meserge = "Please Load/Create user!";
                        Console.WriteLine(meserge);
                        Console.ReadKey(true);
                        HomeScreen(context, Startup.ScreenWidth, Startup.ScreenHeight);
                    }
                    else
                    {
                        RenderLogo(2, 35);
                        Thread.Sleep(1000);
                        RunPong(context, Speed, MaxPoints);
                    }
                    break;
                case Command.AddUser:
                    var alert = new Input(ScreenHeight / 2, ScreenWidth / 2, "Add Username:", 15);
                    alert.Print();
                    var username = Console.ReadLine();
                    Import.ImportUser(context, username);
                    HomeScreen(context, ScreenWidth, ScreenHeight);
                    break;
                case Command.LoadUser:
                    var loadAlert = new Input(ScreenHeight / 2, ScreenWidth / 2, "Load User:", 15);
                    loadAlert.Print();
                    var user = Console.ReadLine();
                    var result = Import.GetUser(context, user);
                    var mesege = result[0];
                    if (result.Count == 2)
                    {
                        Startup.username = result[1];
                    }
                    var resultAlert = new Alert(ScreenHeight / 2, ScreenWidth / 2, mesege);
                    resultAlert.Print();
                    Console.ReadKey(true);
                    HomeScreen(context, ScreenWidth, ScreenHeight);
                    break;
                case Command.Exit:
                    Console.Clear();
                    Console.WriteLine("Exit successful!");
                    Environment.Exit(0);
                    break;
                case Command.HomeScreen:
                    //end game clear da go to home screen
                    Console.Clear();
                    HomeScreen(context, ScreenWidth,ScreenHeight);
                    break;
            }
        }

        public static void RunPong(MetaPongContext context, int speed, int maxPoints)
        {
            const int verticalMiddle = ScreenHeight / 2;
            const int playerMiddle = verticalMiddle - 4;

            var playerOne = new Player(playerMiddle,"Left", Startup.username);
            var playerTwo = new PlayerBot(playerMiddle,"Right", 60);

            var game = new GameController(context, playerOne, playerTwo, speed, maxPoints);

            game.Load(context);
        }

        public static void RenderLogo(int startRow, int startColumn)
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

            var context = new MetaPongContext();
            //context.Database.Initialize(true);

            ////User for test.
            //string user = "Mitko";
            //string user1 = "Zlatio";
            //string user2 = "Pesho";
            //string user3 = "Ginka";

            //Import.ImportUser(context, user);
            //Import.ImportUser(context, user1);
            //Import.ImportUser(context, user2);
            //Import.ImportUser(context, user3);

            ////Game for test.

            //Import.ImportGame(context, true, user);
            //Import.ImportGame(context, false, user1);
            //Import.ImportGame(context, true, user2);
            //Import.ImportGame(context, false, user3);

            HomeScreen(context, ScreenWidth,ScreenHeight);

            RunPong(context, Speed,MaxPoints);
            
        }
    }
}
