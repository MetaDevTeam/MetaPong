namespace MetaPong.Utilities.ScreenElements
{
    using System;

    public class ScreenLayout : ScreenElement
    {
        public string[] _layout;

        public ScreenLayout(int row, int column)
            : base(row, column)
        {
            _layout = new[] { "" };
        }

        public ScreenLayout(int row) : base(row)
        {
            _column = 0;
            _row = row;
        }

        public void SetLayout(string[] layout)
        {
            _layout = layout;
        }

        public virtual void Hide()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Print();
            Console.ForegroundColor = ConsoleColor.White;
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
        }
    }
}
