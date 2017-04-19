namespace MetaPong.Utilities.ScreenElements
{
    using System;

    public class MovingElement : ScreenElement
    {
        public string[] _layout;
        protected int _rowDestination;
        protected int _columnDestination;
        protected bool _visible;

        public MovingElement(int row, int column)
            : base(row, column)
        {
            _rowDestination = _row;
            _columnDestination = column;
            _layout = new[] { "" };
            _visible = false;
        }

        public MovingElement(int row) : base(row)
        {
            _rowDestination = _row;
            _columnDestination = _column;
            _visible = false;
        }

        public void SetLayout(string[] layout)
        {
            _layout = layout;
        }

        public virtual void Move()
        {
            if (_visible && (_rowDestination != _row || _columnDestination != _column))
            {
                Console.MoveBufferArea(
                    _column,
                    _row,
                    _layout[0].Length,
                    _layout.Length,
                    _columnDestination,
                    _rowDestination
                );
                _row = _rowDestination;
                _column = _columnDestination;
            }
        }

        public override void Print()
        {
            Console.SetCursorPosition(Column,Row);

            foreach (string line in _layout)
            {
                int colAfter = Console.CursorLeft + line.Length;
                Console.Write(line);
                Console.CursorLeft = Column;
                if (colAfter < Console.WindowWidth && Console.CursorTop < Console.BufferHeight-1)
                {
                    Console.CursorTop++;
                }
                
            }
            _visible = true;
        }
    }
}
