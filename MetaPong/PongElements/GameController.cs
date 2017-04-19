namespace MetaPong.PongElements
{
    using System;
    using System.Threading;
    using DrawElements;
    using Utilities.Enumeration;
    using Utilities.ScreenElements;
    using Utilities.ScreenElements.Composit;


    public class GameController
    {
        private int _verticalMiddle;
        private int _horizontalMiddle;
        private Label _score;
        private int _speed;
        private const string ScoresTemplate = "{0} sored!";
        private const string WinsTemplate = "{0} WINS!";

        /// <summary>
        /// Initializes a new instance of the MetaPong game.<see cref="GameController"/> class.
        /// </summary>
        /// <param name="playerOne">The first player, should be controlled by user.</param>
        /// <param name="playerTwo">The second player controlled by a bot. </param>
        /// <param name="speed">Larger values make the game slower.</param>
        /// <param name="maxScore">Defines the score at which the game ends.</param>
        public GameController(Player playerOne, PlayerBot playerTwo, int speed=50, int maxScore=10)
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

            // alerts
            MessageWins = new Alert(_verticalMiddle, _horizontalMiddle, WinsTemplate);
            MessageScores = new Alert(_verticalMiddle, _horizontalMiddle, ScoresTemplate);

            _speed = speed;
            MaxScore = maxScore;
        }

        public Player PlayerOne { get; set; }
        public PlayerBot PlayerTwo { get; set; }
        public Ball Ball { get; set; }
        public Label Score { get; set; }
        public int MaxScore { get; set; }
        public Alert MessageScores { get; set; }
        public Alert MessageWins { get; set; }

        public void Load()
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
                        ExecCommand(Command.HomeScreen);
                    }
                }

                Tick();

                Thread.Sleep(_speed);
            }
        }

        private void PongBall()
        {
            if (Ball.Right && 
                Ball.Column == Ball.LastCol && 
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
            return Ball.Row <= player.Row - Ball.Radius && 
                   Ball.Row >= player.Row + player.Height + Ball.Radius;
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

        public void ExecCommand(Command command)
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
                    Startup.HomeScreen(Console.BufferWidth, Console.BufferHeight);
                    break;
            }
        }

        public void Tick()
        {
            // iterate bot player
            PlayerTwo.Tick(Ball);

            // iterate ball
            Ball.Tick();

            // draw first playe on screen
            PlayerOne.Move();

            // draw second player on the screen
            PlayerTwo.Move();

            // draw the ball
            Ball.Move();

            //Check pong
            PongBall();

            // update score
            UpdateScore();
            Score.Print();
        }
    }
}
