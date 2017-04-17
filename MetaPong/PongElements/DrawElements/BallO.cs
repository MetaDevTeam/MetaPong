namespace MetaPong.PongElements.DrawElements
{
    using System;
    using System.Collections.Generic;
    using Utilities;
    using Utilities.ScreenElements;


    public class BallO: ScreenLayout
    {
        private int _diameter;

        public BallO(int row, int column, int diameter) : base(row, column)
        {
            _row = row;
            _column = column;
            Diameter = diameter;
            Up = true;
            Right = true;
            _layout = Composer.Compose(Composer.MakeBoxLayout(_diameter, diameter));
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

        public bool Up { get; set; }
        public bool Right { get; set; }

        private void MoveRow()
        {
            int lastBallRow = Console.BufferHeight - 1 - _diameter;
            if (!Up && Row <= lastBallRow)
            {
                Row += 1;
            }
            else if (Up && Row > 0)
            {
                Row -= 1;
            }

            if (Up && Row == 0)
            {
                Up = false;
            }
            else if (!Up && Row == lastBallRow)
            {
                Up = true;
            }
        }

        private void MoveCol()
        {
            int lastBallCol = Console.WindowWidth - 1 - _diameter;

            if (Right && Column <= lastBallCol)
            {
                Column += 1;
            }
            else if (!Right && Column > 0)
            {
                Column -= 1;
            }

            if (Right && Column == lastBallCol)
            {
                Right = false;
            }
            else if (!Right && Column == 0)
            {
                Right = true;
            }
        }

        public void Tick()
        {
            MoveCol();
            MoveRow();
        }
    }
}
