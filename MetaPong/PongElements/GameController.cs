namespace MetaPong.PongElements
{
    using System;
    using DrawElements;
    using Utilities.Enumeration;
    using Utilities.ScreenElements;
    using Utilities.ScreenElements.Composit;


    public class GameController
    {
        private int _verticalMiddle;
        private int _horizontalMiddle;
        private Label _score;
        private const string ScoresTemplate = "{0} sored!";
        private const string WinsTemplate = "{0} WINS!";

        /// <summary>
        /// Initializes a new instance of the MetaPong game.<see cref="GameController"/> class.
        /// </summary>
        /// <param name="playerOne">The first player, should be controlled by user.</param>
        /// <param name="playerTwo">The second player controlled by a bot. </param>
        public GameController(Player playerOne, PlayerBot playerTwo)
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

            // max score
            MaxScore = 2;
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
        }

        private void UpdateScore()
        {
            if (Ball.Column < 3)
            {
                PlayerTwo._score += 1;
                Score.Content = $"{PlayerOne._score}-{PlayerTwo._score}";
                DisplayMessage("Player Two scored!");
            }
            else if (Ball.Column > Ball.LastBallCol - PlayerTwo.Thickness)
            {
                PlayerOne._score += 1;
                Score.Content = $"{PlayerOne._score}-{PlayerTwo._score}";
                DisplayMessage("Player One scored!");
            }
            if (PlayerOne.Score == MaxScore)
            {
                new Alert(_verticalMiddle, _horizontalMiddle, "Player One WINS!").Print();
                ExecCommand(Command.HomeScreen);
            }
            else if (PlayerOne.Score == MaxScore)
            {
                new Alert(_verticalMiddle, _horizontalMiddle, "Player Two WINS!").Print();
            }
        }

        private void DisplayMessage(string playerTwoScored)
        {
            var alert = new Alert(_verticalMiddle, _horizontalMiddle, playerTwoScored);
            alert.Print();
            Console.ReadKey(true);
            alert.Clear();
            Ball.Reset();
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

        private void ResetScores()
        {
            PlayerOne._score = 0;
            PlayerTwo._score = 0;
        }

        public void DisplayScore()
        {
            Score.Print();
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

            UpdateScore();
            Score.Print();
        }
    }
}
