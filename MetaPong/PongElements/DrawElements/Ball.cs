namespace MetaPong.PongElements.DrawElements
{
    using System;
    using Utilities;
    using Utilities.ScreenElements;


    public class Ball: MovingElement
    {
        private int _diameter;
        public int LastBallRow;
        public int LastBallCol;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ball"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="diameter">The diameter.</param>
        public Ball(int row, int column, int diameter) : base(row, column)
        {
            // set positon, diameter, and visualization;
            _row = row;
            _column = column;
            Diameter = diameter;
            _layout = Composer.Compose(Composer.MakeBoxLayout(_diameter, _diameter));

            // set limitations for the movement of the ball;
            LastBallRow = Console.BufferHeight - 1 - _diameter;
            LastBallCol = Console.BufferWidth - 1 - _diameter;

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
            else if (!Up && Row == LastBallRow)
            {
                Up = true;
            }
        }

        private void SetVertical()
        {
            if (Right && Column == LastBallCol)
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
            if (!Up && Row <= LastBallRow)
            {
                _rowDestination += 1;
            }
            else if (Up && Row > 0)
            {
                _rowDestination -= 1;
            }

            SetHorizontal();
        }

        private void MoveCol()
        {
            if (Right && Column <= LastBallCol)
            {
                _columnDestination += 1;
            }
            else if (!Right && Column > 0)
            {
                _columnDestination -= 1;
            }

            SetVertical();
        }

        public void Reset()
        {
            _columnDestination = Console.BufferWidth / 2;
            _rowDestination = Console.BufferHeight / 2;
            Move();
        }

        public void Tick()
        {
            MoveCol();
            MoveRow();
        }
    }
}
