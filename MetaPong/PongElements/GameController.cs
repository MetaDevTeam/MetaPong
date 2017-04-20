namespace MetaPong.PongElements
{
    using System;
    using System.Threading;
    using GameObjects;
    using Utilities.Enumeration;
    using Utilities.ScreenElements;
    using Utilities.ScreenElements.Composit;
    using Data.ImportData;
    using Data;

    public class GameController
    {
        private int _verticalMiddle;
        private int _horizontalMiddle;
        private Label _score;
        private int _speed;

        /// <summary>
        /// Initializes a new instance of the MetaPong game.<see cref="GameController"/> class.
        /// </summary>
        /// <param name="playerOne">The first player, should be controlled by user.</param>
        /// <param name="playerTwo">The second player controlled by a bot. </param>
        /// <param name="speed">Larger values make the game slower.</param>
        /// <param name="maxScore">Defines the score at which the game ends.</param>
        public GameController(MetaPongContext context, Player playerOne, PlayerBot playerTwo, int speed=50, int maxScore=10)
        {
            
            // set players
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            // set middle point in game
            _verticalMiddle = Console.BufferHeight / 2;
            _horizontalMiddle = Console.BufferWidth / 2;

            // create a ball
            Ball = new Ball(_verticalMiddle, _horizontalMiddle, 2);

            // scre lable
            Score = new Label(0, _horizontalMiddle - 1, $"{PlayerOne._score}-{PlayerTwo._score}");

            _speed = speed;
            MaxScore = maxScore;
            Context = context;
        }

        public MetaPongContext Context { get; set; }
        public Player PlayerOne { get; set; }
        public PlayerBot PlayerTwo { get; set; }
        public Ball Ball { get; set; }
        public Label Score { get; set; }
        public int MaxScore { get; set; }

        public void Load(MetaPongContext context)
        {
            Console.Clear();
            PlayerOne.Print();
            PlayerTwo.Print();
            Ball.Print();

            while (true)
            {
                // move first player
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        PlayerOne.MoveUp();
                        //Console.Beep(40 * 100, 100);
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        PlayerOne.MoveDown();
                        //Console.Beep(10 * 100, 100);
                    }
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        bool playerWin = PlayerOne.Score == MaxScore;

                        int scoreDiference = MaxScore - PlayerOne.Score;

                        Import.ImportGame(context, playerWin, PlayerOne.Username, scoreDiference);
                        ExecCommand(Command.HomeScreen);
                    }
                }

                Tick();

                Thread.Sleep(_speed);
            }
        }

        private void PongBall()
        {
            bool isUpperCollisionOne = Ball.Row >= PlayerOne.Row - Ball.Radius;
            bool isLowerColisionOne = Ball.Row <= PlayerOne.Row + PlayerOne.Height + Ball.Radius;

            bool isUpperCollisionTwo = Ball.Row >= PlayerTwo.Row - Ball.Radius;
            bool isLowerColisionTwo = Ball.Row <= PlayerTwo.Row + PlayerTwo.Height + Ball.Radius;

            if (Ball.Right && 
                Ball.ColumnDestination == Ball.PongRight && 
                Aligned(PlayerTwo))
            {
                Ball.Right = false;
            }
            else if(Ball.Column == PlayerOne.Width+1 && Aligned(PlayerOne))
            {
                Ball.Right = true;
            }
        }

        private bool Aligned(Player player)
        {
            bool isUpperCollision = Ball.RowDestination >= player.RowDestination - Ball.Radius;
            bool isLowerColision = Ball.RowDestination <= player.RowDestination + player.Height + Ball.Radius;
            return isUpperCollision && isLowerColision;
        }

        // Score methods
        private void UpdateScore()
        {
            if (Ball.Column == 0 && PlayerTwo.Score < MaxScore - 1)
            {
                PlayerTwo._score += 1;
                RefreshScore();
                DisplayMessage("Player Two scored!");
                Ball.Reset();
            }
            else if (Ball.Column == Ball.LastCol && PlayerOne.Score < MaxScore - 1)
            {
                PlayerOne._score += 1;
                RefreshScore();
                DisplayMessage("Player One scored!");
                Ball.Reset();
            }
            else if (Ball.Column == Ball.LastCol && PlayerOne.Score == MaxScore-1)
            {
                PlayerOne.Score += 1;
                RefreshScore();
                DisplayMessage("Player One WINS!");
                ExecCommand(Command.HomeScreen);
            }
            else if (Ball.Column == 0 && PlayerTwo.Score == MaxScore-1)
            {
                PlayerTwo.Score += 1;
                RefreshScore();
                DisplayMessage("Player Two WINS!");
                ExecCommand(Command.HomeScreen);
            }
        }

        private void RefreshScore()
        {
            Score.Content = $"{PlayerOne._score}-{PlayerTwo._score}";
            Score.Print();
        }

        private void ResetScores()
        {
            PlayerOne._score = 0;
            PlayerTwo._score = 0;
        }

        public void DisplayScore()
        {
            Score.Print();
        }

        private void DisplayMessage(string playerTwoScored)
        {
            var alert = new Alert(_verticalMiddle, _horizontalMiddle, playerTwoScored);
            alert.Print();
            Console.ReadKey(true);
            alert.Clear();
        }

        public void ExecCommand( Command command)
        {
            switch (command)
            {
                case Command.Exit:
                    Console.Clear();
                    Console.WriteLine("Exit successful!");
                    Environment.Exit(0);
                    break;
                case Command.HomeScreen:
                    //end game clear da go to home screen
                    Console.Clear();
                    ResetScores();
                    Startup.HomeScreen(Context, Console.BufferWidth, Console.BufferHeight);
                    break;
            }
        }

        public void Tick()
        {
            // iterate bot player
            PlayerTwo.Tick(Ball);

            // iterate ball
            Ball.Tick();
            
            //Check pong
            PongBall();

            // draw first playe on screen
            PlayerOne.Move();

            // draw second player on the screen
            PlayerTwo.Move();

            // draw the ball
            Ball.Move();

            // update score
            UpdateScore();
            Score.Print();
        }
    }
}
