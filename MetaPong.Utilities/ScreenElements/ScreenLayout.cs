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
                if (colAfter >= Console.WindowWidth)
                {
                    Console.Write(line);
                    Console.CursorLeft = Column;
                }
                else
                {
                    Console.Write(line);
                    Console.CursorLeft -= line.Length;
                    Console.CursorTop++; 
                }
                
            }
        }
    }
}
