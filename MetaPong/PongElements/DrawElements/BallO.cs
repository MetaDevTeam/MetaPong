namespace MetaPong.PongElements.DrawElements
{
    using System;
    using Utilities;
    using Utilities.ScreenElements;


    public class BallO: ScreenLayout
    {
        private int _diameter;
        private int _lastBallRow;
        private int _lastBallCol;

        public BallO(int row, int column, int diameter) : base(row, column)
        {
            // set positon, diameter, and visualization;
            _row = row;
            _column = column;
            Diameter = diameter;
            _layout = Composer.Compose(Composer.MakeBoxLayout(_diameter, _diameter));

            // set limitations for the movement of the ball;
            _lastBallRow = Console.BufferHeight - 1 - _diameter;
            _lastBallCol = Console.BufferWidth - 1 - _diameter;

            // set initial direciton;
            Up = true;
            Right = true;
        }

        public int Diameter
        {
            get { return _diameter; }
            set
            {
                if (value >= 2)
                {
                    _diameter = value;
                }
                else
                {
                    throw new ArgumentException("Ball diameter shoud not be less then 2!");
                }
            }
        }

        // movement direction and managment
        public bool Up { get; set; }
        public bool Right { get; set; }

        private void SetHorizontal()
        {
            if (Up && Row == 0)
            {
                Up = false;
            }
            else if (!Up && Row == _lastBallRow)
            {
                Up = true;
            }
        }

        private void SetVertical()
        {
            if (Right && Column == _lastBallCol)
            {
                Right = false;
            }
            else if (!Right && Column == 0)
            {
                Right = true;
            }
        }

        private void MoveRow()
        {
            if (!Up && Row <= _lastBallRow)
            {
                _destinationRow += 1;
            }
            else if (Up && Row > 0)
            {
                _destinationRow -= 1;
            }

            SetHorizontal();
        }

        private void MoveCol()
        {
            if (Right && Column <= _lastBallCol)
            {
                _destinationColumn += 1;
            }
            else if (!Right && Column > 0)
            {
                _destinationColumn -= 1;
            }

            SetVertical();
        }

        public void Tick()
        {
            MoveCol();
            MoveRow();
        }
    }
}
