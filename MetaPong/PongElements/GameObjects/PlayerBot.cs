namespace MetaPong.PongElements.GameObjects
{
    using System;


    public class PlayerBot: Player
    {
        private static readonly Random Random = new Random();
        private int _accuracy;

        public PlayerBot(int row, int column, string side, int accuracy) : base(row, column)
        {
            Accuracy = accuracy;
        }

        public PlayerBot(int row, string side, int accuracy) : base(row, side)
        {
            Accuracy = accuracy;
        }

        public int Accuracy
        {
            private get { return _accuracy; }
            set
            {
                if (value <= 100 && value > 0 )
                {
                    _accuracy = value;
                }
                else
                {
                    throw new ArgumentException("Accuracy should be between 1 and 100%!");
                }
            }
        }

        public void Tick(Ball ball)
        {
            int randomNum = Random.Next(1, 101);

            if (randomNum <= _accuracy)
            {
                if (ball.Up)
                {
                    MoveUp();
                }

                else
                {
                    MoveDown();
                }
            }
        }
    }
}
