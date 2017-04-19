namespace MetaPong.Utilities.ScreenElements
{
    using System;

    public class ScreenLayout : ScreenElement
    {
        public string[] _layout;
        protected int _destinationRow;
        protected int _destinationColumn;
        protected bool _visible;

        public ScreenLayout(int row, int column)
            : base(row, column)
        {
            _destinationRow = _row;
            _destinationColumn = column;
            _layout = new[] { "" };
            _visible = false;
        }

        public ScreenLayout(int row) : base(row)
        {
            _destinationRow = _row;
            _destinationColumn = _column;
            _visible = false;
        }

        public void SetLayout(string[] layout)
        {
            _layout = layout;
        }

        public virtual void Move()
        {
            if (_visible && (_destinationRow != _row || _destinationColumn != _column))
            {
                Console.MoveBufferArea(
                    _column,
                    _row,
                    _layout[0].Length,
                    _layout.Length,
                    _destinationColumn,
                    _destinationRow
                );
                _row = _destinationRow;
                _column = _destinationColumn;
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
