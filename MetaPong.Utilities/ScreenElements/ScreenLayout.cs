namespace MetaPong.Utilities.ScreenElements
{
    using System;

    public class ScreenLayout : ScreenElement
    {
        private string[] _layout;

        public ScreenLayout(int row, int column)
            : base(row, column)
        {
            _layout = new[] { "" };
        }

        public void SetLayout(string[] layout)
        {
            _layout = layout;
        }

        public override void Print()
        {
            Console.SetCursorPosition(Column,Row);

            foreach (string line in _layout)
            {
                int colAfter = Console.CursorLeft + line.Length;
                int cursorTop = Console.CursorTop;
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
